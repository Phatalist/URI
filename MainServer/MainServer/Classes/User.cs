using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainServer.Classes
{
	// Token: 0x02000016 RID: 22
	[DataContract(Namespace = "User")]
	public class User
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000058FD File Offset: 0x000058FD
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00005905 File Offset: 0x00005905
		[DataMember]
		public string Login { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000590E File Offset: 0x0000590E
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00005916 File Offset: 0x00005916
		[DataMember]
		public string Password { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000591F File Offset: 0x0000591F
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00005927 File Offset: 0x00005927
		public bool Activated { get; set; } = false;

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00005930 File Offset: 0x00005930
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00005938 File Offset: 0x00005938
		[DataMember]
		public List<string> ActivatedModules { get; set; } = new List<string>();

		// Token: 0x04000052 RID: 82
		public List<ModuleFile> Modules = new List<ModuleFile>();
	}
}
