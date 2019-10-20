using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class NegatorComparison {

		readonly Pattern Negator = !(Pattern)"Hello";

		readonly Regex Regex = new Regex("^[^H][^e][^l][^l][^o]");

		[Params("World", "Hello")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Stringier() => Negator.Consume(Source);

		[Benchmark]
		public Match MSRegex() => Regex.Match(Source);

	}
}
