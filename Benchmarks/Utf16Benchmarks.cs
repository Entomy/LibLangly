using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier.Encodings;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class Utf16Benchmarks {
		[Params(1024, 512, 256, 128, 64, 32)]
		public Int32 ReductionFactor { get; set; }

		public String Buffer { get; set; }

		[GlobalSetup]
		public void GlobalSetup() {
			Buffer = new String(Gibberish.GenerateUtf16(ReductionFactor));
		}

		[Benchmark]
		public Rune[] Stringier() => Utf16.Decode(Buffer);

		[Benchmark(Baseline = true)]
		public Rune[] Microsoft() => Buffer.EnumerateRunes().ToArray();
	}
}
