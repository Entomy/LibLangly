using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class FuzzerBenchmarks {
		public static readonly Pattern literal = "bob";

		public static readonly Pattern fuzzer = Fuzzy("bob");

		[Params("bob", "mob", "mom")]
		public String Source { get; set; }

		[Benchmark(Baseline = true)]
		public Result Literal() => literal.Consume(Source);

		[Benchmark]
		public Result Fuzzer() => fuzzer.Consume(Source);
	}
}
