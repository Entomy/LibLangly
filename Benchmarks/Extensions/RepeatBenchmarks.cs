using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
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
