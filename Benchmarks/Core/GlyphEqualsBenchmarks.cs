using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Core {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class GlyphEqualsBenchmarks {
		[Params("a", "\u00E1", "\u0041\u0301")]
		public String First { get; set; }

		[Params("a", "\u00E1", "\u0041\u0301")]
		public String Second { get; set; }


		[Benchmark]
		public Boolean Equals() => new Glyph(First).Equals(new Glyph(Second));
	}
}
