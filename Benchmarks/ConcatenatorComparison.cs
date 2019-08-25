using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class ConcatenatorComparison {

		Pattern Concatenator = (Pattern)"Hello" & "World";

		Regex Regex = new Regex("^(Hello)(World)");

		[Params("HelloWorld", "Hello")]
		public String Source { get; set; }

		[Benchmark]
		public Result ConcatenatorConsume() => Concatenator.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
