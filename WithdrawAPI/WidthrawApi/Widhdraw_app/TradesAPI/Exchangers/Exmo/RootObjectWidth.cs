using System;

namespace Widhdraw_app.TradesAPI.Exchangers.Exmo
{
	// Token: 0x02000023 RID: 35
	public class RootObjectWidth
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00006A3B File Offset: 0x00004C3B
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00006A43 File Offset: 0x00004C43
		public bool result { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00006A4C File Offset: 0x00004C4C
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00006A54 File Offset: 0x00004C54
		public string error { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00006A5D File Offset: 0x00004C5D
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00006A65 File Offset: 0x00004C65
		public string task_id { get; set; }
	}
}
