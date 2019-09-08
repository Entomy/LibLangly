using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class AlternatorComparison {

		Pattern Alternator = (Pattern)"Hello" | "Goodbye";

		Regex Regex = new Regex("^(Hello|Goodbye)");

		[Params("Hello", "Goodbye")]
		public String Source { get; set; }

		[Benchmark]
		public Result AlternatorConsume() => Alternator.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);
	}
}
