namespace Widhdraw_app
{
	// Token: 0x0200000B RID: 11
	public partial class MainFrm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00004B9C File Offset: 0x00002D9C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004BD4 File Offset: 0x00002DD4
		private void InitializeComponent()
		{
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.signInBtn = new global::System.Windows.Forms.Button();
			this.apiSecretTb = new global::System.Windows.Forms.TextBox();
			this.apiKeyTb = new global::System.Windows.Forms.TextBox();
			this.balanceView = new global::System.Windows.Forms.ListView();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.adressTb = new global::System.Windows.Forms.TextBox();
			this.amountTb = new global::System.Windows.Forms.TextBox();
			this.currTb = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.sendBtn = new global::System.Windows.Forms.Button();
			this.label6 = new global::System.Windows.Forms.Label();
			this.invoiceTb = new global::System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.signInBtn);
			this.groupBox1.Controls.Add(this.apiSecretTb);
			this.groupBox1.Controls.Add(this.apiKeyTb);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(223, 161);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Авторизация";
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[]
			{
				"Bittrex",
				"Yobit",
				"Cryptopia",
				"Poloniex",
				"Bitfinex",
				"Exmo",
				"Livecoin",
				"Binance",
				"Hitbtc"
			});
			this.comboBox1.Location = new global::System.Drawing.Point(6, 127);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.Text = "Yobit";
			this.comboBox1.SelectedValueChanged += new global::System.EventHandler(this.comboBox1_SelectedValueChanged);
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(6, 73);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(74, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "SECRET KEY";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(6, 24);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(48, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "API KEY";
			this.signInBtn.Location = new global::System.Drawing.Point(142, 125);
			this.signInBtn.Name = "signInBtn";
			this.signInBtn.Size = new global::System.Drawing.Size(75, 23);
			this.signInBtn.TabIndex = 2;
			this.signInBtn.Text = "Войти";
			this.signInBtn.UseVisualStyleBackColor = true;
			this.signInBtn.Click += new global::System.EventHandler(this.signInBtn_Click);
			this.apiSecretTb.Location = new global::System.Drawing.Point(6, 89);
			this.apiSecretTb.Name = "apiSecretTb";
			this.apiSecretTb.Size = new global::System.Drawing.Size(211, 20);
			this.apiSecretTb.TabIndex = 1;
			this.apiKeyTb.Location = new global::System.Drawing.Point(6, 40);
			this.apiKeyTb.Name = "apiKeyTb";
			this.apiKeyTb.Size = new global::System.Drawing.Size(211, 20);
			this.apiKeyTb.TabIndex = 0;
			this.balanceView.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2
			});
			this.balanceView.Location = new global::System.Drawing.Point(21, 177);
			this.balanceView.Name = "balanceView";
			this.balanceView.Size = new global::System.Drawing.Size(214, 266);
			this.balanceView.TabIndex = 1;
			this.balanceView.UseCompatibleStateImageBehavior = false;
			this.balanceView.View = global::System.Windows.Forms.View.Details;
			this.columnHeader1.Text = "Валюта";
			this.columnHeader1.Width = 70;
			this.columnHeader2.Text = "Баланс";
			this.columnHeader2.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 132;
			this.adressTb.Location = new global::System.Drawing.Point(293, 30);
			this.adressTb.Name = "adressTb";
			this.adressTb.Size = new global::System.Drawing.Size(222, 20);
			this.adressTb.TabIndex = 2;
			this.amountTb.Location = new global::System.Drawing.Point(293, 79);
			this.amountTb.Name = "amountTb";
			this.amountTb.Size = new global::System.Drawing.Size(222, 20);
			this.amountTb.TabIndex = 3;
			this.currTb.Location = new global::System.Drawing.Point(293, 131);
			this.currTb.Name = "currTb";
			this.currTb.Size = new global::System.Drawing.Size(222, 20);
			this.currTb.TabIndex = 4;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(290, 14);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(41, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Адрес:";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(290, 63);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(44, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Сумма:";
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(290, 115);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(48, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Валюта:";
			this.sendBtn.Location = new global::System.Drawing.Point(440, 211);
			this.sendBtn.Name = "sendBtn";
			this.sendBtn.Size = new global::System.Drawing.Size(75, 23);
			this.sendBtn.TabIndex = 8;
			this.sendBtn.Text = "Отправить";
			this.sendBtn.UseVisualStyleBackColor = true;
			this.sendBtn.Click += new global::System.EventHandler(this.button1_Click);
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(290, 160);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(108, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Invoice(только XRP)";
			this.invoiceTb.Location = new global::System.Drawing.Point(293, 176);
			this.invoiceTb.Name = "invoiceTb";
			this.invoiceTb.Size = new global::System.Drawing.Size(222, 20);
			this.invoiceTb.TabIndex = 9;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(543, 455);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.invoiceTb);
			base.Controls.Add(this.sendBtn);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.currTb);
			base.Controls.Add(this.amountTb);
			base.Controls.Add(this.adressTb);
			base.Controls.Add(this.balanceView);
			base.Controls.Add(this.groupBox1);
			base.Name = "MainFrm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Менеджер бирж";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000042 RID: 66
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000045 RID: 69
		private global::System.Windows.Forms.Button signInBtn;

		// Token: 0x04000046 RID: 70
		private global::System.Windows.Forms.TextBox apiSecretTb;

		// Token: 0x04000047 RID: 71
		private global::System.Windows.Forms.TextBox apiKeyTb;

		// Token: 0x04000048 RID: 72
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.ListView balanceView;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.TextBox adressTb;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.TextBox amountTb;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.TextBox currTb;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.Button sendBtn;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.ComboBox comboBox1;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.TextBox invoiceTb;
	}
}
