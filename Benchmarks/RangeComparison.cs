using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class RangeComparison {

		Pattern Pattern = Pattern.Range(From: "Hello", To: ";");

		Regex Regex = new Regex("^Hello.*;$");

		[Params("Hello World;", "Hello World", "Goodbye World;")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Stringier() => Pattern.Consume(Source);

		[Benchmark]
		public Match MSRegex() => Regex.Match(Source);

	}
}
