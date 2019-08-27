using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class NegatorComparison {

		Pattern Negator = !(Pattern)"Hello";

		Regex Regex = new Regex("^[^H][^e][^l][^l][^o]");

		[Params("World", "Hello")]
		public String Source { get; set; }

		[Benchmark]
		public Result NegatorConsume() => Negator.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
