using System;
using System.Text.Patterns;
using System.Text.Patterns.Unsafe.InPlace;
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
		public Pattern StringierUnsafeComplex() {
			Pattern Result = Pattern.Number * 3;
			Result.Concatenate('-').Concatenate(Pattern.Number * 3).Concatenate('-').Concatenate(Pattern.Number * 4);
			return Result;
		}

		[Benchmark]
		public Regex MSRegexLiteral() => new Regex("Hello", RegexOptions.IgnoreCase);

		[Benchmark]
		public Regex MSRegexComplex() => new Regex(@"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase);

	}
}
