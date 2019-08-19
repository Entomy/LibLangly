using System;
using System.Text.Patterns;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class StringComparison {
		[Benchmark]
		public Boolean StringEqualsCase1() => String.Equals("Hello", "Hello");

		[Benchmark]
		public Boolean StringEqualsCase2() => String.Equals("Hello", "World");

		[Benchmark]
		public Boolean StringEqualsCase3() => String.Equals("Hello", "H");

		[Benchmark]
		public Boolean StringEqualsCase4() => "Hello"[0].Equals('H');
	}
}
