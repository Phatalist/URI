using System;
using System.Linq;

namespace Decrypt
{
	// Token: 0x02000036 RID: 54
	public class Asn1Der
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00006E40 File Offset: 0x00005040
		public Asn1DerObject Parse(byte[] dataToParse)
		{
			Asn1DerObject asn1DerObject = new Asn1DerObject();
			int i = 0;
			while (i < dataToParse.Length)
			{
				Asn1Der.Type type = (Asn1Der.Type)dataToParse[i];
				switch (type)
				{
				case Asn1Der.Type.Integer:
				{
					asn1DerObject.objects.Add(new Asn1DerObject
					{
						Type = Asn1Der.Type.Integer,
						Lenght = (int)dataToParse[i + 1]
					});
					byte[] array = new byte[(int)dataToParse[i + 1]];
					int length = (i + 2 + (int)dataToParse[i + 1] > dataToParse.Length) ? (dataToParse.Length - (i + 2)) : ((int)dataToParse[i + 1]);
					Array.Copy(dataToParse.ToArray<byte>(), i + 2, array, 0, length);
					asn1DerObject.objects.Last<Asn1DerObject>().Data = array;
					i = i + 1 + asn1DerObject.objects.Last<Asn1DerObject>().Lenght;
					break;
				}
				case Asn1Der.Type.BitString:
				case Asn1Der.Type.Null:
					break;
				case Asn1Der.Type.OctetString:
				{
					asn1DerObject.objects.Add(new Asn1DerObject
					{
						Type = Asn1Der.Type.OctetString,
						Lenght = (int)dataToParse[i + 1]
					});
					byte[] array = new byte[(int)dataToParse[i + 1]];
					int length = (i + 2 + (int)dataToParse[i + 1] > dataToParse.Length) ? (dataToParse.Length - (i + 2)) : ((int)dataToParse[i + 1]);
					Array.Copy(dataToParse.ToArray<byte>(), i + 2, array, 0, length);
					asn1DerObject.objects.Last<Asn1DerObject>().Data = array;
					i = i + 1 + asn1DerObject.objects.Last<Asn1DerObject>().Lenght;
					break;
				}
				case Asn1Der.Type.ObjectIdentifier:
				{
					asn1DerObject.objects.Add(new Asn1DerObject
					{
						Type = Asn1Der.Type.ObjectIdentifier,
						Lenght = (int)dataToParse[i + 1]
					});
					byte[] array = new byte[(int)dataToParse[i + 1]];
					int length = (i + 2 + (int)dataToParse[i + 1] > dataToParse.Length) ? (dataToParse.Length - (i + 2)) : ((int)dataToParse[i + 1]);
					Array.Copy(dataToParse.ToArray<byte>(), i + 2, array, 0, length);
					asn1DerObject.objects.Last<Asn1DerObject>().Data = array;
					i = i + 1 + asn1DerObject.objects.Last<Asn1DerObject>().Lenght;
					break;
				}
				default:
					if (type == Asn1Der.Type.Sequence)
					{
						bool flag = asn1DerObject.Lenght == 0;
						byte[] array;
						if (flag)
						{
							asn1DerObject.Type = Asn1Der.Type.Sequence;
							asn1DerObject.Lenght = dataToParse.Length - (i + 2);
							array = new byte[asn1DerObject.Lenght];
						}
						else
						{
							asn1DerObject.objects.Add(new Asn1DerObject
							{
								Type = Asn1Der.Type.Sequence,
								Lenght = (int)dataToParse[i + 1]
							});
							array = new byte[(int)dataToParse[i + 1]];
						}
						int num = (array.Length > dataToParse.Length - (i + 2)) ? (dataToParse.Length - (i + 2)) : array.Length;
						Array.Copy(dataToParse, i + 2, array, 0, array.Length);
						asn1DerObject.objects.Add(this.Parse(array));
						i = i + 1 + (int)dataToParse[i + 1];
					}
					break;
				}
				IL_293:
				i++;
				continue;
				goto IL_293;
			}
			return asn1DerObject;
		}

		// Token: 0x02000037 RID: 55
		public enum Type
		{
			// Token: 0x040000A3 RID: 163
			Sequence = 48,
			// Token: 0x040000A4 RID: 164
			Integer = 2,
			// Token: 0x040000A5 RID: 165
			BitString,
			// Token: 0x040000A6 RID: 166
			OctetString,
			// Token: 0x040000A7 RID: 167
			Null,
			// Token: 0x040000A8 RID: 168
			ObjectIdentifier
		}
	}
}
