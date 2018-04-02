using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Cryptopia
{
	// Token: 0x02000026 RID: 38
	public class Datum
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00006E04 File Offset: 0x00005004
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00006E0C File Offset: 0x0000500C
		public int CurrencyId { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00006E15 File Offset: 0x00005015
		// (set) Token: 0x0600014C RID: 332 RVA: 0x00006E1D File Offset: 0x0000501D
		public string Symbol { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00006E26 File Offset: 0x00005026
		// (set) Token: 0x0600014E RID: 334 RVA: 0x00006E2E File Offset: 0x0000502E
		public string Total { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00006E37 File Offset: 0x00005037
		// (set) Token: 0x06000150 RID: 336 RVA: 0x00006E3F File Offset: 0x0000503F
		public string Available { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00006E48 File Offset: 0x00005048
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00006E50 File Offset: 0x00005050
		public string Unconfirmed { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000153 RID: 339 RVA: 0x00006E59 File Offset: 0x00005059
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00006E61 File Offset: 0x00005061
		public string HeldForTrades { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000155 RID: 341 RVA: 0x00006E6A File Offset: 0x0000506A
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00006E72 File Offset: 0x00005072
		public string PendingWithdraw { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00006E7B File Offset: 0x0000507B
		// (set) Token: 0x06000158 RID: 344 RVA: 0x00006E83 File Offset: 0x00005083
		public string Address { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000159 RID: 345 RVA: 0x00006E8C File Offset: 0x0000508C
		// (set) Token: 0x0600015A RID: 346 RVA: 0x00006E94 File Offset: 0x00005094
		public string BaseAddress { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600015B RID: 347 RVA: 0x00006E9D File Offset: 0x0000509D
		// (set) Token: 0x0600015C RID: 348 RVA: 0x00006EA5 File Offset: 0x000050A5
		public string Status { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600015D RID: 349 RVA: 0x00006EAE File Offset: 0x000050AE
		// (set) Token: 0x0600015E RID: 350 RVA: 0x00006EB6 File Offset: 0x000050B6
		public string StatusMessage { get; set; }
	}
}
