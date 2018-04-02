using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MainServer.Classes;
using MainServer.Controller;

namespace MainServer
{
	// Token: 0x02000002 RID: 2
	public partial class MainFrm : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00002050
		public MainFrm()
		{
			this.InitializeComponent();
			IntPtr handle = base.Handle;
			Controller instance = Singleton<Controller>.Instance;
			instance.SystemHandler = (SystemHandler)Delegate.Combine(instance.SystemHandler, new SystemHandler(this.WriteLog));
			Controller instance2 = Singleton<Controller>.Instance;
			instance2.UserAuthHandler = (AuthHandler)Delegate.Combine(instance2.UserAuthHandler, new AuthHandler(delegate(string user)
			{
				base.Invoke(new MethodInvoker(delegate
				{
					this.logWindow.AppendText(DateTime.Now.ToString() + string.Format("   |\tПользователь {0} авторизовался", user) + Environment.NewLine);
				}));
				object obj = this.forLock;
				lock (obj)
				{
					File.AppendAllText("logs.txt", DateTime.Now.ToString() + string.Format("   |\tПользователь {0} авторизовался", user) + Environment.NewLine);
				}
			}));
			Controller instance3 = Singleton<Controller>.Instance;
			instance3.UserRegHandler = (NewUserHandler)Delegate.Combine(instance3.UserRegHandler, new NewUserHandler(delegate(User user)
			{
				Singleton<Controller>.Instance._base.Add(user);
				base.Invoke(new MethodInvoker(delegate
				{
					this.logWindow.AppendText(DateTime.Now.ToString() + string.Format("   |\tПользователь {0} зарегистрировался", user.Login) + Environment.NewLine);
				}));
				object obj = this.forLock;
				lock (obj)
				{
					File.AppendAllText("logs.txt", DateTime.Now.ToString() + string.Format("   |\tПользователь {0} зарегистрировался", user.Login) + Environment.NewLine);
				}
			}));
			Singleton<Controller>.Instance.InitServer<Implement>();
			Thread thread = new Thread(delegate
			{
				for (;;)
				{
					bool needToSave = Singleton<Controller>.Instance.NeedToSave;
					if (needToSave)
					{
						Singleton<Controller>.Instance.SaveBase();
					}
					Thread.Sleep(300000);
					base.Invoke(new MethodInvoker(delegate
					{
						this.logWindow.ResetText();
					}));
				}
			})
			{
				IsBackground = true
			};
			thread.Start();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002124 File Offset: 0x00002124
		public void WriteLog(string message)
		{
			base.Invoke(new MethodInvoker(delegate
			{
				this.logWindow.AppendText(DateTime.Now.ToString() + "   |\t" + message + Environment.NewLine);
			}));
			object obj = this.forLock;
			lock (obj)
			{
				File.AppendAllText("logs.txt", DateTime.Now.ToString() + "   |\t" + message + Environment.NewLine);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000021B8 File Offset: 0x000021B8
		private void clearBtn_Click(object sender, EventArgs e)
		{
			this.logWindow.ResetText();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021C7 File Offset: 0x000021C7
		private void logWindow_TextChanged(object sender, EventArgs e)
		{
			this.logWindow.SelectionStart = this.logWindow.Text.Length;
			this.logWindow.ScrollToCaret();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021F4 File Offset: 0x000021F4
		private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool needToSave = Singleton<Controller>.Instance.NeedToSave;
			if (needToSave)
			{
				Singleton<Controller>.Instance.SaveBase();
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000221B File Offset: 0x0000221B
		private void userViewBtn_Click(object sender, EventArgs e)
		{
			new UserEdit().Show();
		}

		// Token: 0x04000001 RID: 1
		public object forLock = new object();
	}
}
