using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class Int32ParseCharComparison {

		Char Value = '5';

		[Benchmark]
		public Int32 Int32Parse() => Int32.Parse(Value.ToString());

		[Benchmark]
		public Int32 ParseInt32() => Value.ParseInt32();
	}
}
