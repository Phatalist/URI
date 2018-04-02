using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x0200004F RID: 79
	[DataContract(Namespace = "UserLog")]
	public class UserLog
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00008B4A File Offset: 0x00006D4A
		// (set) Token: 0x060001DC RID: 476 RVA: 0x00008B52 File Offset: 0x00006D52
		[DataMember]
		public DateTime Time { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00008B5B File Offset: 0x00006D5B
		// (set) Token: 0x060001DE RID: 478 RVA: 0x00008B63 File Offset: 0x00006D63
		[DataMember]
		public string UserName { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00008B6C File Offset: 0x00006D6C
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00008B74 File Offset: 0x00006D74
		[DataMember]
		public List<PasswordContainer> ListOfLogs { get; set; }
	}
}
