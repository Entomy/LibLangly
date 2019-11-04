using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class ContainsCharStringBenchmarks {
		[Params('a', 'g', 'i')]
		public Char Char { get; set; }

		[Params("apple", "hello")]
		public String String { get; set; }

		[Benchmark]
		public Boolean Contains() => String.Contains(Char);
	}

	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class ContainsCharIEnumerableBenchmarks {
		[Params('a', 'g', 'i')]
		public Char Char { get; set; }

		public String[] Array = new String[] { "ab", "cd", "ef", "gh" };

		[Benchmark]
		public Boolean Contains() => Array.Contains(Char);
	}

	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class ContainsStringIEnumerableBenchmarks {
		[Params("cd", "de")]
		public String String { get; set; }

		public String[] Array = new String[] { "ab", "cd", "ef", "gh" };

		[Benchmark]
		public Boolean Contains() => Array.Contains(String);
	}
}
