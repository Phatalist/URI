using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainServer.Classes
{
	// Token: 0x02000011 RID: 17
	[DataContract(Namespace = "BuildSettings")]
	public class BuildSettings
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00005801 File Offset: 0x00005801
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00005809 File Offset: 0x00005809
		[DataMember]
		public Dictionary<string, string> Wallets { get; set; } = new Dictionary<string, string>();

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00005812 File Offset: 0x00005812
		// (set) Token: 0x0600007B RID: 123 RVA: 0x0000581A File Offset: 0x0000581A
		[DataMember]
		public byte[] Icon { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00005823 File Offset: 0x00005823
		// (set) Token: 0x0600007D RID: 125 RVA: 0x0000582B File Offset: 0x0000582B
		[DataMember]
		public string IPSERVER { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00005834 File Offset: 0x00005834
		// (set) Token: 0x0600007F RID: 127 RVA: 0x0000583C File Offset: 0x0000583C
		[DataMember]
		public string ID { get; set; }
	}
}
