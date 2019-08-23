using System;
using BenchmarkDotNet.Running;

namespace Benchmarks {
	static class Program {
		static void Main() {
			BenchmarkRunner.Run<Int32ParseCharComparison>();
			BenchmarkRunner.Run<Int32ParseStringComparison>();
			BenchmarkRunner.Run<AlternatorComparison>();
			BenchmarkRunner.Run<ConcatenatorComparison>();
			BenchmarkRunner.Run<CompoundPatternComparison>();
			BenchmarkRunner.Run<LiteralComparison>();
			BenchmarkRunner.Run<NegatorComparison>();
			BenchmarkRunner.Run<OptorComparison>();
			BenchmarkRunner.Run<RangeComparison>();
			BenchmarkRunner.Run<RepeaterComparison>();
			BenchmarkRunner.Run<SpannerComparison>();
			BenchmarkRunner.Run<StringComparison>();
		}
	}
}
