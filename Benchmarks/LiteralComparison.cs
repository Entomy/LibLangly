using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class LiteralComparison {

		Pattern Literal = "Hello";

		Regex Regex = new Regex("^Hello");

		[Benchmark]
		public Result LiteralConsumeCase1() => Literal.Consume("Hello");

		[Benchmark]
		public Result LiteralConsumeCase2() => Literal.Consume("World");

		[Benchmark]
		public Result LiteralConsumeCase3() => Literal.Consume("H");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("Hello");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("World");

		[Benchmark]
		public Match RegexMatchCase3() => Regex.Match("H");

	}
}
