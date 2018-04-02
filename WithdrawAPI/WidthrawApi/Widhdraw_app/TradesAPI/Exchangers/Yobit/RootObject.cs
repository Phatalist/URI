using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Yobit
{
	// Token: 0x02000017 RID: 23
	public class RootObject
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00006167 File Offset: 0x00004367
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x0000616F File Offset: 0x0000436F
		public int success { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00006178 File Offset: 0x00004378
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00006180 File Offset: 0x00004380
		public Return @return { get; set; }
	}
}
