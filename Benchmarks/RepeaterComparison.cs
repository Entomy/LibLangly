using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class RepeaterComparison {

		Pattern Repeater = (Pattern)"Hi!" * 2;

		Regex Regex = new Regex("^(Hi!){2}");

		[Params("Hi!Hi!", "Hi!Hi!Hi!", "Hi!")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result RepeaterConsume() => Repeater.Consume(Source);

		[Benchmark]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
