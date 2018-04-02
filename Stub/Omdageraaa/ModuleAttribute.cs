using System;

namespace Omdagerssss
{
	// Token: 0x02000008 RID: 8
	[AttributeUsage(AttributeTargets.Class)]
	public class ModuleAttribute : Attribute
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002BE7 File Offset: 0x00000DE7
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002BEF File Offset: 0x00000DEF
		public string Description { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002BF8 File Offset: 0x00000DF8
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002C00 File Offset: 0x00000E00
		public string Version { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002C09 File Offset: 0x00000E09
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00002C11 File Offset: 0x00000E11
		public string Author { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002C1A File Offset: 0x00000E1A
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00002C22 File Offset: 0x00000E22
		public string Name { get; set; }
	}
}
