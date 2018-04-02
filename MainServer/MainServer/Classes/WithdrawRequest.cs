using System;
using System.Runtime.Serialization;

namespace MainServer.Classes
{
	// Token: 0x02000010 RID: 16
	[DataContract(Namespace = "WithdrawRequest")]
	public class WithdrawRequest
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000057BD File Offset: 0x000057BD
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000057C5 File Offset: 0x000057C5
		[DataMember]
		public decimal amount { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000057CE File Offset: 0x000057CE
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000057D6 File Offset: 0x000057D6
		[DataMember]
		public string currency { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000057DF File Offset: 0x000057DF
		// (set) Token: 0x06000074 RID: 116 RVA: 0x000057E7 File Offset: 0x000057E7
		[DataMember]
		public string adress { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000057F0 File Offset: 0x000057F0
		// (set) Token: 0x06000076 RID: 118 RVA: 0x000057F8 File Offset: 0x000057F8
		[DataMember]
		public string paymentid { get; set; }
	}
}
