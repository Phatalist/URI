using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Widhdraw_app.TradesAPI;

namespace MainServer.Classes
{
	// Token: 0x0200000F RID: 15
	[ServiceContract]
	internal interface IUser
	{
		// Token: 0x06000066 RID: 102
		[OperationContract]
		Task<SResponse<bool>> Authorize(User user);

		// Token: 0x06000067 RID: 103
		[OperationContract]
		Task<SResponse<bool>> Register(User user);

		// Token: 0x06000068 RID: 104
		[OperationContract]
		Task<SResponse<List<ModuleFile>>> UserModules(User user);

		// Token: 0x06000069 RID: 105
		[OperationContract]
		Task<SResponse<byte[]>> CreateBuild(User user, BuildSettings settings);

		// Token: 0x0600006A RID: 106
		[OperationContract]
		Task<SResponse<List<string>>> CustomModules(User user);

		// Token: 0x0600006B RID: 107
		[OperationContract]
		Task<SResponse<List<Currency>>> GetBalance(User user, string Name, string PublicKey, string PrivateKey);

		// Token: 0x0600006C RID: 108
		[OperationContract]
		Task<SResponse<string>> Withdraw(User user, string Name, string PublicKey, string PrivateKey, WithdrawRequest request);

		// Token: 0x0600006D RID: 109
		[OperationContract]
		Task<SResponse<List<string>>> AvailableExchangers(User user);

		// Token: 0x0600006E RID: 110
		[OperationContract]
		Task AMAVULN(string hwid);
	}
}
