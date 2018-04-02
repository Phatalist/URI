using System;

namespace Omdagerssss
{
	// Token: 0x02000009 RID: 9
	[AttributeUsage(AttributeTargets.Method)]
	public class InputParamAttribute : Attribute
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002C34 File Offset: 0x00000E34
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002C3C File Offset: 0x00000E3C
		public string[] Names { get; set; }
	}
}
