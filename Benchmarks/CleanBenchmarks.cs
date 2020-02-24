using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
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
