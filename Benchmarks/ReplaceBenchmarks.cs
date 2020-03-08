using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class ReplaceBenchmarks {
		[Benchmark]
		public String CharChar() => "hello".Replace('h', 'j');

		[Benchmark]
		public String CharCharMap1() => "hello".Replace(('h', 'j'));

		[Benchmark]
		public String CharCharMap2() => "hello".Replace(('h', 'z'), ('e', 'i'));

		[Benchmark]
		public String CharCharMapArray() => "world".Replace(('w', 'b'), ('o', 'a'), ('r', 'c'), ('l', 'o'), ('d', 'n'));
	}
}
