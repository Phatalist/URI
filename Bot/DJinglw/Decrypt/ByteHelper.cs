using System;
using System.Globalization;

namespace Decrypt
{
	// Token: 0x0200003A RID: 58
	public static class ByteHelper
	{
		// Token: 0x0600013E RID: 318 RVA: 0x000076BC File Offset: 0x000058BC
		public static byte[] ConvertHexStringToByteArray(string hexString)
		{
			bool flag = hexString.Length % 2 != 0;
			if (flag)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", new object[]
				{
					hexString
				}));
			}
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				string s = hexString.Substring(i * 2, 2);
				array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return array;
		}
	}
}
