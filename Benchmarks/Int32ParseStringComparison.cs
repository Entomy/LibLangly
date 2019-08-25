using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class Int32ParseStringComparison {

		[Params("1", "42", "1337", "1234567890")]
		public String String { get; set; }

		[Benchmark(Baseline = true)]
		public Int32 Int32Parse() => Int32.Parse(String);

		[Benchmark]
		public Int32 ParseInt32() => String.ParseInt32();
	}
}
