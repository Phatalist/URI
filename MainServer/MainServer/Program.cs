using System;
using System.Windows.Forms;

namespace MainServer
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000029F7 File Offset: 0x000029F7
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainFrm());
		}
	}
}
