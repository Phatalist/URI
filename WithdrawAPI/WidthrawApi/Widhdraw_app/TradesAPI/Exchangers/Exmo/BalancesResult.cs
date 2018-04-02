using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Exmo
{
	// Token: 0x02000022 RID: 34
	public class BalancesResult
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000132 RID: 306 RVA: 0x000069F7 File Offset: 0x00004BF7
		// (set) Token: 0x06000133 RID: 307 RVA: 0x000069FF File Offset: 0x00004BFF
		public int uid { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00006A08 File Offset: 0x00004C08
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00006A10 File Offset: 0x00004C10
		public int server_date { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00006A19 File Offset: 0x00004C19
		// (set) Token: 0x06000137 RID: 311 RVA: 0x00006A21 File Offset: 0x00004C21
		public Balances balances { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00006A2A File Offset: 0x00004C2A
		// (set) Token: 0x06000139 RID: 313 RVA: 0x00006A32 File Offset: 0x00004C32
		public Reserved reserved { get; set; }
	}
}
