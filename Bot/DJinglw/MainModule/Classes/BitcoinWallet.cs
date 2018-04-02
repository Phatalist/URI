using System;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x02000048 RID: 72
	[DataContract(Namespace = "BitcoinWallet")]
	public class BitcoinWallet
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600019C RID: 412 RVA: 0x0000896E File Offset: 0x00006B6E
		// (set) Token: 0x0600019D RID: 413 RVA: 0x00008976 File Offset: 0x00006B76
		[DataMember]
		public string WalletName { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600019E RID: 414 RVA: 0x0000897F File Offset: 0x00006B7F
		// (set) Token: 0x0600019F RID: 415 RVA: 0x00008987 File Offset: 0x00006B87
		[DataMember]
		public byte[] WalletArray { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00008990 File Offset: 0x00006B90
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00008998 File Offset: 0x00006B98
		[DataMember]
		public string FileName { get; set; }
	}
}
