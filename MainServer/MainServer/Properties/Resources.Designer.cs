using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MainServer.Properties
{
	// Token: 0x02000007 RID: 7
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003580 File Offset: 0x00003580
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000026 RID: 38 RVA: 0x0000358C File Offset: 0x0000358C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("MainServer.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000035D4 File Offset: 0x000035D4
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000035EB File Offset: 0x000035EB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400001D RID: 29
		private static ResourceManager resourceMan;

		// Token: 0x0400001E RID: 30
		private static CultureInfo resourceCulture;
	}
}
