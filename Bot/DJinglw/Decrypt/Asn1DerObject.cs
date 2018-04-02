using System;
using System.Collections.Generic;
using System.Text;

namespace Decrypt
{
	// Token: 0x02000038 RID: 56
	public class Asn1DerObject
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600012D RID: 301 RVA: 0x000070FB File Offset: 0x000052FB
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00007103 File Offset: 0x00005303
		public Asn1Der.Type Type { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600012F RID: 303 RVA: 0x0000710C File Offset: 0x0000530C
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00007114 File Offset: 0x00005314
		public int Lenght { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000131 RID: 305 RVA: 0x0000711D File Offset: 0x0000531D
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00007125 File Offset: 0x00005325
		public List<Asn1DerObject> objects { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000133 RID: 307 RVA: 0x0000712E File Offset: 0x0000532E
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00007136 File Offset: 0x00005336
		public byte[] Data { get; set; }

		// Token: 0x06000135 RID: 309 RVA: 0x0000713F File Offset: 0x0000533F
		public Asn1DerObject()
		{
			this.objects = new List<Asn1DerObject>();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00007158 File Offset: 0x00005358
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			Asn1Der.Type type = this.Type;
			switch (type)
			{
			case Asn1Der.Type.Integer:
				foreach (byte b in this.Data)
				{
					stringBuilder2.AppendFormat("{0:X2}", b);
				}
				stringBuilder.AppendLine("\tINTEGER " + stringBuilder2);
				stringBuilder2.Clear();
				break;
			case Asn1Der.Type.BitString:
			case Asn1Der.Type.Null:
				break;
			case Asn1Der.Type.OctetString:
				foreach (byte b2 in this.Data)
				{
					stringBuilder2.AppendFormat("{0:X2}", b2);
				}
				stringBuilder.AppendLine("\tOCTETSTRING " + stringBuilder2.ToString());
				stringBuilder2.Clear();
				break;
			case Asn1Der.Type.ObjectIdentifier:
				foreach (byte b3 in this.Data)
				{
					stringBuilder2.AppendFormat("{0:X2}", b3);
				}
				stringBuilder.AppendLine("\tOBJECTIDENTIFIER " + stringBuilder2.ToString());
				stringBuilder2.Clear();
				break;
			default:
				if (type == Asn1Der.Type.Sequence)
				{
					stringBuilder.AppendLine("SEQUENCE {");
				}
				break;
			}
			foreach (Asn1DerObject asn1DerObject in this.objects)
			{
				stringBuilder.Append(asn1DerObject.ToString());
			}
			bool flag = this.Type.Equals(Asn1Der.Type.Sequence);
			if (flag)
			{
				stringBuilder.AppendLine("}");
			}
			return stringBuilder.ToString();
		}
	}
}
