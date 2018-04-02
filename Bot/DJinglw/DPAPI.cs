using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x02000002 RID: 2
public class DPAPI
{
	// Token: 0x06000002 RID: 2
	[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool CryptProtectData(ref DPAPI.DATA_BLOB pPlainText, string szDescription, ref DPAPI.DATA_BLOB pEntropy, IntPtr pReserved, ref DPAPI.CRYPTPROTECT_PROMPTSTRUCT pPrompt, int dwFlags, ref DPAPI.DATA_BLOB pCipherText);

	// Token: 0x06000003 RID: 3
	[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool CryptUnprotectData(ref DPAPI.DATA_BLOB pCipherText, ref string pszDescription, ref DPAPI.DATA_BLOB pEntropy, IntPtr pReserved, ref DPAPI.CRYPTPROTECT_PROMPTSTRUCT pPrompt, int dwFlags, ref DPAPI.DATA_BLOB pPlainText);

	// Token: 0x06000004 RID: 4 RVA: 0x00002057 File Offset: 0x00000257
	private static void InitPrompt(ref DPAPI.CRYPTPROTECT_PROMPTSTRUCT ps)
	{
		ps.cbSize = Marshal.SizeOf(typeof(DPAPI.CRYPTPROTECT_PROMPTSTRUCT));
		ps.dwPromptFlags = 0;
		ps.hwndApp = DPAPI.NullPtr;
		ps.szPrompt = null;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002088 File Offset: 0x00000288
	private static void InitBLOB(byte[] data, ref DPAPI.DATA_BLOB blob)
	{
		bool flag = data == null;
		if (flag)
		{
			data = new byte[0];
		}
		blob.pbData = Marshal.AllocHGlobal(data.Length);
		bool flag2 = blob.pbData == IntPtr.Zero;
		if (flag2)
		{
			throw new Exception("Unable to allocate data buffer for BLOB structure.");
		}
		blob.cbData = data.Length;
		Marshal.Copy(data, 0, blob.pbData, data.Length);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000020F0 File Offset: 0x000002F0
	public static string Encrypt(string plainText)
	{
		return DPAPI.Encrypt(DPAPI.defaultKeyType, plainText, string.Empty, string.Empty);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002118 File Offset: 0x00000318
	public static string Encrypt(DPAPI.KeyType keyType, string plainText)
	{
		return DPAPI.Encrypt(keyType, plainText, string.Empty, string.Empty);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000213C File Offset: 0x0000033C
	public static string Encrypt(DPAPI.KeyType keyType, string plainText, string entropy)
	{
		return DPAPI.Encrypt(keyType, plainText, entropy, string.Empty);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000215C File Offset: 0x0000035C
	public static string Encrypt(DPAPI.KeyType keyType, string plainText, string entropy, string description)
	{
		bool flag = plainText == null;
		if (flag)
		{
			plainText = string.Empty;
		}
		bool flag2 = entropy == null;
		if (flag2)
		{
			entropy = string.Empty;
		}
		return Convert.ToBase64String(DPAPI.Encrypt(keyType, Encoding.UTF8.GetBytes(plainText), Encoding.UTF8.GetBytes(entropy), description));
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000021B0 File Offset: 0x000003B0
	public static byte[] Encrypt(DPAPI.KeyType keyType, byte[] plainTextBytes, byte[] entropyBytes, string description)
	{
		bool flag = plainTextBytes == null;
		if (flag)
		{
			plainTextBytes = new byte[0];
		}
		bool flag2 = entropyBytes == null;
		if (flag2)
		{
			entropyBytes = new byte[0];
		}
		bool flag3 = description == null;
		if (flag3)
		{
			description = string.Empty;
		}
		DPAPI.DATA_BLOB data_BLOB = default(DPAPI.DATA_BLOB);
		DPAPI.DATA_BLOB data_BLOB2 = default(DPAPI.DATA_BLOB);
		DPAPI.DATA_BLOB data_BLOB3 = default(DPAPI.DATA_BLOB);
		DPAPI.CRYPTPROTECT_PROMPTSTRUCT cryptprotect_PROMPTSTRUCT = default(DPAPI.CRYPTPROTECT_PROMPTSTRUCT);
		DPAPI.InitPrompt(ref cryptprotect_PROMPTSTRUCT);
		byte[] result;
		try
		{
			try
			{
				DPAPI.InitBLOB(plainTextBytes, ref data_BLOB);
			}
			catch (Exception innerException)
			{
				throw new Exception("Cannot initialize plaintext BLOB.", innerException);
			}
			try
			{
				DPAPI.InitBLOB(entropyBytes, ref data_BLOB3);
			}
			catch (Exception innerException2)
			{
				throw new Exception("Cannot initialize entropy BLOB.", innerException2);
			}
			int num = 1;
			bool flag4 = keyType == DPAPI.KeyType.MachineKey;
			if (flag4)
			{
				num |= 4;
			}
			bool flag5 = DPAPI.CryptProtectData(ref data_BLOB, description, ref data_BLOB3, IntPtr.Zero, ref cryptprotect_PROMPTSTRUCT, num, ref data_BLOB2);
			bool flag6 = !flag5;
			if (flag6)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				throw new Exception("CryptProtectData failed.", new Win32Exception(lastWin32Error));
			}
			byte[] array = new byte[data_BLOB2.cbData];
			Marshal.Copy(data_BLOB2.pbData, array, 0, data_BLOB2.cbData);
			result = array;
		}
		catch (Exception innerException3)
		{
			throw new Exception("DPAPI was unable to encrypt data.", innerException3);
		}
		finally
		{
			bool flag7 = data_BLOB.pbData != IntPtr.Zero;
			if (flag7)
			{
				Marshal.FreeHGlobal(data_BLOB.pbData);
			}
			bool flag8 = data_BLOB2.pbData != IntPtr.Zero;
			if (flag8)
			{
				Marshal.FreeHGlobal(data_BLOB2.pbData);
			}
			bool flag9 = data_BLOB3.pbData != IntPtr.Zero;
			if (flag9)
			{
				Marshal.FreeHGlobal(data_BLOB3.pbData);
			}
		}
		return result;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002380 File Offset: 0x00000580
	public static string Decrypt(string cipherText)
	{
		string text;
		return DPAPI.Decrypt(cipherText, string.Empty, out text);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000023A0 File Offset: 0x000005A0
	public static string Decrypt(string cipherText, out string description)
	{
		return DPAPI.Decrypt(cipherText, string.Empty, out description);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000023C0 File Offset: 0x000005C0
	public static string Decrypt(string cipherText, string entropy, out string description)
	{
		bool flag = entropy == null;
		if (flag)
		{
			entropy = string.Empty;
		}
		return Encoding.UTF8.GetString(DPAPI.Decrypt(Convert.FromBase64String(cipherText), Encoding.UTF8.GetBytes(entropy), out description));
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002404 File Offset: 0x00000604
	public static byte[] Decrypt(byte[] cipherTextBytes, byte[] entropyBytes, out string description)
	{
		DPAPI.DATA_BLOB data_BLOB = default(DPAPI.DATA_BLOB);
		DPAPI.DATA_BLOB data_BLOB2 = default(DPAPI.DATA_BLOB);
		DPAPI.DATA_BLOB data_BLOB3 = default(DPAPI.DATA_BLOB);
		DPAPI.CRYPTPROTECT_PROMPTSTRUCT cryptprotect_PROMPTSTRUCT = default(DPAPI.CRYPTPROTECT_PROMPTSTRUCT);
		DPAPI.InitPrompt(ref cryptprotect_PROMPTSTRUCT);
		description = string.Empty;
		byte[] result;
		try
		{
			try
			{
				DPAPI.InitBLOB(cipherTextBytes, ref data_BLOB2);
			}
			catch (Exception innerException)
			{
				throw new Exception("Cannot initialize ciphertext BLOB.", innerException);
			}
			try
			{
				DPAPI.InitBLOB(entropyBytes, ref data_BLOB3);
			}
			catch (Exception innerException2)
			{
				throw new Exception("Cannot initialize entropy BLOB.", innerException2);
			}
			int dwFlags = 1;
			bool flag = DPAPI.CryptUnprotectData(ref data_BLOB2, ref description, ref data_BLOB3, IntPtr.Zero, ref cryptprotect_PROMPTSTRUCT, dwFlags, ref data_BLOB);
			bool flag2 = !flag;
			if (flag2)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				throw new Exception("CryptUnprotectData failed.", new Win32Exception(lastWin32Error));
			}
			byte[] array = new byte[data_BLOB.cbData];
			Marshal.Copy(data_BLOB.pbData, array, 0, data_BLOB.cbData);
			result = array;
		}
		catch (Exception innerException3)
		{
			throw new Exception("DPAPI was unable to decrypt data.", innerException3);
		}
		finally
		{
			bool flag3 = data_BLOB.pbData != IntPtr.Zero;
			if (flag3)
			{
				Marshal.FreeHGlobal(data_BLOB.pbData);
			}
			bool flag4 = data_BLOB2.pbData != IntPtr.Zero;
			if (flag4)
			{
				Marshal.FreeHGlobal(data_BLOB2.pbData);
			}
			bool flag5 = data_BLOB3.pbData != IntPtr.Zero;
			if (flag5)
			{
				Marshal.FreeHGlobal(data_BLOB3.pbData);
			}
		}
		return result;
	}

	// Token: 0x04000001 RID: 1
	private static IntPtr NullPtr = (IntPtr)0;

	// Token: 0x04000002 RID: 2
	private const int CRYPTPROTECT_UI_FORBIDDEN = 1;

	// Token: 0x04000003 RID: 3
	private const int CRYPTPROTECT_LOCAL_MACHINE = 4;

	// Token: 0x04000004 RID: 4
	private static DPAPI.KeyType defaultKeyType = DPAPI.KeyType.UserKey;

	// Token: 0x02000003 RID: 3
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct DATA_BLOB
	{
		// Token: 0x04000005 RID: 5
		public int cbData;

		// Token: 0x04000006 RID: 6
		public IntPtr pbData;
	}

	// Token: 0x02000004 RID: 4
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct CRYPTPROTECT_PROMPTSTRUCT
	{
		// Token: 0x04000007 RID: 7
		public int cbSize;

		// Token: 0x04000008 RID: 8
		public int dwPromptFlags;

		// Token: 0x04000009 RID: 9
		public IntPtr hwndApp;

		// Token: 0x0400000A RID: 10
		public string szPrompt;
	}

	// Token: 0x02000005 RID: 5
	public enum KeyType
	{
		// Token: 0x0400000C RID: 12
		UserKey = 1,
		// Token: 0x0400000D RID: 13
		MachineKey
	}
}
