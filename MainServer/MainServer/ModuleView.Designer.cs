namespace MainServer
{
	// Token: 0x02000003 RID: 3
	public partial class ModuleView : global::System.Windows.Forms.Form
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00002798 File Offset: 0x00002798
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000027D0 File Offset: 0x000027D0
		private void InitializeComponent()
		{
			this.modulesTb = new global::System.Windows.Forms.TextBox();
			this.saveBtn = new global::System.Windows.Forms.Button();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.modulesTb.Location = new global::System.Drawing.Point(12, 12);
			this.modulesTb.Multiline = true;
			this.modulesTb.Name = "modulesTb";
			this.modulesTb.Size = new global::System.Drawing.Size(369, 306);
			this.modulesTb.TabIndex = 0;
			this.saveBtn.Location = new global::System.Drawing.Point(12, 324);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new global::System.Drawing.Size(75, 23);
			this.saveBtn.TabIndex = 1;
			this.saveBtn.Text = "Сохранить";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new global::System.EventHandler(this.saveBtn_Click);
			this.cancelBtn.Location = new global::System.Drawing.Point(306, 324);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new global::System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "Отмена";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(393, 352);
			base.Controls.Add(this.cancelBtn);
			base.Controls.Add(this.saveBtn);
			base.Controls.Add(this.modulesTb);
			base.Name = "ModuleView";
			this.Text = "ModuleView";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000007 RID: 7
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.TextBox modulesTb;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.Button saveBtn;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Button cancelBtn;
	}
}
