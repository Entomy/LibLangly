using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class SplitBenchmarks {
		[Benchmark]
		public String[] SplitChar() => "commma,separated,values".Split(',');

		[Benchmark]
		public String[] SplitString() => "comma, separated, values, 1,300".Split(", ");

		[Benchmark]
		public String[] SplitArray() => "comma,or;semicolon;separated,values".Split(',', ';');
	}
}
