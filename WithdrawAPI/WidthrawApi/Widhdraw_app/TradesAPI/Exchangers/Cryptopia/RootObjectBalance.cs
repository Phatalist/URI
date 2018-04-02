using System;
using System.Collections.Generic;

namespace Widhdraw_app.TradesAPI.Exchangers.Cryptopia
{
	// Token: 0x02000027 RID: 39
	public class RootObjectBalance
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00006EBF File Offset: 0x000050BF
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00006EC7 File Offset: 0x000050C7
		public bool Success { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00006ED0 File Offset: 0x000050D0
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00006ED8 File Offset: 0x000050D8
		public object Error { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00006EE1 File Offset: 0x000050E1
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00006EE9 File Offset: 0x000050E9
		public List<Datum> Data { get; set; }
	}
}
