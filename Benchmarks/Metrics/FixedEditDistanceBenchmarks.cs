using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Stringier.Metrics;

namespace Benchmarks.Metrics {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class FixedEditDistanceBenchmarks {

		[Params("ram")]
		public String Source { get; set; }

		[Params("ram", "rom", "rob", "bob")]
		public String Other { get; set; }

		[Benchmark]
		public Int32 Hamming() => HammingDistance(Source, Other);

		[Benchmark]
		public Int32 Levenshtein() => LevenshteinDistance(Source, Other);
	}
}
