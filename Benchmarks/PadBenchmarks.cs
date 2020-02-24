using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
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
