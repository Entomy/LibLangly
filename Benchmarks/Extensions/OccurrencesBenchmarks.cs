using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class OccurrencesBenchmarks {
		[Benchmark]
		public Int32 OccurrencesCharString() => "hello".Occurrences('l');

		[Benchmark]
		public Int32 OccurrencesArrayString() => "hello".Occurrences('e', 'o');

		[Benchmark]
		public Int32 OccurrencesArrayArray() => new String[] { "hello", "world", "how", "are", "you", "today?" }.Occurrences('e', 'o');
	}
}
