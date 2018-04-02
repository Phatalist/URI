using System;
using System.Collections.Generic;
using System.Linq;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Market;

namespace Widhdraw_app.TradesAPI.Exchangers.Binance
{
	// Token: 0x0200003A RID: 58
	public class BinanceAPI : ExchangerBase
	{
		// Token: 0x060001E5 RID: 485 RVA: 0x00008078 File Offset: 0x00006278
		public BinanceAPI(string publicKey, string privateKey) : base(publicKey, privateKey, null)
		{
			this._client = new ApiClient(publicKey, privateKey, "https://www.binance.com", "wss://stream.binance.com:9443/ws/", true);
			this.binanceClient = new BinanceClient(this._client, false);
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000080B0 File Offset: 0x000062B0
		public override List<Currency> GetBalance()
		{
			List<Currency> result;
			try
			{
				List<Currency> list = new List<Currency>();
				IEnumerable<Balance> balances = this.binanceClient.GetAccountInfo(5000L).Result.Balances;
				foreach (Balance balance in balances)
				{
					list.Add(new Currency
					{
						Name = balance.Asset,
						Amount = balance.Free.ToString()
					});
				}
				list = (from x in list
				orderby x.Amount descending
				select x).ToList<Currency>();
				result = list;
			}
			catch (Exception ex)
			{
				result = new List<Currency>();
			}
			return result;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008194 File Offset: 0x00006394
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result = string.Empty;
			try
			{
				result = this.binanceClient.Withdraw(currency, amount, adress, "", 5000L).Result.Msg;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x040000F7 RID: 247
		private ApiClient _client;

		// Token: 0x040000F8 RID: 248
		private BinanceClient binanceClient;
	}
}
