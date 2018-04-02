using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dodjins
{
	// Token: 0x02000031 RID: 49
	[XmlRoot(ElementName = "RecentServers")]
	public class RecentServers
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00006CB6 File Offset: 0x00004EB6
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00006CBE File Offset: 0x00004EBE
		[XmlElement(ElementName = "Server")]
		public List<Server> Server { get; set; }
	}
}
