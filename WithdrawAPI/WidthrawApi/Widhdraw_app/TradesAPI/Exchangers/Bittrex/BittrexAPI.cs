using System;
using System.Collections.Generic;
using System.Linq;
using Bittrex.Net;
using Bittrex.Net.Objects;

namespace Widhdraw_app.TradesAPI.Exchangers.Bittrex
{
	// Token: 0x02000036 RID: 54
	public class BittrexAPI : ExchangerBase
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x00007D18 File Offset: 0x00005F18
		public BittrexAPI(string publicKey, string privateKey, string baseAdress = null) : base(publicKey, privateKey, null)
		{
			this._client = new BittrexClient();
			this._client.SetApiCredentials(publicKey, privateKey);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00007D40 File Offset: 0x00005F40
		public override List<Currency> GetBalance()
		{
			List<Currency> result2;
			try
			{
				List<Currency> list = new List<Currency>();
				BittrexApiResult<BittrexBalance[]> balances = this._client.GetBalances();
				bool success = balances.Success;
				if (success)
				{
					foreach (BittrexBalance bittrexBalance in balances.Result)
					{
						bool flag = bittrexBalance.Balance != null;
						if (flag)
						{
							list.Add(new Currency
							{
								Name = bittrexBalance.Currency,
								Amount = ((bittrexBalance.Balance == null) ? "0" : bittrexBalance.Balance.ToString())
							});
						}
					}
					list = (from x in list
					orderby x.Amount descending
					select x).ToList<Currency>();
					result2 = list;
				}
				else
				{
					result2 = list;
				}
			}
			catch (Exception ex)
			{
				result2 = new List<Currency>();
			}
			return result2;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00007E4C File Offset: 0x0000604C
		public override string Withdraw(decimal amount, string currency, string adress, string invoice = null)
		{
			string result;
			try
			{
				string text = string.Empty;
				bool flag = !string.IsNullOrWhiteSpace(invoice);
				if (flag)
				{
					BittrexApiResult<BittrexGuid> bittrexApiResult = this._client.Withdraw(currency, amount, adress, invoice);
					bool success = bittrexApiResult.Success;
					if (success)
					{
						text = "Успешно";
					}
					else
					{
						text = bittrexApiResult.Error.ErrorMessage;
					}
				}
				else
				{
					BittrexApiResult<BittrexGuid> bittrexApiResult2 = this._client.Withdraw(currency, amount, adress, null);
					bool success2 = bittrexApiResult2.Success;
					if (success2)
					{
						text = "Успешно";
					}
					else
					{
						text = bittrexApiResult2.Error.ErrorMessage;
					}
				}
				result = text;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x040000F1 RID: 241
		private BittrexClient _client;
	}
}
