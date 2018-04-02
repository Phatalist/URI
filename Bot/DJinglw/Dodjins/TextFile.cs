using System;
using System.Runtime.Serialization;

namespace Dodjins
{
	// Token: 0x0200001C RID: 28
	[DataContract(Namespace = "TextFile")]
	public class TextFile
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000042D7 File Offset: 0x000024D7
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000042DF File Offset: 0x000024DF
		[DataMember]
		public string Name { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000042E8 File Offset: 0x000024E8
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000042F0 File Offset: 0x000024F0
		[DataMember]
		public byte[] Bytes { get; set; }
	}
}
