using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class RepeatBenchmarks {
		[Params(1,2,3)]
		public Int32 Count { get; set; }

		[Benchmark]
		public String RepeatChar() => 'a'.Repeat(Count);

		[Benchmark]
		public String RepeatString() => "hi!".Repeat(Count);
	}
}
