using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decrypt
{
	// Token: 0x02000039 RID: 57
	public class BerkeleyDB
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00007348 File Offset: 0x00005548
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00007350 File Offset: 0x00005550
		public string Version { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00007359 File Offset: 0x00005559
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00007361 File Offset: 0x00005561
		public List<KeyValuePair<string, string>> Keys { get; private set; }

		// Token: 0x0600013B RID: 315 RVA: 0x0000736C File Offset: 0x0000556C
		public BerkeleyDB(string FileName)
		{
			List<byte> list = new List<byte>();
			this.Keys = new List<KeyValuePair<string, string>>();
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(FileName)))
			{
				int i = 0;
				int num = (int)binaryReader.BaseStream.Length;
				while (i < num)
				{
					list.Add(binaryReader.ReadByte());
					i++;
				}
			}
			string text = BitConverter.ToString(this.Extract(list.ToArray(), 0, 4, false)).Replace("-", "");
			string text2 = BitConverter.ToString(this.Extract(list.ToArray(), 4, 4, false)).Replace("-", "");
			int num2 = BitConverter.ToInt32(this.Extract(list.ToArray(), 12, 4, true), 0);
			bool flag = text.Equals("00061561");
			if (flag)
			{
				this.Version = "Berkelet DB";
				bool flag2 = text2.Equals("00000002");
				if (flag2)
				{
					this.Version += " 1.85 (Hash, version 2, native byte-order)";
				}
				int num3 = int.Parse(BitConverter.ToString(this.Extract(list.ToArray(), 56, 4, false)).Replace("-", ""));
				int num4 = 1;
				while (this.Keys.Count < num3)
				{
					string[] array = new string[(num3 - this.Keys.Count) * 2];
					for (int j = 0; j < (num3 - this.Keys.Count) * 2; j++)
					{
						array[j] = BitConverter.ToString(this.Extract(list.ToArray(), num2 * num4 + 2 + j * 2, 2, true)).Replace("-", "");
					}
					Array.Sort<string>(array);
					for (int k = 0; k < array.Length; k += 2)
					{
						int num5 = Convert.ToInt32(array[k], 16) + num2 * num4;
						int num6 = Convert.ToInt32(array[k + 1], 16) + num2 * num4;
						int num7 = (k + 2 >= array.Length) ? (num2 + num2 * num4) : (Convert.ToInt32(array[k + 2], 16) + num2 * num4);
						string @string = Encoding.ASCII.GetString(this.Extract(list.ToArray(), num6, num7 - num6, false));
						string value = BitConverter.ToString(this.Extract(list.ToArray(), num5, num6 - num5, false));
						bool flag3 = !string.IsNullOrWhiteSpace(@string);
						if (flag3)
						{
							this.Keys.Add(new KeyValuePair<string, string>(@string, value));
						}
					}
					num4++;
				}
			}
			else
			{
				this.Version = "Unknow database format";
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00007650 File Offset: 0x00005850
		private byte[] Extract(byte[] source, int start, int length, bool littleEndian)
		{
			byte[] array = new byte[length];
			int num = 0;
			for (int i = start; i < start + length; i++)
			{
				array[num] = source[i];
				num++;
			}
			if (littleEndian)
			{
				Array.Reverse(array);
			}
			return array;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000076A0 File Offset: 0x000058A0
		private byte[] ConvertToLittleEndian(byte[] source)
		{
			Array.Reverse(source);
			return source;
		}
	}
}
