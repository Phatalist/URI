using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Widhdraw_app.TradesAPI;

namespace Widhdraw_app
{
	// Token: 0x0200000B RID: 11
	public partial class MainFrm : Form
	{
		// Token: 0x0600008C RID: 140 RVA: 0x00004AC2 File Offset: 0x00002CC2
		public MainFrm()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004AEC File Offset: 0x00002CEC
		private async void signInBtn_Click(object sender, EventArgs e)
		{
			await Task.Factory.StartNew(delegate
			{
				bool flag = string.IsNullOrWhiteSpace(this.apiKeyTb.Text);
				if (flag)
				{
					MessageBox.Show("Заполните поле API KEY");
				}
				else
				{
					bool flag2 = string.IsNullOrWhiteSpace(this.apiSecretTb.Text);
					if (flag2)
					{
						MessageBox.Show("Заполните поле Secret Key");
					}
					else
					{
						this.exchanger = ExchangerBase.CreateExchanger(this.currenExchanger, this.apiKeyTb.Text, this.apiSecretTb.Text);
						List<Currency> result = this.exchanger.GetBalance();
						bool flag3 = result.Count != 0;
						if (flag3)
						{
							this.authorized = true;
							base.Invoke(new MethodInvoker(delegate
							{
								this.balanceView.Items.Clear();
								foreach (Currency currency in result)
								{
									this.balanceView.Items.Add(new ListViewItem(new string[]
									{
										currency.Name,
										currency.Amount
									}));
								}
							}));
						}
						else
						{
							this.authorized = false;
							MessageBox.Show("Ошибка при получении баланса");
						}
					}
				}
			});
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004B38 File Offset: 0x00002D38
		private async void button1_Click(object sender, EventArgs e)
		{
			await Task.Factory.StartNew(delegate
			{
				bool flag = !this.authorized;
				if (flag)
				{
					MessageBox.Show("Выполните авторизацию.");
				}
				else
				{
					bool flag2 = string.IsNullOrWhiteSpace(this.adressTb.Text);
					if (flag2)
					{
						MessageBox.Show("Заполните поле адреса");
					}
					else
					{
						bool flag3 = string.IsNullOrWhiteSpace(this.amountTb.Text);
						if (flag3)
						{
							MessageBox.Show("Заполните поле суммы");
						}
						else
						{
							bool flag4 = string.IsNullOrWhiteSpace(this.currTb.Text);
							if (flag4)
							{
								MessageBox.Show("Заполните поле валюты");
							}
							else
							{
								MessageBox.Show(this.exchanger.Withdraw(decimal.Parse(this.amountTb.Text, new CultureInfo(CultureInfo.CurrentCulture.Name)
								{
									NumberFormat = new NumberFormatInfo
									{
										NumberDecimalSeparator = ","
									}
								}), this.currTb.Text, this.adressTb.Text, this.invoiceTb.Text));
							}
						}
					}
				}
			});
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004B82 File Offset: 0x00002D82
		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			this.currenExchanger = this.comboBox1.SelectedItem.ToString();
		}

		// Token: 0x0400003F RID: 63
		private string currenExchanger = "Yobit";

		// Token: 0x04000040 RID: 64
		private bool authorized = false;

		// Token: 0x04000041 RID: 65
		private ExchangerBase exchanger;
	}
}
