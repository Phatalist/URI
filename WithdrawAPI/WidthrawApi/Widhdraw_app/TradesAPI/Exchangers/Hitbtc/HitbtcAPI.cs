using System;
using System.Collections.Generic;
using System.Linq;
using HitBtcApi;
using HitBtcApi.Model;

namespace Widhdraw_app.TradesAPI.Exchangers.Hitbtc
{
	// Token: 0x02000034 RID: 52
	public class HitbtcAPI : ExchangerBase
	{
		// Token: 0x060001D3 RID: 467 RVA: 0x00007B5F File Offset: 0x00005D5F
		public HitbtcAPI(string publicKey, string privateKey) : base(publicKey, privateKey, null)
		{
			this.api = new HitBtcApi();
			this.api.Authorize(publicKey, privateKey);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00007B88 File Offset: 0x00005D88
		public override List<Currency> GetBalance()
		{
			List<Currency> list = new List<Currency>();
			try
			{
				MultiCurrencyBalance result = this.api.Payment.GetMultiCurrencyBalance().Result;
				bool flag = result.balance != null;
				if (flag)
				{
					foreach (Balance balance in result.balance)
					{
						list.Add(new Currency
						{
							Name = balance.currency_code,
							Amount = balance.balance.ToString()
						});
					}
					list = (from x in list
					orderby x.Amount descending
					select x).ToList<Currency>();
				}
				else
				{
					list.Add(new Currency
					{
						Name = "БАЛАНС ВЕЗДЕ",
						Amount = "0"
					});
				}
			}
			catch (Exception ex)
			{
				list = new List<Currency>();
			}
			return list;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00007CB0 File Offset: 0x00005EB0
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result = string.Empty;
			try
			{
				result = this.api.Payment.GetPyout(amount, currency, adress, paymentid).Result.status;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x040000EE RID: 238
		private HitBtcApi api;
	}
}
