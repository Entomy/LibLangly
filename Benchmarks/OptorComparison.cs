using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class OptorComparison {

		Pattern Optor = ~(Pattern)"Hello";

		Regex Regex = new Regex("^(Hello)?");

		[Benchmark]
		public Result OptorConsumeCase1() => Optor.Consume("Hello");

		[Benchmark]
		public Result OptorConsumeCase2() => Optor.Consume("Bacon");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("Hello");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Bacon");

	}
}
