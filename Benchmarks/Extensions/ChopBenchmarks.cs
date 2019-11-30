using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class ChopBenchmarks {
		[Params("hello world")]
		public String String { get; set; }

		[Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
		public Int32 Size { get; set; }

		[Benchmark]
		public String[] Chop() => String.Chop(Size);
	}
}
