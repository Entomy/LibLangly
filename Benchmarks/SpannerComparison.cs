using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class SpannerComparison {

		readonly Pattern Spanner = +(Pattern)"Hi!";

		readonly Regex Regex = new Regex("^(Hi!)+");

		[Params("Hi!Hi!", "Hi!Hi!Hi!", "Hi!", "Okay?")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Stringier() => Spanner.Consume(Source);

		[Benchmark]
		public Match MSRegex() => Regex.Match(Source);

	}
}