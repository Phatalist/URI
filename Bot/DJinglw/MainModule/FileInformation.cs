using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainModule
{
	// Token: 0x02000046 RID: 70
	[DataContract(Namespace = "FileInformation")]
	public class FileInformation
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00008908 File Offset: 0x00006B08
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00008910 File Offset: 0x00006B10
		[DataMember]
		public string FullName { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00008919 File Offset: 0x00006B19
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00008921 File Offset: 0x00006B21
		[DataMember]
		public long Size { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000193 RID: 403 RVA: 0x0000892A File Offset: 0x00006B2A
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00008932 File Offset: 0x00006B32
		[DataMember]
		public DateTime ChangeTime { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000893B File Offset: 0x00006B3B
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00008943 File Offset: 0x00006B43
		[DataMember]
		public string FullPath { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000894C File Offset: 0x00006B4C
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00008954 File Offset: 0x00006B54
		[DataMember]
		public List<string> Attributes { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000895D File Offset: 0x00006B5D
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00008965 File Offset: 0x00006B65
		[DataMember]
		public FileType Type { get; set; }
	}
}
