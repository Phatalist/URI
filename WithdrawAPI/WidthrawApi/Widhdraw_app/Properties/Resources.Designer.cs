using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Widhdraw_app.Properties
{
	// Token: 0x02000010 RID: 16
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600009D RID: 157 RVA: 0x00005A5B File Offset: 0x00003C5B
		internal Resources()
		{
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00005A68 File Offset: 0x00003C68
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Widhdraw_app.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00005AB0 File Offset: 0x00003CB0
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x00005AC7 File Offset: 0x00003CC7
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

		// Token: 0x04000064 RID: 100
		private static ResourceManager resourceMan;

		// Token: 0x04000065 RID: 101
		private static CultureInfo resourceCulture;
	}
}
