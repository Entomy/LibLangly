using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class ConstructionComparison {

		[Benchmark]
		public Pattern PatternLiteral() => "Hello";

		[Benchmark]
		public Pattern PatternComplex() => Pattern.Number * 3 & '-' & Pattern.Number * 3 & '-' & Pattern.Number * 4;

		[Benchmark]
		public Regex RegexLiteral() => new Regex("Hello", RegexOptions.IgnoreCase);

		[Benchmark]
		public Regex RegexComplex() => new Regex(@"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase);

	}
}
