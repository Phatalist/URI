using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Livecoin
{
	// Token: 0x0200002E RID: 46
	public class RootObjectLiveCoin
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000185 RID: 389 RVA: 0x000074E3 File Offset: 0x000056E3
		// (set) Token: 0x06000186 RID: 390 RVA: 0x000074EB File Offset: 0x000056EB
		public string type { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000187 RID: 391 RVA: 0x000074F4 File Offset: 0x000056F4
		// (set) Token: 0x06000188 RID: 392 RVA: 0x000074FC File Offset: 0x000056FC
		public string currency { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00007505 File Offset: 0x00005705
		// (set) Token: 0x0600018A RID: 394 RVA: 0x0000750D File Offset: 0x0000570D
		public double value { get; set; }
	}
}
