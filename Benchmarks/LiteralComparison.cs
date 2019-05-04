using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class LiteralComparison {

		Literal Literal = "Hello";

		Regex Regex = new Regex("^Hello");

		[Benchmark]
		public Result LiteralConsume() => Literal.Consume("Hello");

		[Benchmark]
		public Match RegexMatch() => Regex.Match("Hello");

	}
}
