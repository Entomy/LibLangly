using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Core {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class GlyphSplitBenchmarks {
		[Params("aa", "a\u00E1", "a\u0041\u0301")]
		public String Source { get; set; }

		[Benchmark]
		public Glyph[] Split() => Glyph.Split(Source);
	}
}
