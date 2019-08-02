using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class AlternatorComparison {

		Pattern Alternator = (Pattern)"Hello" | "Goodbye";

		Regex Regex = new Regex("^(Hello|Goodbye)");

		[Benchmark]
		public Result AlternatorConsumeCase1() => Alternator.Consume("Hello");

		[Benchmark]
		public Result AlternatorConsumeCase2() => Alternator.Consume("Goodbye");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("Hello");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Goodbye");
	}
}
