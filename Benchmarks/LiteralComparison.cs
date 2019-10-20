using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class LiteralComparison {

		readonly Pattern Literal = "Hello";

		readonly Regex Regex = new Regex("^Hello");

		[Params("Hello", "World", "H", "Failure")]
		public String Source { get; set; }

		[Benchmark]
		public Result Stringier() => Literal.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match MSRegex() => Regex.Match(Source);

	}
}
