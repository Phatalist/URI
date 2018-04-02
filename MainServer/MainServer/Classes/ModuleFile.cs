using System;
using System.Runtime.Serialization;

namespace MainServer.Classes
{
	// Token: 0x02000012 RID: 18
	[DataContract(Namespace = "ModuleFile")]
	public class ModuleFile
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00005859 File Offset: 0x00005859
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00005861 File Offset: 0x00005861
		[DataMember]
		public string FileName { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000586A File Offset: 0x0000586A
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00005872 File Offset: 0x00005872
		[DataMember]
		public string FilePath { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000085 RID: 133 RVA: 0x0000587B File Offset: 0x0000587B
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00005883 File Offset: 0x00005883
		[DataMember]
		public string FileURL { get; set; }
	}
}
