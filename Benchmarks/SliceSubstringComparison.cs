using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class SliceSubstringComparison {

		[Benchmark]
		public String Slice() => "Hello World"[3..7];

		[Benchmark(Baseline = true)]
		public String Substring() => "Hello World".Substring(3, 5);

	}
}
