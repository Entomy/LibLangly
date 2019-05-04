using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class CombinatorComparison {

		Combinator Combinator = (Literal)"Hello" & "World";

		Regex Regex = new Regex("^(Hello)(World)");

		[Benchmark]
		public Result CombinatorConsumeCase1() => Combinator.Consume("HelloWorld");

		[Benchmark]
		public Result CombinatorConsumeCase2() => Combinator.Consume("Hello");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("HelloWorld");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Hello");

	}
}
