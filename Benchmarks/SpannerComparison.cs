using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class SpannerComparison {

		Pattern Spanner = +(Pattern)"Hi!";

		Regex Regex = new Regex("^(Hi!)+");

		[Params("Hi!Hi!", "Hi!Hi!Hi!", "Hi!", "Okay?")]
		public String Source { get; set; }

		[Benchmark]
		public Result SpannerConsume() => Spanner.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}