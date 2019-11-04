using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class CleanBenchmarks {
		[Params('o')]
		public Char Char { get; set; }

		[Params("hello world", "hello  world", " hello  world ", "hellooo world")]
		public String String { get; set; }

		[Benchmark]
		public String Clean() => String.Clean();

		[Benchmark]
		public String Clean2() => String.Clean(Char);
	}
}
