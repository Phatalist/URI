using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainServer.Classes;
using MainServer.Controller;

namespace MainServer
{
	// Token: 0x02000005 RID: 5
	public partial class UserEdit : Form
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002A14 File Offset: 0x00002A14
		public UserEdit()
		{
			this.InitializeComponent();
			IntPtr handle = base.Handle;
			this.UpdateView();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002A48 File Offset: 0x00002A48
		public async Task UpdateView()
		{
			await Task.Factory.StartNew(delegate
			{
				base.Invoke(new MethodInvoker(delegate
				{
					this.userLv.Items.Clear();
				}));
				using (List<User>.Enumerator enumerator = Singleton<Controller>.Instance._base.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						User item = enumerator.Current;
						base.Invoke(new MethodInvoker(delegate
						{
							this.userLv.Items.Add(new ListViewItem(new string[]
							{
								(this.userLv.Items.Count + 1).ToString(),
								item.Login,
								item.Password,
								item.Activated.ToString()
							}));
						}));
					}
				}
			});
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002A90 File Offset: 0x00002A90
		private async void button1_Click(object sender, EventArgs e)
		{
			await this.UpdateView();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002ADC File Offset: 0x00002ADC
		private async void активироватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			await Task.Factory.StartNew<Task>(async delegate
			{
				int current = Convert.ToInt32(this.userLv.FocusedItem.SubItems[0].Text) - 1;
				Singleton<Controller>.Instance._base[current].Activated = true;
				await this.UpdateView();
			});
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002B28 File Offset: 0x00002B28
		private async void деактивироватьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int current = Convert.ToInt32(this.userLv.FocusedItem.SubItems[0].Text) - 1;
			await Task.Factory.StartNew<Task>(async delegate
			{
				Singleton<Controller>.Instance._base[current].Activated = false;
				await this.UpdateView();
			});
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002B74 File Offset: 0x00002B74
		private async void модулиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int current = Convert.ToInt32(this.userLv.FocusedItem.SubItems[0].Text) - 1;
			await Task.Factory.StartNew(delegate
			{
				new ModuleView(current).ShowDialog();
			});
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002BC0 File Offset: 0x00002BC0
		private async void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int current = Convert.ToInt32(this.userLv.FocusedItem.SubItems[0].Text) - 1;
			await Task.Factory.StartNew<Task>(async delegate
			{
				new UserEditCredent(current).ShowDialog();
				await this.UpdateView();
			});
		}
	}
}
