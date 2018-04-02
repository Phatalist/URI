using System;
using System.Runtime.Serialization;

namespace MainModule.Classes
{
	// Token: 0x02000049 RID: 73
	[DataContract(Namespace = "BrowserCookie")]
	public class BrowserCookie
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x000089A1 File Offset: 0x00006BA1
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x000089A9 File Offset: 0x00006BA9
		[DataMember]
		public string Browser { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x000089B2 File Offset: 0x00006BB2
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x000089BA File Offset: 0x00006BBA
		[DataMember]
		public string FileName { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x000089C3 File Offset: 0x00006BC3
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x000089CB File Offset: 0x00006BCB
		[DataMember]
		public byte[] FileArray { get; set; }
	}
}
