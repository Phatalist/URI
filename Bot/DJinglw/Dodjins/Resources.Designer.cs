using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Dodjins
{
	// Token: 0x02000035 RID: 53
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	internal class Resources
	{
		// Token: 0x06000124 RID: 292 RVA: 0x00006D3E File Offset: 0x00004F3E
		internal Resources()
		{
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00006D48 File Offset: 0x00004F48
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("Dodjins.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00006D90 File Offset: 0x00004F90
		// (set) Token: 0x06000127 RID: 295 RVA: 0x00006DA7 File Offset: 0x00004FA7
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

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00006DB0 File Offset: 0x00004FB0
		internal static byte[] SQLite_Interop_x64
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("SQLite_Interop_x64", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00006DE0 File Offset: 0x00004FE0
		internal static byte[] SQLite_Interop_x86
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("SQLite_Interop_x86", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00006E10 File Offset: 0x00005010
		internal static byte[] System_Data_SQLite
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("System_Data_SQLite", Resources.resourceCulture);
				return (byte[])@object;
			}
		}

		// Token: 0x040000A0 RID: 160
		private static ResourceManager resourceMan;

		// Token: 0x040000A1 RID: 161
		private static CultureInfo resourceCulture;
	}
}
