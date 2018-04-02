using System;
using System.Runtime.Serialization;

namespace Dodjins
{
	// Token: 0x02000033 RID: 51
	[DataContract(Namespace = "AvaliableTask")]
	public class AvaliableTask
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00006CFA File Offset: 0x00004EFA
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00006D02 File Offset: 0x00004F02
		[DataMember]
		public int ID { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00006D0B File Offset: 0x00004F0B
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00006D13 File Offset: 0x00004F13
		[DataMember]
		public string Action { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00006D1C File Offset: 0x00004F1C
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00006D24 File Offset: 0x00004F24
		[DataMember]
		public string Target { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00006D2D File Offset: 0x00004F2D
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00006D35 File Offset: 0x00004F35
		[DataMember]
		public bool ExecuteSilient { get; set; }
	}
}
