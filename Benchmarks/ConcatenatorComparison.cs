using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class ConcatenatorComparison {

		Pattern Concatenator = (Pattern)"Hello" & ' ' & "World";

		Regex Regex = new Regex("^Hello World");

		[Params("Hello World", "Hello")]
		public String Source { get; set; }

		[Benchmark]
		public Result ConcatenatorConsume() => Concatenator.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
