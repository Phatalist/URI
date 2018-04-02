using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Omdagerssss
{
	// Token: 0x02000005 RID: 5
	[ServiceContract(CallbackContract = typeof(Foo))]
	public interface IConnector
	{
		// Token: 0x06000022 RID: 34
		[OperationContract]
		Task<List<ModuleFile>> GetModuleList();
	}
}
