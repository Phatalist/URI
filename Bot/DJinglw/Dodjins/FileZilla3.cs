using System;
using System.Xml.Serialization;

namespace Dodjins
{
	// Token: 0x02000032 RID: 50
	[XmlRoot(ElementName = "FileZilla3")]
	public class FileZilla3
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00006CC7 File Offset: 0x00004EC7
		// (set) Token: 0x06000115 RID: 277 RVA: 0x00006CCF File Offset: 0x00004ECF
		[XmlElement(ElementName = "RecentServers")]
		public RecentServers RecentServers { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00006CD8 File Offset: 0x00004ED8
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00006CE0 File Offset: 0x00004EE0
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00006CE9 File Offset: 0x00004EE9
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00006CF1 File Offset: 0x00004EF1
		[XmlAttribute(AttributeName = "platform")]
		public string Platform { get; set; }
	}
}
