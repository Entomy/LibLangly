using System;
using BenchmarkDotNet.Running;

namespace Benchmarks {
	static class Program {
		static void Main() {
			BenchmarkRunner.Run<AlternatorComparison>();
			BenchmarkRunner.Run<CombinatorComparison>();
			BenchmarkRunner.Run<LiteralComparison>();
			BenchmarkRunner.Run<NegatorComparison>();
			BenchmarkRunner.Run<OptorComparison>();
			BenchmarkRunner.Run<RangerComparison>();
			BenchmarkRunner.Run<RepeaterComparison>();
			BenchmarkRunner.Run<SpannerComparison>();
		}
	}
}
