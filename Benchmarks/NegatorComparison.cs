using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class NegatorComparison {

		Pattern Negator = !(Pattern)"Hello";

		Regex Regex = new Regex("^[^H][^e][^l][^l][^o]");

		[Benchmark]
		public Result NegatorConsumeCase1() => Negator.Consume("World");

		[Benchmark]
		public Result NegatorConsumeCase2() => Negator.Consume("Hello");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("World");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Hello");

	}
}
