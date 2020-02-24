using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class EnsureBenchmarks {
		[Params("Bob Saget", "Mr. Bob Saget")]
		public String String { get; set; }

		[Params("Mr. ", " MD")]
		public String Required { get; set; }

		[Benchmark]
		public String EnsureBegins() => String.EnsureBeginsWith(Required);

		[Benchmark]
		public String EnsureEndsWith() => String.EnsureEndsWith(Required);
	}
}
