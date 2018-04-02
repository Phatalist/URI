using System;
using System.Collections.Generic;

namespace Widhdraw_app.TradesAPI.Exchangers.Yobit
{
	// Token: 0x02000016 RID: 22
	public class Return
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00006101 File Offset: 0x00004301
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00006109 File Offset: 0x00004309
		public Dictionary<string, string> funds { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00006112 File Offset: 0x00004312
		// (set) Token: 0x060000BD RID: 189 RVA: 0x0000611A File Offset: 0x0000431A
		public Dictionary<string, string> funds_incl_orders { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00006123 File Offset: 0x00004323
		// (set) Token: 0x060000BF RID: 191 RVA: 0x0000612B File Offset: 0x0000432B
		public Rights rights { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00006134 File Offset: 0x00004334
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x0000613C File Offset: 0x0000433C
		public int transaction_count { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00006145 File Offset: 0x00004345
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x0000614D File Offset: 0x0000434D
		public int open_orders { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00006156 File Offset: 0x00004356
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x0000615E File Offset: 0x0000435E
		public int server_time { get; set; }
	}
}
