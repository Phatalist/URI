namespace MainServer
{
	// Token: 0x02000006 RID: 6
	public partial class UserEditCredent : global::System.Windows.Forms.Form
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000032A8 File Offset: 0x000032A8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000032E0 File Offset: 0x000032E0
		private void InitializeComponent()
		{
			this.loginTb = new global::System.Windows.Forms.TextBox();
			this.passwordTb = new global::System.Windows.Forms.TextBox();
			this.saveBtn = new global::System.Windows.Forms.Button();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.loginTb.Location = new global::System.Drawing.Point(12, 15);
			this.loginTb.Name = "loginTb";
			this.loginTb.Size = new global::System.Drawing.Size(280, 20);
			this.loginTb.TabIndex = 0;
			this.loginTb.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.passwordTb.Location = new global::System.Drawing.Point(12, 41);
			this.passwordTb.Name = "passwordTb";
			this.passwordTb.Size = new global::System.Drawing.Size(280, 20);
			this.passwordTb.TabIndex = 1;
			this.passwordTb.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.saveBtn.Location = new global::System.Drawing.Point(12, 74);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new global::System.Drawing.Size(75, 23);
			this.saveBtn.TabIndex = 2;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new global::System.EventHandler(this.saveBtn_Click);
			this.cancelBtn.Location = new global::System.Drawing.Point(217, 74);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 3;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(304, 109);
			base.Controls.Add(this.cancelBtn);
			base.Controls.Add(this.saveBtn);
			base.Controls.Add(this.passwordTb);
			base.Controls.Add(this.loginTb);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "UserEditCredent";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UserEditCredent";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000018 RID: 24
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.TextBox loginTb;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.TextBox passwordTb;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Button saveBtn;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Button cancelBtn;
	}
}
