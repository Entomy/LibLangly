using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class Int32ParseStringComparison {

		String Value = "543789345";

		[Benchmark]
		public Int32 Int32Parse() => Int32.Parse(Value);

		[Benchmark]
		public Int32 ParseInt32() => Value.ParseInt32();
	}
}
