using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Widhdraw_app.TradesAPI.Exchangers.Yobit
{
	// Token: 0x0200001A RID: 26
	public class YobitAPI : ExchangerBase
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x000061BC File Offset: 0x000043BC
		public YobitAPI(string publicKey, string privateKey, string baseAdress = "https://yobit.net/tapi/") : base(publicKey, privateKey, baseAdress)
		{
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000061CC File Offset: 0x000043CC
		public override List<Currency> GetBalance()
		{
			List<Currency> result;
			try
			{
				string this2 = this.ApiQuery("getInfo", new Dictionary<string, string>());
				RootObject rootObject = this2.ParseJSON<RootObject>();
				List<Currency> list = new List<Currency>();
				foreach (KeyValuePair<string, string> keyValuePair in rootObject.@return.funds)
				{
					list.Add(new Currency
					{
						Name = keyValuePair.Key,
						Amount = keyValuePair.Value
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

		// Token: 0x060000D6 RID: 214 RVA: 0x000062B4 File Offset: 0x000044B4
		private string ApiQuery(string apiName, IDictionary<string, string> req)
		{
			string value = ((int)Math.Round(DateTime.Now.Subtract(new DateTime(2018, 1, 1)).TotalSeconds * 100.0)).ToString();
			string @string;
			using (WebClient webClient = new WebClient())
			{
				req.Add("nonce", value);
				req.Add("method", apiName);
				string message = this.ToQueryString(req);
				string value2 = base.Sign(this._privateKey, message);
				webClient.Headers.Add("Sign", value2);
				webClient.Headers.Add("Key", this._publicKey);
				NameValueCollection data = req.ToNameValueCollection<string, string>();
				byte[] bytes = webClient.UploadValues(this._baseAdress, "POST", data);
				@string = Encoding.UTF8.GetString(bytes);
			}
			return @string;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000063B0 File Offset: 0x000045B0
		private string ToQueryString(IDictionary<string, string> dic)
		{
			string[] value = (from key in dic.Keys
			select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(dic[key]))).ToArray<string>();
			return string.Join("&", value);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000063FC File Offset: 0x000045FC
		public override string Withdraw(decimal amount, string currency, string adress, string paymentid = null)
		{
			string result;
			try
			{
				string this2 = this.ApiQuery("WithdrawCoinsToAddress", new Dictionary<string, string>
				{
					{
						"amount",
						amount.ToString()
					},
					{
						"address",
						adress
					},
					{
						"coinName",
						currency
					}
				});
				bool flag = this2.ParseJSON<RootObjectWidthdraw>().success == 0;
				if (flag)
				{
					result = "Невозможно выполнить платеж.";
				}
				else
				{
					result = "Успешно";
				}
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
	}
}
