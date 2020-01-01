using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class IsPalindromeBenchmarks {
		[Params("hello", "detartrated", "Malayalam")]
		public String String { get; set; }

		[Benchmark]
		public Boolean String_IsPalindrome() => String.IsPalindrome();

		[Benchmark]
		public Boolean Span_IsPalindrome() => String.AsSpan().IsPalindrome();
	}
}
