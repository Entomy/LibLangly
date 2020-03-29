using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class ChopBenchmarks {
		[Params("hello world")]
		public String String { get; set; }

		[Params(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)]
		public Int32 Size { get; set; }

		[Benchmark]
		public void Chop() => String.Chop(Size);
	}
}
