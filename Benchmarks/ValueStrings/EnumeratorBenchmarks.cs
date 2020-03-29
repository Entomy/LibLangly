using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.ValueStrings {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class EnumeratorBenchmarks {
		[Params(new Char[] { }, new Char[] { 'h', 'e', 'l', 'l', 'o' }, new Char[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' })]
		public Char[] Source { get; set; }

		public String StrSrc { get; set; }

		[GlobalSetup]
		public void GlobalSetup() {
			StrSrc = new String(Source);
		}

		[Benchmark]
		public void String() {
			foreach (Char @char in StrSrc) {
				//
			}
		}

		[Benchmark]
		public void ValueString() {
			foreach (Char @char in Source) {
				//
			}
		}
	}
}
