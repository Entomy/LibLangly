using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class LiteralComparison {

		Pattern Literal = "Hello";

		Regex Regex = new Regex("^Hello");

		[Params("Hello", "World", "H")]
		public String Source { get; set; }

		[Benchmark]
		public Result LiteralConsume() => Literal.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
