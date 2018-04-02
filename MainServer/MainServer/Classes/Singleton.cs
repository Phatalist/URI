using System;

namespace MainServer.Classes
{
	// Token: 0x02000014 RID: 20
	public class Singleton<T> where T : class, new()
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00003580 File Offset: 0x00003580
		protected Singleton()
		{
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000089 RID: 137 RVA: 0x0000588C File Offset: 0x0000588C
		public static T Instance
		{
			get
			{
				return Singleton<T>.SingletonCreator<T>.CreatorInstance;
			}
		}

		// Token: 0x02000042 RID: 66
		private sealed class SingletonCreator<S> where S : class, new()
		{
			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000121 RID: 289 RVA: 0x00008994 File Offset: 0x00008994
			public static S CreatorInstance
			{
				get
				{
					return Singleton<T>.SingletonCreator<S>.lazy.Value;
				}
			}

			// Token: 0x04000129 RID: 297
			private static readonly Lazy<S> lazy = new Lazy<S>(() => Activator.CreateInstance<S>());
		}
	}
}
