using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
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
