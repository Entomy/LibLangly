using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.ValueStrings {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class ConstructorBenchmarks {
		[Params(new Char[] { }, new Char[] { 'h', 'e', 'l', 'l', 'o' }, new Char[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' })]
		public Char[] Source { get; set; }

		[Benchmark]
		public void String() => new String(Source);

		[Benchmark]
		public void ValueString() => new ValueString(Source);
	}
}
