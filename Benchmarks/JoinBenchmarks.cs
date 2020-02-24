using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class JoinBenchmarks {
		[Benchmark]
		public String JoinChars() => new Char[] { 'a', 'b', 'c', 'd' }.Join();

		[Benchmark]
		public String JoinStrings() => new String[] { "This", "Winds", "Up", "Camel", "Case" }.Join();

		[Benchmark]
		public String JoinCharsWithChar() => new Char[] { 'a', 'b', 'c', 'd' }.Join('-');

		[Benchmark]
		public String JoinStringsWithChar() => new String[] { "This", "Winds", "Up", "Kebab", "Case" }.Join('-');
	}
}
