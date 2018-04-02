using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x0200004C RID: 76
	[DataContract(Namespace = "PasswordContainer")]
	public class PasswordContainer
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00008A6D File Offset: 0x00006C6D
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00008A75 File Offset: 0x00006C75
		[DataMember]
		public string Name { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00008A7E File Offset: 0x00006C7E
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x00008A86 File Offset: 0x00006C86
		[DataMember]
		public List<Log> ListOfLogs { get; set; }
	}
}
