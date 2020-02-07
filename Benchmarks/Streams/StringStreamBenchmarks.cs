using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier.Streams;

namespace Benchmarks.Extensions {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class StringStreamBenchmarks {
		public static readonly String String = "The quick brown fox jumps\nover the lazy dog";

		public static readonly StringStream Stream = new StringStream(String);

		public static readonly StreamReader Reader = new StreamReader(Stream);

		[Benchmark]
		public StringStream StreamConstruction() => new StringStream(String);

		[Benchmark]
		public StreamReader ReaderConstruction() => new StreamReader(Stream);

		[Benchmark]
		public Int32 Read() => Reader.Read();

		[Benchmark]
		public String ReadLine() => Reader.ReadLine();

		[Benchmark]
		public String ReadToEnd() => Reader.ReadToEnd();

		[Benchmark]
		public void Seek() => Stream.Seek(10, SeekOrigin.Begin);
	}
}
