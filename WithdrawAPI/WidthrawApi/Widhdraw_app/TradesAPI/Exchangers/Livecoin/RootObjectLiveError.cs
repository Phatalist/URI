using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Livecoin
{
	// Token: 0x0200002F RID: 47
	public class RootObjectLiveError
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00007516 File Offset: 0x00005716
		// (set) Token: 0x0600018D RID: 397 RVA: 0x0000751E File Offset: 0x0000571E
		public int errorCode { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00007527 File Offset: 0x00005727
		// (set) Token: 0x0600018F RID: 399 RVA: 0x0000752F File Offset: 0x0000572F
		public string errorMessage { get; set; }
	}
}
