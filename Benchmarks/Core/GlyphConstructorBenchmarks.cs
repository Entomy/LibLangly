using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Core {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class GlyphConstructorBenchmarks {
		[Params("a", "\u00E1", "\u0041\u0301")]
		public String Glyph_Sequence { get; set; }

		[Benchmark]
		public Glyph Constructor_Char() => new Glyph('a');

		[Benchmark]
		public Glyph Constructor_String() => new Glyph(Glyph_Sequence);
	}
}
