using System;
using System.Xml.Serialization;

namespace Dodjins
{
	// Token: 0x02000030 RID: 48
	[XmlRoot(ElementName = "Server")]
	public class Server
	{
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00006BEA File Offset: 0x00004DEA
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00006BF2 File Offset: 0x00004DF2
		[XmlElement(ElementName = "Host")]
		public string Host { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00006BFB File Offset: 0x00004DFB
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00006C03 File Offset: 0x00004E03
		[XmlElement(ElementName = "Port")]
		public string Port { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00006C0C File Offset: 0x00004E0C
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00006C14 File Offset: 0x00004E14
		[XmlElement(ElementName = "Protocol")]
		public string Protocol { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00006C1D File Offset: 0x00004E1D
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00006C25 File Offset: 0x00004E25
		[XmlElement(ElementName = "Type")]
		public string Type { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00006C2E File Offset: 0x00004E2E
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00006C36 File Offset: 0x00004E36
		[XmlElement(ElementName = "User")]
		public string User { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00006C3F File Offset: 0x00004E3F
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00006C47 File Offset: 0x00004E47
		[XmlElement(ElementName = "Pass")]
		public Pass Pass { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00006C50 File Offset: 0x00004E50
		// (set) Token: 0x06000105 RID: 261 RVA: 0x00006C58 File Offset: 0x00004E58
		[XmlElement(ElementName = "Logontype")]
		public string Logontype { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00006C61 File Offset: 0x00004E61
		// (set) Token: 0x06000107 RID: 263 RVA: 0x00006C69 File Offset: 0x00004E69
		[XmlElement(ElementName = "TimezoneOffset")]
		public string TimezoneOffset { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00006C72 File Offset: 0x00004E72
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00006C7A File Offset: 0x00004E7A
		[XmlElement(ElementName = "PasvMode")]
		public string PasvMode { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00006C83 File Offset: 0x00004E83
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00006C8B File Offset: 0x00004E8B
		[XmlElement(ElementName = "MaximumMultipleConnections")]
		public string MaximumMultipleConnections { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00006C94 File Offset: 0x00004E94
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00006C9C File Offset: 0x00004E9C
		[XmlElement(ElementName = "EncodingType")]
		public string EncodingType { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00006CA5 File Offset: 0x00004EA5
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00006CAD File Offset: 0x00004EAD
		[XmlElement(ElementName = "BypassProxy")]
		public string BypassProxy { get; set; }
	}
}
