using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using static Stringier.Metrics;

namespace Benchmarks.Algorithms {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class FixedEditDistanceBenchmarks {
		[Params("ram", "rám")]
		public String Source { get; set; }

		[Params("ram", "rom", "rob", "bob")]
		public String Other { get; set; }

		[Benchmark]
		public Int32 Hamming_GraphemeWise() => HammingDistance(Source, Other);

		[Benchmark]
		public Int32 Hamming_CharacterWise() => HammingDistance(Source.AsSpan(), Other.AsSpan());

		[Benchmark]
		public Int32 Levenshtein_GraphemeWise() => LevenshteinDistance(Source, Other);

		[Benchmark]
		public Int32 Levenshtein_CharacterWise() => LevenshteinDistance(Source.AsSpan(), Other.AsSpan());
	}
}
