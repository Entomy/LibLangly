using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier.Patterns;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[MemoryDiagnoser]
	public class StringEquality {
		public readonly String StringA = "Hello";

		public readonly String StringB = "Hello";

		public readonly String StringC = "World";

		[Benchmark(Baseline = true)]
		public Boolean NETEqualsPassing() => String.Equals(StringA, StringB, StringComparison.Ordinal);

		[Benchmark]
		public Boolean NETEqualsFailing() => String.Equals(StringA, StringC, StringComparison.Ordinal);

		[Benchmark]
		public Boolean StringierEqualsPassing() => Stringier.Patterns.Stringier.Equals(StringA, StringB);

		[Benchmark]
		public Boolean StringierEqualsFailing() => Stringier.Patterns.Stringier.Equals(StringA, StringC);
	}
}
