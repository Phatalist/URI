using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x0200004E RID: 78
	[DataContract(Namespace = "SubInfo")]
	public class SubInfo
	{
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00008AC2 File Offset: 0x00006CC2
		// (set) Token: 0x060001CB RID: 459 RVA: 0x00008ACA File Offset: 0x00006CCA
		[DataMember]
		public string BuildID { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00008AD3 File Offset: 0x00006CD3
		// (set) Token: 0x060001CD RID: 461 RVA: 0x00008ADB File Offset: 0x00006CDB
		[DataMember]
		public string HWID { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00008AE4 File Offset: 0x00006CE4
		// (set) Token: 0x060001CF RID: 463 RVA: 0x00008AEC File Offset: 0x00006CEC
		[DataMember]
		public string IpAdress { get; set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00008AF5 File Offset: 0x00006CF5
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x00008AFD File Offset: 0x00006CFD
		[DataMember]
		public string Country { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00008B06 File Offset: 0x00006D06
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x00008B0E File Offset: 0x00006D0E
		[DataMember]
		public string OS { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00008B17 File Offset: 0x00006D17
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x00008B1F File Offset: 0x00006D1F
		[DataMember]
		public string VideoCard { get; set; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00008B28 File Offset: 0x00006D28
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00008B30 File Offset: 0x00006D30
		[DataMember]
		public string Processor { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00008B39 File Offset: 0x00006D39
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x00008B41 File Offset: 0x00006D41
		[DataMember]
		public List<string> SystemSecurities { get; set; }
	}
}
