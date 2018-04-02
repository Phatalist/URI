using System;
using System.Xml.Serialization;

namespace Dodjins
{
	// Token: 0x0200002F RID: 47
	[XmlRoot(ElementName = "Pass")]
	public class Pass
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00006BC8 File Offset: 0x00004DC8
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x00006BD0 File Offset: 0x00004DD0
		[XmlAttribute(AttributeName = "encoding")]
		public string Encoding { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00006BD9 File Offset: 0x00004DD9
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00006BE1 File Offset: 0x00004DE1
		[XmlText]
		public string Text { get; set; }
	}
}
