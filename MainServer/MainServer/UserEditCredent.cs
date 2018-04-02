using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainServer.Classes;
using MainServer.Controller;

namespace MainServer
{
	// Token: 0x02000006 RID: 6
	public partial class UserEditCredent : Form
	{
		// Token: 0x06000020 RID: 32 RVA: 0x000031DC File Offset: 0x000031DC
		public UserEditCredent(int current)
		{
			this.InitializeComponent();
			this.ID = current;
			this.loginTb.Text = Singleton<Controller>.Instance._base[this.ID].Login;
			this.passwordTb.Text = Singleton<Controller>.Instance._base[this.ID].Password;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000325C File Offset: 0x0000325C
		private async void saveBtn_Click(object sender, EventArgs e)
		{
			string login = this.loginTb.Text;
			string pass = this.passwordTb.Text;
			await Task.Factory.StartNew(delegate
			{
				Singleton<Controller>.Instance._base[this.ID].Login = login;
				Singleton<Controller>.Instance._base[this.ID].Password = pass;
			});
			base.Close();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000278E File Offset: 0x0000278E
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x04000017 RID: 23
		private int ID = -1;
	}
}
