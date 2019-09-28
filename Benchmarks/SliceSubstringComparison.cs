using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class SliceSubstringComparison {
#if !NET48
		[Benchmark]
		public String Slice() => "Hello World"[3..7];
#endif

		[Benchmark(Baseline = true)]
		public String Substring() => "Hello World".Substring(3, 5);

	}
}
