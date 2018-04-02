using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Widhdraw_app.TradesAPI.Exchangers.Binance;
using Widhdraw_app.TradesAPI.Exchangers.Bitfinex;
using Widhdraw_app.TradesAPI.Exchangers.Bittrex;
using Widhdraw_app.TradesAPI.Exchangers.Cryptopia;
using Widhdraw_app.TradesAPI.Exchangers.Exmo;
using Widhdraw_app.TradesAPI.Exchangers.Hitbtc;
using Widhdraw_app.TradesAPI.Exchangers.Livecoin;
using Widhdraw_app.TradesAPI.Exchangers.Poloniex;
using Widhdraw_app.TradesAPI.Exchangers.Yobit;

namespace Widhdraw_app.TradesAPI
{
	// Token: 0x02000013 RID: 19
	public abstract class ExchangerBase
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00005C18 File Offset: 0x00003E18
		public ExchangerBase(string publicKey, string privateKey, string baseAdress = null)
		{
			this._publicKey = publicKey;
			this._privateKey = privateKey;
			this._baseAdress = baseAdress;
		}

		// Token: 0x060000A8 RID: 168
		public abstract List<Currency> GetBalance();

		// Token: 0x060000A9 RID: 169
		public abstract string Withdraw(decimal amount, string currency, string adress, string paymentid = null);

		// Token: 0x060000AA RID: 170 RVA: 0x00005C88 File Offset: 0x00003E88
		protected string Sign(string key, string message)
		{
			string result;
			using (HMACSHA512 hmacsha = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
			{
				byte[] buff = hmacsha.ComputeHash(Encoding.UTF8.GetBytes(message));
				result = this.ByteToString(buff);
			}
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005CE0 File Offset: 0x00003EE0
		protected string ByteToString(byte[] buff)
		{
			string text = "";
			for (int i = 0; i < buff.Length; i++)
			{
				text += buff[i].ToString("X2");
			}
			return text.ToLowerInvariant();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005D2C File Offset: 0x00003F2C
		public static ExchangerBase CreateExchanger(string name, string pubkey, string privatekey)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 2023983646u)
			{
				if (num <= 1061567749u)
				{
					if (num != 433071488u)
					{
						if (num == 1061567749u)
						{
							if (name == "Hitbtc")
							{
								return new HitbtcAPI(pubkey, privatekey);
							}
						}
					}
					else if (name == "Bitfinex")
					{
						return new BitfinexAPI(pubkey, privatekey);
					}
				}
				else if (num != 1238851600u)
				{
					if (num == 2023983646u)
					{
						if (name == "Cryptopia")
						{
							return new CryptopiaAPI(pubkey, privatekey, "https://www.cryptopia.co.nz/Api/");
						}
					}
				}
				else if (name == "Exmo")
				{
					return new ExmoAPI(pubkey, privatekey, "http://api.exmo.com/v1/{0}");
				}
			}
			else if (num <= 2800880393u)
			{
				if (num != 2068254929u)
				{
					if (num == 2800880393u)
					{
						if (name == "Poloniex")
						{
							return new PoloniexAPI(pubkey, privatekey, "https://poloniex.com/tradingApi");
						}
					}
				}
				else if (name == "Binance")
				{
					return new BinanceAPI(pubkey, privatekey);
				}
			}
			else if (num != 3577317231u)
			{
				if (num != 3669191692u)
				{
					if (num == 3956517394u)
					{
						if (name == "Livecoin")
						{
							return new LivecoinAPI(pubkey, privatekey, "https://api.livecoin.net/");
						}
					}
				}
				else if (name == "Yobit")
				{
					return new YobitAPI(pubkey, privatekey, "https://yobit.net/tapi/");
				}
			}
			else if (name == "Bittrex")
			{
				return new BittrexAPI(pubkey, privatekey, null);
			}
			throw new Exception("Unkown exchanger");
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005F00 File Offset: 0x00004100
		public static ExchangerBase CreateExchanger(string name, string pubkey, string privatekey, string baseAdress)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 2023983646u)
			{
				if (num <= 1061567749u)
				{
					if (num != 433071488u)
					{
						if (num == 1061567749u)
						{
							if (name == "Hitbtc")
							{
								return new HitbtcAPI(pubkey, privatekey);
							}
						}
					}
					else if (name == "Bitfinex")
					{
						return new BitfinexAPI(pubkey, privatekey);
					}
				}
				else if (num != 1238851600u)
				{
					if (num == 2023983646u)
					{
						if (name == "Cryptopia")
						{
							return new CryptopiaAPI(pubkey, privatekey, baseAdress);
						}
					}
				}
				else if (name == "Exmo")
				{
					return new ExmoAPI(pubkey, privatekey, baseAdress);
				}
			}
			else if (num <= 2800880393u)
			{
				if (num != 2068254929u)
				{
					if (num == 2800880393u)
					{
						if (name == "Poloniex")
						{
							return new PoloniexAPI(pubkey, privatekey, baseAdress);
						}
					}
				}
				else if (name == "Binance")
				{
					return new BinanceAPI(pubkey, privatekey);
				}
			}
			else if (num != 3577317231u)
			{
				if (num != 3669191692u)
				{
					if (num == 3956517394u)
					{
						if (name == "Livecoin")
						{
							return new LivecoinAPI(pubkey, privatekey, baseAdress);
						}
					}
				}
				else if (name == "Yobit")
				{
					return new YobitAPI(pubkey, privatekey, baseAdress);
				}
			}
			else if (name == "Bittrex")
			{
				return new BittrexAPI(pubkey, privatekey, baseAdress);
			}
			throw new Exception("Unkown exchanger");
		}

		// Token: 0x04000068 RID: 104
		protected string _publicKey = string.Empty;

		// Token: 0x04000069 RID: 105
		protected string _privateKey = string.Empty;

		// Token: 0x0400006A RID: 106
		protected string _baseAdress = string.Empty;

		// Token: 0x0400006B RID: 107
		protected long _nounce = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalMilliseconds;
	}
}
