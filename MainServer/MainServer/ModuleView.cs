using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainServer.Classes;
using MainServer.Controller;

namespace MainServer
{
	// Token: 0x02000003 RID: 3
	public partial class ModuleView : Form
	{
		// Token: 0x0600000D RID: 13 RVA: 0x0000267C File Offset: 0x0000267C
		public ModuleView(int current)
		{
			try
			{
				this.InitializeComponent();
				IntPtr handle = base.Handle;
				this.ID = current;
				this.LoadModules();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026E0 File Offset: 0x000026E0
		public void LoadModules()
		{
			bool flag = Singleton<Controller>.Instance._base[this.ID].ActivatedModules.Count > 0;
			if (flag)
			{
				this.modulesTb.Text = string.Join(Environment.NewLine, Singleton<Controller>.Instance._base[this.ID].ActivatedModules);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002744 File Offset: 0x00002744
		private async void saveBtn_Click(object sender, EventArgs e)
		{
			Singleton<Controller>.Instance._base[this.ID].ActivatedModules = (from x in this.modulesTb.Lines
			select x.Trim()).ToList<string>();
			base.Close();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000278E File Offset: 0x0000278E
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x04000006 RID: 6
		private int ID = -1;
	}
}
