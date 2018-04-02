using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Dodjins
{
	// Token: 0x02000006 RID: 6
	public class HWID
	{
		// Token: 0x06000011 RID: 17
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool GetCurrentHwProfile(IntPtr lpHwProfileInfo);

		// Token: 0x06000012 RID: 18
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern long GetVolumeInformationA(string PathName, StringBuilder VolumeNameBuffer, int VolumeNameSize, ref int VolumeSerialNumber, ref int MaximumComponentLength, ref int FileSystemFlags, StringBuilder FileSystemNameBuffer, int FileSystemNameSize);

		// Token: 0x06000013 RID: 19 RVA: 0x000025B0 File Offset: 0x000007B0
		private static HWID.HW_PROFILE_INFO ProfileInfo()
		{
			IntPtr intPtr = IntPtr.Zero;
			HWID.HW_PROFILE_INFO result;
			try
			{
				HWID.HW_PROFILE_INFO hw_PROFILE_INFO = new HWID.HW_PROFILE_INFO();
				intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(hw_PROFILE_INFO));
				Marshal.StructureToPtr(hw_PROFILE_INFO, intPtr, false);
				bool flag = !HWID.GetCurrentHwProfile(intPtr);
				if (flag)
				{
					throw new Exception("Error cant get current hw profile!");
				}
				Marshal.PtrToStructure(intPtr, hw_PROFILE_INFO);
				result = hw_PROFILE_INFO;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
			finally
			{
				bool flag2 = intPtr != IntPtr.Zero;
				if (flag2)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002654 File Offset: 0x00000854
		private static string GetVolumeSerial(string strDriveLetter)
		{
			int value = 0;
			int num = 0;
			int num2 = 0;
			StringBuilder stringBuilder = new StringBuilder(256);
			StringBuilder stringBuilder2 = new StringBuilder(256);
			HWID.GetVolumeInformationA(strDriveLetter + ":\\", stringBuilder, stringBuilder.Capacity, ref value, ref num, ref num2, stringBuilder2, stringBuilder2.Capacity);
			return Convert.ToString(value);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026B4 File Offset: 0x000008B4
		private static string MD5(string str)
		{
			byte[] array = Encoding.UTF8.GetBytes(str);
			using (MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider())
			{
				array = md5CryptoServiceProvider.ComputeHash(array);
			}
			return BitConverter.ToString(array).Replace("-", string.Empty).ToUpper();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002718 File Offset: 0x00000918
		public static string Generate()
		{
			HWID.HW_PROFILE_INFO hw_PROFILE_INFO = HWID.ProfileInfo();
			string str = hw_PROFILE_INFO.szHwProfileGuid.ToString();
			string volumeSerial = HWID.GetVolumeSerial(Environment.SystemDirectory.Substring(0, 1));
			return HWID.MD5(str + volumeSerial);
		}

		// Token: 0x02000007 RID: 7
		[Flags]
		private enum DockInfo
		{
			// Token: 0x0400000F RID: 15
			DOCKINFO_DOCKED = 2,
			// Token: 0x04000010 RID: 16
			DOCKINFO_UNDOCKED = 1,
			// Token: 0x04000011 RID: 17
			DOCKINFO_USER_SUPPLIED = 4,
			// Token: 0x04000012 RID: 18
			DOCKINFO_USER_DOCKED = 5,
			// Token: 0x04000013 RID: 19
			DOCKINFO_USER_UNDOCKED = 6
		}

		// Token: 0x02000008 RID: 8
		[StructLayout(LayoutKind.Sequential)]
		private class HW_PROFILE_INFO
		{
			// Token: 0x04000014 RID: 20
			[MarshalAs(UnmanagedType.U4)]
			public int dwDockInfo;

			// Token: 0x04000015 RID: 21
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39)]
			public string szHwProfileGuid;

			// Token: 0x04000016 RID: 22
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szHwProfileName;
		}
	}
}
