using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class RangeComparison {

		RangePattern Range = new RangePattern("Hello", ";");

		RangePattern RangePattern = new RangePattern("Hello", ';');

		Regex Regex = new Regex("^Hello.*;$");

		[Benchmark]
		public Result RangeConsumeCase1() => Range.Consume("Hello World;");

		[Benchmark]
		public Match RegexMatchCase1() => Regex.Match("Hello World;");

		[Benchmark]
		public Result RangeConsumeCase2() => Range.Consume("Hello World");

		[Benchmark]
		public Match RegexMatchCase2() => Regex.Match("Hello World");

		[Benchmark]
		public Result RangeConsumeCase3() => Range.Consume("Goodbye World;");

		[Benchmark]
		public Match RegexMatchCase3() => Regex.Match("Goodbye World;");

	}
}
