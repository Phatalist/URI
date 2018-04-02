using System;
using System.IO;
using System.Security.Cryptography;

namespace Decrypt
{
	// Token: 0x02000043 RID: 67
	public class TripleDESHelper
	{
		// Token: 0x06000185 RID: 389 RVA: 0x000084C0 File Offset: 0x000066C0
		public static string DESCBCDecryptor(byte[] key, byte[] iv, byte[] input)
		{
			string result = null;
			using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider())
			{
				tripleDESCryptoServiceProvider.Key = key;
				tripleDESCryptoServiceProvider.IV = iv;
				tripleDESCryptoServiceProvider.Mode = CipherMode.CBC;
				tripleDESCryptoServiceProvider.Padding = PaddingMode.None;
				ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateDecryptor(tripleDESCryptoServiceProvider.Key, tripleDESCryptoServiceProvider.IV);
				using (MemoryStream memoryStream = new MemoryStream(input))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						using (StreamReader streamReader = new StreamReader(cryptoStream))
						{
							result = streamReader.ReadToEnd();
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000085A8 File Offset: 0x000067A8
		public static byte[] DESCBCDecryptorByte(byte[] key, byte[] iv, byte[] input)
		{
			byte[] array = new byte[512];
			using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider())
			{
				tripleDESCryptoServiceProvider.Key = key;
				tripleDESCryptoServiceProvider.IV = iv;
				tripleDESCryptoServiceProvider.Mode = CipherMode.CBC;
				tripleDESCryptoServiceProvider.Padding = PaddingMode.None;
				ICryptoTransform transform = tripleDESCryptoServiceProvider.CreateDecryptor(tripleDESCryptoServiceProvider.Key, tripleDESCryptoServiceProvider.IV);
				using (MemoryStream memoryStream = new MemoryStream(input))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array, 0, array.Length);
					}
				}
			}
			return array;
		}
	}
}
