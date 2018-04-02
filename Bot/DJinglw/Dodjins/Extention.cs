using System;
using System.Web.Script.Serialization;

namespace Dodjins
{
	// Token: 0x02000011 RID: 17
	public static class Extention
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00003C74 File Offset: 0x00001E74
		private static JavaScriptSerializer JSON
		{
			get
			{
				JavaScriptSerializer result;
				if ((result = Extention.json) == null)
				{
					result = (Extention.json = new JavaScriptSerializer());
				}
				return result;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00003C9C File Offset: 0x00001E9C
		public static T ParseJSON<T>(this string @this) where T : class
		{
			T result;
			try
			{
				result = Extention.JSON.Deserialize<T>(@this.Trim());
			}
			catch
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x04000030 RID: 48
		private static JavaScriptSerializer json;
	}
}
