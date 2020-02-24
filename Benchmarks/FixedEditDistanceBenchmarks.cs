using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Stringier.Metrics;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class FixedEditDistanceBenchmarks {
		[Params("ram", "rám")]
		public String Source { get; set; }

		[Params("ram", "rom", "rob", "bob")]
		public String Other { get; set; }

		[Benchmark]
		public Int32 Hamming_GraphemeWise() => HammingDistance(Source.Normalize(), Other.Normalize());

		[Benchmark]
		public Int32 Hamming_CharacterWise() => HammingDistance(Source.Normalize().AsSpan(), Other.Normalize().AsSpan());

		[Benchmark]
		public Int32 Levenshtein_GraphemeWise() => LevenshteinDistance(Source.Normalize(), Other.Normalize());

		[Benchmark]
		public Int32 Levenshtein_CharacterWise() => LevenshteinDistance(Source.Normalize().AsSpan(), Other.Normalize().AsSpan());
	}
}
