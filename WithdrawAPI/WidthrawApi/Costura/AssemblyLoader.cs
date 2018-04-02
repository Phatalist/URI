using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x0200003E RID: 62
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x060001EC RID: 492 RVA: 0x0000823A File Offset: 0x0000643A
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000824C File Offset: 0x0000644C
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x000082B4 File Offset: 0x000064B4
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000082E8 File Offset: 0x000064E8
		private static Stream LoadStream(string fullname)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullname.EndsWith(".compressed"))
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullname))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullname);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0000836C File Offset: 0x0000656C
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullname;
			if (resourceNames.TryGetValue(name, out fullname))
			{
				return AssemblyLoader.LoadStream(fullname);
			}
			return null;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000838C File Offset: 0x0000658C
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x000083B4 File Offset: 0x000065B4
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = string.Format("{0}.{1}", requestedAssemblyName.CultureInfo.Name, text);
			}
			byte[] rawAssembly;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				rawAssembly = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00008474 File Offset: 0x00006674
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				obj = AssemblyLoader.nullCacheLock;
				lock (obj)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if (assemblyName.Flags == AssemblyNameFlags.Retargetable)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00008534 File Offset: 0x00006734
		static AssemblyLoader()
		{
			// Note: this type is marked as 'beforefieldinit'.
			AssemblyLoader.assemblyNames.Add("binance.api.csharp.client", "costura.binance.api.csharp.client.dll.compressed");
			AssemblyLoader.assemblyNames.Add("binance.api.csharp.client.domain", "costura.binance.api.csharp.client.domain.dll.compressed");
			AssemblyLoader.assemblyNames.Add("binance.api.csharp.client.models", "costura.binance.api.csharp.client.models.dll.compressed");
			AssemblyLoader.assemblyNames.Add("bitfinexapi", "costura.bitfinexapi.dll.compressed");
			AssemblyLoader.symbolNames.Add("bitfinexapi", "costura.bitfinexapi.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("bittrex.net", "costura.bittrex.net.dll.compressed");
			AssemblyLoader.assemblyNames.Add("hitbtcapi", "costura.hitbtcapi.dll.compressed");
			AssemblyLoader.symbolNames.Add("hitbtcapi", "costura.hitbtcapi.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("restsharp", "costura.restsharp.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.valuetuple", "costura.system.valuetuple.dll.compressed");
			AssemblyLoader.assemblyNames.Add("websocket-sharp", "costura.websocket-sharp.dll.compressed");
			AssemblyLoader.assemblyNames.Add("xnet", "costura.xnet.dll.compressed");
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00008673 File Offset: 0x00006873
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x040000FC RID: 252
		private static readonly object nullCacheLock = new object();

		// Token: 0x040000FD RID: 253
		private static readonly Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x040000FE RID: 254
		private static readonly Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x040000FF RID: 255
		private static readonly Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x04000100 RID: 256
		private static int isAttached = 0;
	}
}
