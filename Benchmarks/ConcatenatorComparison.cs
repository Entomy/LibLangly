using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class ConcatenatorComparison {

		readonly Pattern Concatenator = (Pattern)"Hello" & ' ' & "World";

		readonly Regex Regex = new Regex("^Hello World");

		[Params("Hello World", "Hello", "Failure")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Stringier() => Concatenator.Consume(Source);

		[Benchmark]
		public Match MSRegex() => Regex.Match(Source);

	}
}
