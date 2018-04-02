using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Yobit
{
	// Token: 0x02000015 RID: 21
	public class Rights
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x000060CE File Offset: 0x000042CE
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000060D6 File Offset: 0x000042D6
		public int info { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000060DF File Offset: 0x000042DF
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000060E7 File Offset: 0x000042E7
		public int trade { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x000060F0 File Offset: 0x000042F0
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x000060F8 File Offset: 0x000042F8
		public int withdraw { get; set; }
	}
}
