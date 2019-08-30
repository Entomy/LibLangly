using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class OptorComparison {

		Pattern Optor = -(Pattern)"Hello";

		Regex Regex = new Regex("^(Hello)?");

		[Params("Hello", "World")]
		public String Source { get; set; }

		[Benchmark]
		public Result OptorConsume() => Optor.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
