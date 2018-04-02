using System;
using System.Globalization;

namespace Decrypt
{
	// Token: 0x02000042 RID: 66
	public class PasswordCheck
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600017E RID: 382 RVA: 0x0000841C File Offset: 0x0000661C
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00008424 File Offset: 0x00006624
		public string EntrySalt { get; private set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000180 RID: 384 RVA: 0x0000842D File Offset: 0x0000662D
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00008435 File Offset: 0x00006635
		public string OID { get; private set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000843E File Offset: 0x0000663E
		// (set) Token: 0x06000183 RID: 387 RVA: 0x00008446 File Offset: 0x00006646
		public string Passwordcheck { get; private set; }

		// Token: 0x06000184 RID: 388 RVA: 0x00008450 File Offset: 0x00006650
		public PasswordCheck(string DataToParse)
		{
			int num = int.Parse(DataToParse.Substring(2, 2), NumberStyles.HexNumber) * 2;
			this.EntrySalt = DataToParse.Substring(6, num);
			int num2 = DataToParse.Length - (6 + num + 36);
			this.OID = DataToParse.Substring(6 + num + 36, num2);
			this.Passwordcheck = DataToParse.Substring(6 + num + 4 + num2);
		}
	}
}
