using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Collections {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class StringBuilderBenchmarks {
		[Params(0,1,2,3,4,5,6,7,8,9,10,20,30,40,50)]
		public Int32 Count { get; set; }

		[Benchmark]
		public void MSBuilderConstruct() {
			StringBuilder msbuilder = new StringBuilder();
		}

		[Benchmark]
		public void StringierConstruct() {
			Stringier.Collections.StringBuilder stringbuilder = new Stringier.Collections.StringBuilder();
		}

		[Benchmark]
		public void MSBuilderAppend() {
			StringBuilder msbuilder = new StringBuilder();
			for (Int32 i = Count; i --> 0;) {
				_ = msbuilder.Append("hello");
			}
		}

		[Benchmark]
		public void StringierAppend() {
			Stringier.Collections.StringBuilder stringbuilder = new Stringier.Collections.StringBuilder();
			for (Int32 i = Count; i --> 0;) {
				_ = stringbuilder.Append("hello");
			}
		}

		[Benchmark]
		public String MSBuilderToString() {
			StringBuilder msbuilder = new StringBuilder();
			for (Int32 i = Count; i --> 0;) {
				_ = msbuilder.Append("hello");
			}
			return msbuilder.ToString();
		}

		[Benchmark]
		public String StringierToString() {
			Stringier.Collections.StringBuilder stringbuilder = new Stringier.Collections.StringBuilder();
			for (Int32 i = Count; i --> 0;) {
				_ = stringbuilder.Append("hello");
			}
			return stringbuilder.ToString();
		}
	}
}
