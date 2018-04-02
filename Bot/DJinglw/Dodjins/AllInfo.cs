using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MainModule.Classes;

namespace Dodjins
{
	// Token: 0x0200001B RID: 27
	[DataContract(Namespace = "AllInfo")]
	public class AllInfo
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000092 RID: 146 RVA: 0x0000425E File Offset: 0x0000245E
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00004266 File Offset: 0x00002466
		[DataMember]
		public List<TextFile> TextFiles { get; set; } = new List<TextFile>();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000094 RID: 148 RVA: 0x0000426F File Offset: 0x0000246F
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00004277 File Offset: 0x00002477
		[DataMember]
		public List<BrowserCookie> Cookies { get; set; } = new List<BrowserCookie>();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00004280 File Offset: 0x00002480
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00004288 File Offset: 0x00002488
		[DataMember]
		public List<BitcoinWallet> Wallets { get; set; } = new List<BitcoinWallet>();

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00004291 File Offset: 0x00002491
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00004299 File Offset: 0x00002499
		[DataMember]
		public UserLog Log { get; set; } = new UserLog();
	}
}
