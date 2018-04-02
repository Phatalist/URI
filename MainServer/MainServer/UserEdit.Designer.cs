namespace MainServer
{
	// Token: 0x02000005 RID: 5
	public partial class UserEdit : global::System.Windows.Forms.Form
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00002C0C File Offset: 0x00002C0C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002C44 File Offset: 0x00002C44
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.userLv = new global::System.Windows.Forms.ListView();
			this.columnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new global::System.Windows.Forms.ColumnHeader();
			this.userMenu = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.активироватьToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.деактивироватьToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.модулиToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.изменитьДанныеToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new global::System.Windows.Forms.Button();
			this.userMenu.SuspendLayout();
			base.SuspendLayout();
			this.userLv.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader3,
				this.columnHeader4
			});
			this.userLv.ContextMenuStrip = this.userMenu;
			this.userLv.FullRowSelect = true;
			this.userLv.Location = new global::System.Drawing.Point(12, 12);
			this.userLv.Name = "userLv";
			this.userLv.Size = new global::System.Drawing.Size(418, 338);
			this.userLv.TabIndex = 0;
			this.userLv.UseCompatibleStateImageBehavior = false;
			this.userLv.View = global::System.Windows.Forms.View.Details;
			this.columnHeader1.Text = "№";
			this.columnHeader1.Width = 41;
			this.columnHeader2.Text = "Логин";
			this.columnHeader2.Width = 97;
			this.columnHeader3.Text = "Пароль";
			this.columnHeader3.Width = 164;
			this.columnHeader4.Text = "Статус";
			this.columnHeader4.Width = 91;
			this.userMenu.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.активироватьToolStripMenuItem,
				this.деактивироватьToolStripMenuItem,
				this.модулиToolStripMenuItem,
				this.изменитьДанныеToolStripMenuItem
			});
			this.userMenu.Name = "userMenu";
			this.userMenu.Size = new global::System.Drawing.Size(173, 92);
			this.активироватьToolStripMenuItem.Name = "активироватьToolStripMenuItem";
			this.активироватьToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.активироватьToolStripMenuItem.Text = "Активировать";
			this.активироватьToolStripMenuItem.Click += new global::System.EventHandler(this.активироватьToolStripMenuItem_Click);
			this.деактивироватьToolStripMenuItem.Name = "деактивироватьToolStripMenuItem";
			this.деактивироватьToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.деактивироватьToolStripMenuItem.Text = "Деактивировать";
			this.деактивироватьToolStripMenuItem.Click += new global::System.EventHandler(this.деактивироватьToolStripMenuItem_Click);
			this.модулиToolStripMenuItem.Name = "модулиToolStripMenuItem";
			this.модулиToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.модулиToolStripMenuItem.Text = "Модули";
			this.модулиToolStripMenuItem.Click += new global::System.EventHandler(this.модулиToolStripMenuItem_Click);
			this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
			this.изменитьДанныеToolStripMenuItem.Size = new global::System.Drawing.Size(172, 22);
			this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
			this.изменитьДанныеToolStripMenuItem.Click += new global::System.EventHandler(this.изменитьДанныеToolStripMenuItem_Click);
			this.button1.Location = new global::System.Drawing.Point(164, 356);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Обновить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(442, 383);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.userLv);
			base.Name = "UserEdit";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Редактирование юзеров";
			this.userMenu.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400000B RID: 11
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.ListView userLv;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.ColumnHeader columnHeader1;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.ColumnHeader columnHeader2;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.ColumnHeader columnHeader3;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.ColumnHeader columnHeader4;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.ContextMenuStrip userMenu;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.ToolStripMenuItem активироватьToolStripMenuItem;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.ToolStripMenuItem деактивироватьToolStripMenuItem;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.ToolStripMenuItem модулиToolStripMenuItem;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem;
	}
}
