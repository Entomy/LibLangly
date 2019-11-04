using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier.Patterns;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class SourceConstruction {
		[Benchmark]
		public Source SourceFromString() => new Source("Hello");

		[Benchmark]
		public Source SourceFromStringPreconvert() => new Source("Hello", true);
	}
}
