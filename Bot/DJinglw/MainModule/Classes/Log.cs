using System;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x0200004A RID: 74
	[DataContract(Namespace = "Log")]
	public class Log
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001AA RID: 426 RVA: 0x000089D4 File Offset: 0x00006BD4
		// (set) Token: 0x060001AB RID: 427 RVA: 0x000089DC File Offset: 0x00006BDC
		[DataMember]
		public string Login { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001AC RID: 428 RVA: 0x000089E5 File Offset: 0x00006BE5
		// (set) Token: 0x060001AD RID: 429 RVA: 0x000089ED File Offset: 0x00006BED
		[DataMember]
		public string Password { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000089F6 File Offset: 0x00006BF6
		// (set) Token: 0x060001AF RID: 431 RVA: 0x000089FE File Offset: 0x00006BFE
		[DataMember]
		public string URL { get; set; }
	}
}
