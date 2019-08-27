using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class RangeComparison {

		Pattern Pattern = (From: "Hello", To: ";");

		Regex Regex = new Regex("^Hello.*;$");

		[Params("Hello World;", "Hello World", "Goodbye World;")]
		public String Source { get; set; }

		[Benchmark]
		public Result RangeConsume() => Pattern.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
