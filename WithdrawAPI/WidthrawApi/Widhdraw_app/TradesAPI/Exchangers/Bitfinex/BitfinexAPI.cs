using System;
using System.Collections.Generic;
using System.Linq;
using BitfinexApi;

namespace Widhdraw_app.TradesAPI.Exchangers.Bitfinex
{
	// Token: 0x02000038 RID: 56
	public class BitfinexAPI : ExchangerBase
	{
		// Token: 0x060001DF RID: 479 RVA: 0x00007F10 File Offset: 0x00006110
		public BitfinexAPI(string publicKey, string privateKey) : base(publicKey, privateKey, null)
		{
			this._client = new BitfinexApiV1(publicKey, privateKey);
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00007F2C File Offset: 0x0000612C
		public override List<Currency> GetBalance()
		{
			List<Currency> result;
			try
			{
				List<Currency> list = new List<Currency>();
				BalancesResponse balances = this._client.GetBalances();
				list.Add(new Currency
				{
					Name = "BTC_EXCH",
					Amount = balances.exchange.BTC.ToString()
				});
				list.Add(new Currency
				{
					Name = "BTC_DSPT",
					Amount = balances.deposit.BTC.ToString()
				});
				list.Add(new Currency
				{
					Name = "BTC_TRDNG",
					Amount = balances.trading.BTC.ToString()
				});
				list = (from x in list
				orderby x.Amount descending
				select x).ToList<Currency>();
				result = list;
			}
			catch
			{
				result = new List<Currency>();
			}
			return result;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00008024 File Offset: 0x00006224
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result;
			try
			{
				WidthrawResponse widthrawResponse = this._client.Widthraw(adress, amount.ToString());
				result = widthrawResponse.status;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x040000F4 RID: 244
		private BitfinexApiV1 _client;
	}
}
