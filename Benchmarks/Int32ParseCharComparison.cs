using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class Int32ParseCharComparison {

		[Params('1', '2', '3', '4', '5', '6', '7', '8', '9', '0')]
		public Char Char { get; set; }

		[Benchmark(Baseline = true)]
		public Int32 Int32Parse() => Int32.Parse(Char.ToString());

		[Benchmark]
		public Int32 ParseInt32() => Char.ParseInt32();
	}
}
