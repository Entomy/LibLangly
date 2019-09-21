using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class CheckerComparison {

		Pattern Alternator = (Pattern)'0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9';

		Pattern Checker = Pattern.Check("Number", (Char) => 0x30 <= Char && Char <= 0x39);

		[Params("0", "1", "a")]
		public String Source { get; set; }

		[Benchmark]
		public Result AlternatorConsume() => Alternator.Consume(Source);

		[Benchmark]
		public Result CheckerConsume() => Checker.Consume(Source);

	}
}
