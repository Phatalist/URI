using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;
using System.Xml.Serialization;
using MainServer.Classes;

namespace MainServer.Controller
{
	// Token: 0x0200000C RID: 12
	public class Controller : Singleton<Controller>
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000362A File Offset: 0x0000362A
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00003632 File Offset: 0x00003632
		public string ServiceAdress { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003A RID: 58 RVA: 0x0000363C File Offset: 0x0000363C
		public string LocalPath
		{
			get
			{
				return "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\Common7\\IDE\\devenv.com";
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003653 File Offset: 0x00003653
		public void OnNewUser(User user)
		{
			NewUserHandler userRegHandler = this.UserRegHandler;
			if (userRegHandler != null)
			{
				userRegHandler(user);
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003669 File Offset: 0x00003669
		public void OnAuthwUser(string user)
		{
			AuthHandler userAuthHandler = this.UserAuthHandler;
			if (userAuthHandler != null)
			{
				userAuthHandler(user);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000367F File Offset: 0x0000367F
		public void OnSystem(string user)
		{
			SystemHandler systemHandler = this.SystemHandler;
			if (systemHandler != null)
			{
				systemHandler(user);
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003698 File Offset: 0x00003698
		public User CreateUser()
		{
			return new User
			{
				Activated = false,
				Modules = new List<ModuleFile>
				{
					new ModuleFile
					{
						FileName = "MainModule.dll",
						FilePath = "\\MainModule.dll",
						FileURL = File.ReadAllText("ModuleLink.txt").Trim()
					}
				}
			};
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000036FC File Offset: 0x000036FC
		public void InitServer<T>()
		{
			try
			{
				this.LoadBase();
				bool flag = File.Exists("ip.cfg");
				if (!flag)
				{
					throw new FileNotFoundException("Не найден файл ip.cfg");
				}
				bool flag2 = string.IsNullOrWhiteSpace(File.ReadAllText("ip.cfg"));
				if (flag2)
				{
					throw new NullReferenceException("Заполните файл ip.cfg");
				}
				this.ServiceAdress = File.ReadAllText("ip.cfg");
				BasicHttpBinding basicHttpBinding = new BasicHttpBinding
				{
					Security = new BasicHttpSecurity
					{
						Mode = BasicHttpSecurityMode.None
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
				basicHttpBinding.OpenTimeout = new TimeSpan(24, 30, 0);
				basicHttpBinding.CloseTimeout = new TimeSpan(24, 30, 0);
				basicHttpBinding.SendTimeout = new TimeSpan(24, 30, 0);
				basicHttpBinding.ReceiveTimeout = new TimeSpan(24, 30, 0);
				Uri uri = new Uri(string.Format("http://{0}:12621", this.ServiceAdress));
				ServiceHost serviceHost = new ServiceHost(typeof(T), new Uri[]
				{
					uri
				});
				ServiceMetadataBehavior serviceMetadataBehavior = serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
				bool flag3 = serviceMetadataBehavior == null;
				if (flag3)
				{
					serviceMetadataBehavior = new ServiceMetadataBehavior
					{
						HttpGetEnabled = true
					};
					serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
				}
				serviceHost.AddServiceEndpoint(typeof(IUser), basicHttpBinding, "IUser");
				ServiceThrottlingBehavior item = new ServiceThrottlingBehavior
				{
					MaxConcurrentCalls = int.MaxValue,
					MaxConcurrentInstances = int.MaxValue,
					MaxConcurrentSessions = int.MaxValue
				};
				serviceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
				serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior
				{
					IncludeExceptionDetailInFaults = true
				});
				serviceHost.Description.Behaviors.Add(item);
				serviceHost.Open();
				for (int i = 0; i < this._base.Count; i++)
				{
					this._base[i].Modules = new List<ModuleFile>
					{
						new ModuleFile
						{
							FileName = "MainModule.dll",
							FilePath = "\\MainModule.dll",
							FileURL = File.ReadAllText("ModuleLink.txt").Trim()
						}
					};
				}
				this.NeedToSave = true;
				this.Exchangers.Add("Yobit");
				this.Exchangers.Add("Exmo");
				this.Exchangers.Add("Bittrex");
				this.Exchangers.Add("Poloniex");
				this.Exchangers.Add("Cryptopia");
				this.Exchangers.Add("Hitbtc");
				this.Exchangers.Add("Binance");
				this.Exchangers.Add("Bitfinex");
				this.Exchangers.Add("Livecoin");
				this.OnSystem("Сервер запущен. Прослушивается адресс: " + string.Format("http://{0}:12621", this.ServiceAdress));
				this.OnSystem(string.Format("Пользователей: {0}", this._base.Count));
			}
			catch (Exception ex)
			{
				this.NeedToSave = false;
				this.OnSystem(string.Format("При загрузки БД возникла ошибка: {0}", ex.Message));
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003AC0 File Offset: 0x00003AC0
		public void LoadBase()
		{
			try
			{
				bool flag = File.Exists("DataBase.xml");
				if (flag)
				{
					using (FileStream fileStream = new FileStream("DataBase.xml", FileMode.Open))
					{
						this._base = (List<User>)this.dbFormat.Deserialize(fileStream);
					}
				}
				else
				{
					bool flag2 = this._base == null;
					if (flag2)
					{
						this._base = new List<User>();
					}
				}
			}
			catch (Exception ex)
			{
				this.OnSystem(string.Format("При загрузки БД возникла ошибка: {0}", ex.Message));
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003B68 File Offset: 0x00003B68
		public void SaveBase()
		{
			try
			{
				lock (this)
				{
					using (FileStream fileStream = new FileStream("DataBase.xml", FileMode.Create))
					{
						this.dbFormat.Serialize(fileStream, this._base);
					}
				}
				this.OnSystem("БД успешно сохранена.");
			}
			catch (Exception ex)
			{
				this.OnSystem(string.Format("При сохранении БД возникла ошибка: {0}", ex.Message));
			}
		}

		// Token: 0x04000020 RID: 32
		public List<string> Exchangers = new List<string>();

		// Token: 0x04000021 RID: 33
		private XmlSerializer dbFormat = new XmlSerializer(typeof(List<User>));

		// Token: 0x04000022 RID: 34
		public bool NeedToSave = false;

		// Token: 0x04000024 RID: 36
		public NewUserHandler UserRegHandler;

		// Token: 0x04000025 RID: 37
		public AuthHandler UserAuthHandler;

		// Token: 0x04000026 RID: 38
		public SystemHandler SystemHandler;

		// Token: 0x04000027 RID: 39
		public List<User> _base = new List<User>();
	}
}
