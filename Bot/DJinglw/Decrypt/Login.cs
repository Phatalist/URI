using System;

namespace Decrypt
{
	// Token: 0x0200003D RID: 61
	public class Login
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00007A00 File Offset: 0x00005C00
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00007A08 File Offset: 0x00005C08
		public int id { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00007A11 File Offset: 0x00005C11
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00007A19 File Offset: 0x00005C19
		public string hostname { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00007A22 File Offset: 0x00005C22
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00007A2A File Offset: 0x00005C2A
		public object httpRealm { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00007A33 File Offset: 0x00005C33
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00007A3B File Offset: 0x00005C3B
		public string formSubmitURL { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00007A44 File Offset: 0x00005C44
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00007A4C File Offset: 0x00005C4C
		public string usernameField { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00007A55 File Offset: 0x00005C55
		// (set) Token: 0x06000155 RID: 341 RVA: 0x00007A5D File Offset: 0x00005C5D
		public string passwordField { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00007A66 File Offset: 0x00005C66
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00007A6E File Offset: 0x00005C6E
		public string encryptedUsername { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00007A77 File Offset: 0x00005C77
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00007A7F File Offset: 0x00005C7F
		public string encryptedPassword { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00007A88 File Offset: 0x00005C88
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00007A90 File Offset: 0x00005C90
		public string guid { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00007A99 File Offset: 0x00005C99
		// (set) Token: 0x0600015D RID: 349 RVA: 0x00007AA1 File Offset: 0x00005CA1
		public int encType { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600015E RID: 350 RVA: 0x00007AAA File Offset: 0x00005CAA
		// (set) Token: 0x0600015F RID: 351 RVA: 0x00007AB2 File Offset: 0x00005CB2
		public long timeCreated { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00007ABB File Offset: 0x00005CBB
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00007AC3 File Offset: 0x00005CC3
		public long timeLastUsed { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00007ACC File Offset: 0x00005CCC
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00007AD4 File Offset: 0x00005CD4
		public long timePasswordChanged { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000164 RID: 356 RVA: 0x00007ADD File Offset: 0x00005CDD
		// (set) Token: 0x06000165 RID: 357 RVA: 0x00007AE5 File Offset: 0x00005CE5
		public int timesUsed { get; set; }
	}
}
