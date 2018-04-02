using System;
using System.Windows.Forms;

namespace Widhdraw_app
{
	// Token: 0x0200000F RID: 15
	internal static class Program
	{
		// Token: 0x0600009C RID: 156 RVA: 0x00005A40 File Offset: 0x00003C40
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainFrm());
		}
	}
}
