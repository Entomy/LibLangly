using System;
using System.IO;
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
	public class Utf8Benchmarks {
		private static readonly Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();

		[Params(1024, 512, 256, 128, 64, 32)]
		public Int32 ReductionFactor { get; set; }

		public Byte[] Buffer { get; set; }

		[GlobalSetup]
		public void GlobalSetup() {
			Buffer = Gibberish.GenerateUtf8(ReductionFactor);
		}

		[Benchmark]
		public Rune[] Stringier_Heap() => Utf8.Decode(Buffer);

		[Benchmark]
		public Rune[] Stringier_Stack() => Utf8.Decode(useStack: true, Buffer);

		[Benchmark(Baseline = true)]
		public Rune[] Microsoft() {
			Char[] chars = new Char[Buffer.Length];
			Int32 charsCount = decoder.GetChars(Buffer, 0, Buffer.Length, chars, 0, flush: true);
			String buffer = new String(chars, 0, charsCount);
			return buffer.EnumerateRunes().ToArray();
		}
	}
}
