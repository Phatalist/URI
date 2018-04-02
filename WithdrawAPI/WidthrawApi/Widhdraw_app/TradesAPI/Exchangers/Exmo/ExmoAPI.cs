using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace Widhdraw_app.TradesAPI.Exchangers.Exmo
{
	// Token: 0x0200001D RID: 29
	public class ExmoAPI : ExchangerBase
	{
		// Token: 0x060000DE RID: 222 RVA: 0x000061BC File Offset: 0x000043BC
		public ExmoAPI(string publicKey, string privateKey, string baseAdress = "http://api.exmo.com/v1/{0}") : base(publicKey, privateKey, baseAdress)
		{
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000064C4 File Offset: 0x000046C4
		public override List<Currency> GetBalance()
		{
			List<Currency> result;
			try
			{
				List<Currency> list = new List<Currency>();
				string this2 = this.ApiQuery("user_info", new Dictionary<string, string>());
				Balances balances = this2.ParseJSON<BalancesResult>().balances;
				foreach (PropertyInfo propertyInfo in balances.GetType().GetProperties())
				{
					list.Add(new Currency
					{
						Name = propertyInfo.Name,
						Amount = (string)propertyInfo.GetValue(balances, null)
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

		// Token: 0x060000E0 RID: 224 RVA: 0x0000659C File Offset: 0x0000479C
		public override string Withdraw(decimal amount, string currency, string adress, string invoice = null)
		{
			string result2;
			try
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>
				{
					{
						"amount",
						amount.ToString()
					},
					{
						"currency",
						currency
					},
					{
						"address",
						adress
					}
				};
				bool flag = !string.IsNullOrWhiteSpace(invoice);
				if (flag)
				{
					dictionary.Add("invoice", invoice);
				}
				RootObjectWidth rootObjectWidth = this.ApiQuery("withdraw_crypt", dictionary).ParseJSON<RootObjectWidth>();
				bool result = rootObjectWidth.result;
				if (result)
				{
					result2 = "Успешно";
				}
				else
				{
					result2 = rootObjectWidth.error;
				}
			}
			catch (Exception ex)
			{
				result2 = ex.Message;
			}
			return result2;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00006650 File Offset: 0x00004850
		private string ApiQuery(string apiName, IDictionary<string, string> req)
		{
			string @string;
			using (WebClient webClient = new WebClient())
			{
				string key = "nonce";
				long nounce = this._nounce;
				this._nounce = nounce + 1L;
				req.Add(key, Convert.ToString(nounce));
				string message = this.ToQueryString(req);
				string value = base.Sign(this._privateKey, message);
				webClient.Headers.Add("Sign", value);
				webClient.Headers.Add("Key", this._publicKey);
				NameValueCollection data = req.ToNameValueCollection<string, string>();
				byte[] bytes = webClient.UploadValues(string.Format(this._baseAdress, apiName), "POST", data);
				@string = Encoding.UTF8.GetString(bytes);
			}
			return @string;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00006718 File Offset: 0x00004918
		private string ToQueryString(IDictionary<string, string> dic)
		{
			string[] value = (from key in dic.Keys
			select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(dic[key]))).ToArray<string>();
			return string.Join("&", value);
		}
	}
}
