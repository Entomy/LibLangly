using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
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
