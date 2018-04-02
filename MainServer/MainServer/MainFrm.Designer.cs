namespace MainServer
{
	// Token: 0x02000002 RID: 2
	public partial class MainFrm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000222C File Offset: 0x0000222C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002264 File Offset: 0x00002264
		private void InitializeComponent()
		{
			this.userViewBtn = new global::System.Windows.Forms.Button();
			this.clearBtn = new global::System.Windows.Forms.Button();
			this.logWindow = new global::System.Windows.Forms.RichTextBox();
			base.SuspendLayout();
			this.userViewBtn.Location = new global::System.Drawing.Point(618, 492);
			this.userViewBtn.Name = "userViewBtn";
			this.userViewBtn.Size = new global::System.Drawing.Size(65, 23);
			this.userViewBtn.TabIndex = 5;
			this.userViewBtn.Text = "Users";
			this.userViewBtn.UseVisualStyleBackColor = true;
			this.userViewBtn.Click += new global::System.EventHandler(this.userViewBtn_Click);
			this.clearBtn.Location = new global::System.Drawing.Point(28, 492);
			this.clearBtn.Name = "clearBtn";
			this.clearBtn.Size = new global::System.Drawing.Size(61, 23);
			this.clearBtn.TabIndex = 4;
			this.clearBtn.Text = "Clear";
			this.clearBtn.UseVisualStyleBackColor = true;
			this.clearBtn.Click += new global::System.EventHandler(this.clearBtn_Click);
			this.logWindow.BackColor = global::System.Drawing.Color.White;
			this.logWindow.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.logWindow.Location = new global::System.Drawing.Point(2, 2);
			this.logWindow.Name = "logWindow";
			this.logWindow.Size = new global::System.Drawing.Size(693, 484);
			this.logWindow.TabIndex = 3;
			this.logWindow.Text = "";
			this.logWindow.TextChanged += new global::System.EventHandler(this.logWindow_TextChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(695, 522);
			base.Controls.Add(this.userViewBtn);
			base.Controls.Add(this.clearBtn);
			base.Controls.Add(this.logWindow);
			base.Margin = new global::System.Windows.Forms.Padding(2);
			base.Name = "MainFrm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Главный сервер";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
			base.ResumeLayout(false);
		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Button userViewBtn;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Button clearBtn;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.RichTextBox logWindow;
	}
}
