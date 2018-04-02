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
	// Token: 0x02000050 RID: 80
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x00008B7D File Offset: 0x00006D7D
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00008B90 File Offset: 0x00006D90
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

		// Token: 0x060001E4 RID: 484 RVA: 0x00008BF8 File Offset: 0x00006DF8
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00008C2C File Offset: 0x00006E2C
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

		// Token: 0x060001E6 RID: 486 RVA: 0x00008CB0 File Offset: 0x00006EB0
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullname;
			if (resourceNames.TryGetValue(name, out fullname))
			{
				return AssemblyLoader.LoadStream(fullname);
			}
			return null;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00008CD0 File Offset: 0x00006ED0
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00008CF8 File Offset: 0x00006EF8
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

		// Token: 0x060001E9 RID: 489 RVA: 0x00008DB8 File Offset: 0x00006FB8
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

		// Token: 0x060001EA RID: 490 RVA: 0x00008E78 File Offset: 0x00007078
		static AssemblyLoader()
		{
			// Note: this type is marked as 'beforefieldinit'.
			AssemblyLoader.assemblyNames.Add("omdageraaa", "costura.omdageraaa.dll.compressed");
			AssemblyLoader.symbolNames.Add("omdageraaa", "costura.omdageraaa.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("system.data.sqlite", "costura.system.data.sqlite.dll.compressed");
			AssemblyLoader.assemblyNames.Add("wmigatherer", "costura.wmigatherer.dll.compressed");
			AssemblyLoader.symbolNames.Add("wmigatherer", "costura.wmigatherer.pdb.compressed");
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00008F17 File Offset: 0x00007117
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x040000FF RID: 255
		private static readonly object nullCacheLock = new object();

		// Token: 0x04000100 RID: 256
		private static readonly Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x04000101 RID: 257
		private static readonly Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x04000102 RID: 258
		private static readonly Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x04000103 RID: 259
		private static int isAttached = 0;
	}
}
