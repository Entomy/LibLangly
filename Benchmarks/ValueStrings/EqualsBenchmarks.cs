using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.ValueStrings {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class EqualsBenchmarks {
		[Params(new Char[] { }, new Char[] { 'h', 'e', 'l', 'l', 'o' }, new Char[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' })]
		public Char[] Source { get; set; }

		[Params(new Char[] { }, new Char[] { 'h', 'e', 'l', 'l', 'o' }, new Char[] { 'h', 'e', 'l', 'l', 'o', ' ', 'w', 'o', 'r', 'l', 'd' })]
		public Char[] Other { get; set; }

		public String StrSrc { get; set; }

		public String StrOth { get; set; }

		[GlobalSetup]
		public void GlobalSetup() {
			StrSrc = new String(Source);
			StrOth = new String(Other);
		}

		[Benchmark]
		public void String() => StrSrc.Equals(StrOth);

		[Benchmark]
		public void ValueString() => new ValueString(Source).Equals(new ValueString(Other));
	}
}
