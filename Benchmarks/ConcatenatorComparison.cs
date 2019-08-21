using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class ConcatenatorComparison {

		Pattern Concatenator = (Pattern)"Hello" & "World";

		Regex Regex = new Regex("^(Hello)(World)");

		[Benchmark]
		public Result ConcatenatorConsumeCase1() => Concatenator.Consume("HelloWorld");

		[Benchmark]
		public Result ConcatenatorConsumeCase2() => Concatenator.Consume("Hello");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("HelloWorld");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Hello");

	}
}
