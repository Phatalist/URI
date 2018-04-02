using System;
using System.Runtime.Serialization;

namespace Widhdraw_app.TradesAPI
{
	// Token: 0x02000014 RID: 20
	[DataContract(Namespace = "Currency")]
	public class Currency
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000060AC File Offset: 0x000042AC
		// (set) Token: 0x060000AF RID: 175 RVA: 0x000060B4 File Offset: 0x000042B4
		[DataMember]
		public string Amount { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x000060BD File Offset: 0x000042BD
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x000060C5 File Offset: 0x000042C5
		[DataMember]
		public string Name { get; set; }
	}
}
