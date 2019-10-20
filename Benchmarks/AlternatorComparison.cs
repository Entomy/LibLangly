using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class AlternatorComparison {

		readonly Pattern Alternator = (Pattern)"Hello" | "Goodbye";

		readonly Regex Regex = new Regex("^(?:Hello|Goodbye)");

		[Params("Hello", "Goodbye", "Failure")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Stringier() => Alternator.Consume(Source);

		[Benchmark]
		public Match MSRegex() => Regex.Match(Source);
	}
}
