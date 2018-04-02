using System;

namespace Decrypt
{
	// Token: 0x0200003C RID: 60
	public class RootObject
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000141 RID: 321 RVA: 0x000079BC File Offset: 0x00005BBC
		// (set) Token: 0x06000142 RID: 322 RVA: 0x000079C4 File Offset: 0x00005BC4
		public int nextId { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000143 RID: 323 RVA: 0x000079CD File Offset: 0x00005BCD
		// (set) Token: 0x06000144 RID: 324 RVA: 0x000079D5 File Offset: 0x00005BD5
		public Login[] logins { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000145 RID: 325 RVA: 0x000079DE File Offset: 0x00005BDE
		// (set) Token: 0x06000146 RID: 326 RVA: 0x000079E6 File Offset: 0x00005BE6
		public object[] disabledHosts { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000147 RID: 327 RVA: 0x000079EF File Offset: 0x00005BEF
		// (set) Token: 0x06000148 RID: 328 RVA: 0x000079F7 File Offset: 0x00005BF7
		public int version { get; set; }
	}
}
