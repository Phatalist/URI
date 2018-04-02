using System;
using System.Runtime.Serialization;

namespace MainServer.Classes
{
	// Token: 0x02000015 RID: 21
	[DataContract(Namespace = "SResponse")]
	public class SResponse<T>
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000058A3 File Offset: 0x000058A3
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000058AB File Offset: 0x000058AB
		[DataMember]
		public RequestStatus Status { get; set; } = RequestStatus.Error;

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000058B4 File Offset: 0x000058B4
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000058BC File Offset: 0x000058BC
		[DataMember]
		public string Message { get; set; } = string.Empty;

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000058C5 File Offset: 0x000058C5
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000058CD File Offset: 0x000058CD
		[DataMember]
		public T Data { get; set; } = default(T);
	}
}
