using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Core {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class GlyphGetGlyphAtBenchmarks {
		[Params("aa", "a\u00E1", "a\u0041\u0301")]
		public String Source { get; set; }

		[Params(0, 1)]
		public Int32 Index { get; set; }

		[Benchmark]
		public Glyph GetGlyphAt() => Glyph.GetGlyphAt(Source, Index, out Int32 _);
	}
}
