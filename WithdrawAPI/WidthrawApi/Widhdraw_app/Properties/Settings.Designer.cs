using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Widhdraw_app.Properties
{
	// Token: 0x02000011 RID: 17
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00005AD0 File Offset: 0x00003CD0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000066 RID: 102
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
