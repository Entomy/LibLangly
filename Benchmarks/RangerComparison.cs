using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class RangerComparison {

		Pattern Ranger = ("Hello", ";");

		Regex Regex = new Regex("^Hello.*;$");

		[Benchmark]
		public Result RangerConsumeCase1() => Ranger.Consume("Hello World;");

		[Benchmark]
		public Result RangerConsumeCase2() => Ranger.Consume("Hello World");

		[Benchmark]
		public Result RangerConsumeCase3() => Ranger.Consume("Goodbye World;");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("Hello World;");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Hello World");

		[Benchmark]
		public Match RegexMatchCase3() => Regex.Match("Goodbye World;");

	}
}
