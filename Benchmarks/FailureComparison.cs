using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class FailureComparison {

		readonly static Pattern pattern = Pattern.Number * 3 & '-' & Pattern.Number * 3 & '-' & Pattern.Number * 4;

		[Benchmark]
		public Result PatternFail() => pattern.Consume("555-555-Narwhal");

		readonly static Regex regex = new Regex(@"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase);

		[Benchmark]

		public Match RegexFail() => regex.Match("555-555-Narwhal");
	}
}
