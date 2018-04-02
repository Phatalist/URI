using System;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x0200004D RID: 77
	[DataContract(Namespace = "ProcessInfo")]
	public class ProcessInfo
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00008A8F File Offset: 0x00006C8F
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x00008A97 File Offset: 0x00006C97
		[DataMember]
		public int ID { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00008AA0 File Offset: 0x00006CA0
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x00008AA8 File Offset: 0x00006CA8
		[DataMember]
		public string Name { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00008AB1 File Offset: 0x00006CB1
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00008AB9 File Offset: 0x00006CB9
		[DataMember]
		public string Path { get; set; }
	}
}
