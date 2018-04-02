using System;
using System.Runtime.Serialization;

namespace Omdagerssss
{
	// Token: 0x02000007 RID: 7
	[DataContract(Namespace = "ModuleFile")]
	public class ModuleFile
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002BB4 File Offset: 0x00000DB4
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002BBC File Offset: 0x00000DBC
		[DataMember]
		public string FileName { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002BC5 File Offset: 0x00000DC5
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002BCD File Offset: 0x00000DCD
		[DataMember]
		public string FilePath { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002BD6 File Offset: 0x00000DD6
		// (set) Token: 0x06000029 RID: 41 RVA: 0x00002BDE File Offset: 0x00000DDE
		[DataMember]
		public string FileURL { get; set; }
	}
}
