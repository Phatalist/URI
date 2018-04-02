using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Omdagerssss
{
	// Token: 0x0200000A RID: 10
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resource1
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002C45 File Offset: 0x00000E45
		internal Resource1()
		{
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002C50 File Offset: 0x00000E50
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resource1.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Omdagerssss.Resource1", typeof(Resource1).Assembly);
					Resource1.resourceMan = resourceManager;
				}
				return Resource1.resourceMan;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002C98 File Offset: 0x00000E98
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002CAF File Offset: 0x00000EAF
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resource1.resourceCulture;
			}
			set
			{
				Resource1.resourceCulture = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002CB8 File Offset: 0x00000EB8
		internal static byte[] FradieMerqury
		{
			get
			{
				object @object = Resource1.ResourceManager.GetObject("FradieMerqury", Resource1.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x04000015 RID: 21
		private static ResourceManager resourceMan;

		// Token: 0x04000016 RID: 22
		private static CultureInfo resourceCulture;
	}
}
