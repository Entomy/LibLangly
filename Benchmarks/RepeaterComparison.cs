using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class RepeaterComparison {

		Repeater Repeater = (Literal)"Hi!" * 2;

		Regex Regex = new Regex("^(Hi!){2}");

		[Benchmark]
		public Result RepeaterConsume() => Repeater.Consume("Hi!Hi!");

		[Benchmark]
		public Match RegexMatch() => Regex.Match("Hi!Hi!");

	}
}
