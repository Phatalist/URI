using System;
using System.Runtime.CompilerServices;

namespace Widhdraw_app.TradesAPI.Exchangers.Cryptopia
{
	// Token: 0x02000028 RID: 40
	public class RootObjectWidthdraw
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006EF2 File Offset: 0x000050F2
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00006EFA File Offset: 0x000050FA
		public bool Success { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00006F03 File Offset: 0x00005103
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00006F0B File Offset: 0x0000510B
		public string Error { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00006F14 File Offset: 0x00005114
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00006F1C File Offset: 0x0000511C
		[Dynamic]
		public dynamic Data { [return: Dynamic] get; [param: Dynamic] set; }
	}
}
