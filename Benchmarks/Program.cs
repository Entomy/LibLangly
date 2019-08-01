using System;
using BenchmarkDotNet.Running;

namespace Benchmarks {
	class Program {
		static void Main() {
			BenchmarkRunner.Run<AlternatorComparison>();
			BenchmarkRunner.Run<CombinatorComparison>();
			BenchmarkRunner.Run<LiteralComparison>();
			BenchmarkRunner.Run<OptorComparison>();
			BenchmarkRunner.Run<RepeaterComparison>();
			BenchmarkRunner.Run<SpannerComparison>();
		}
	}
}
