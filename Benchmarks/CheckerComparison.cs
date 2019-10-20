using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class CheckerComparison {

		readonly Pattern Alternator = (Pattern)'0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9';

		readonly Pattern Checker = Pattern.Check("Number", (Char) => 0x30 <= Char && Char <= 0x39);

		[Params("0", "1", "a")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Stringier() => Alternator.Consume(Source);

		[Benchmark]
		public Result MSRegex() => Checker.Consume(Source);

	}
}
