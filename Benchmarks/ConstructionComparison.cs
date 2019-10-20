using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class ConstructionComparison {

		[Benchmark]
		public Pattern StringierLiteral() => "Hello";

		[Benchmark]
		public Pattern StringierComplex() => Pattern.Number * 3 & '-' & Pattern.Number * 3 & '-' & Pattern.Number * 4;

		[Benchmark]
		public Regex MSRegexLiteral() => new Regex("Hello", RegexOptions.IgnoreCase);

		[Benchmark]
		public Regex MSRegexComplex() => new Regex(@"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase);

	}
}
