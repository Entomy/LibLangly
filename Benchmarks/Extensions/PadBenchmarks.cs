using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class PadBenchmarks {
		[Params("hello")]
		public String String { get; set; }

		[Params(4, 10)]
		public Int32 Size { get; set; }

		[Benchmark]
		public String Pad() => String.Pad(Size);

		[Benchmark]
		public String PadWith() => String.Pad(Size, '-');
	}
}
