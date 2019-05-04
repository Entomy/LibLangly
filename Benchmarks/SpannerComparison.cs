using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class SpannerComparison {

		Spanner Spanner = +(Literal)"Hi!";

		Regex Regex = new Regex("^(Hi!)+");

		[Benchmark]
		public Result SpannerConsume() => Spanner.Consume("Hi!Hi!Hi!");

		[Benchmark]
		public Match RegexMatch() => Regex.Match("Hi!Hi!Hi!");

	}
}
