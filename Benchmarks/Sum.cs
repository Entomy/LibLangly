using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Collectathon.Arrays;
using Numbersome;

namespace Langly {
	[SimpleJob(RuntimeMoniker.Net50)]
	[MemoryDiagnoser]
	public class Sum {
		private readonly BoundedArray<Byte> @byte = new Byte[] { 1, 2, 3, 4, 5 };

		private readonly BoundedArray<Double> @double = new Double[] { 1.0, 2.0, 3.0, 4.0, 5.0 };

		private readonly BoundedArray<Int32> int32 = new Int32[] { 1, 2, 3, 4, 5 };

		private readonly BoundedArray<Single> single = new Single[] { 1f, 2f, 3f, 4f, 5f };

		[Benchmark]
		public void Byte() => @byte.Sum();

		[Benchmark]
		public void Double() => @double.Sum();

		[Benchmark]
		public void Int32() => int32.Sum();

		[Benchmark]
		public void Single() => single.Sum();
	}
}
