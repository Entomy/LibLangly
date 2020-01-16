using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class CheckerBenchmarks {
		public static readonly Pattern alternator = '0'.Or('1').Or('2').Or('3').Or('4').Or('5').Or('6').Or('7').Or('8').Or('9');

		public static readonly Pattern checker = Check((Char) => 0x30 <= Char && Char <= 0x39);

		[Params("0", "1", "a")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Alternator() => alternator.Consume(Source);

		[Benchmark]
		public Result Checker() => checker.Consume(Source);
	}
}
