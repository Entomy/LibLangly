using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class StringCultureComparison {

		[Params("encyclopaedia")]
		public String A { get; set; }

		[Params("encyclopaedia", "encyclopædia", "encyclopedia")]
		public String B { get; set; }

		[Benchmark(Baseline = true)]
		public Boolean OrdinalEquals() => String.Equals(A, B, StringComparison.Ordinal);

		[Benchmark]
		public Boolean InvariantEquals() => String.Equals(A, B, StringComparison.InvariantCulture);

		[Benchmark]
		public Boolean CurrentCultureEquals() => String.Equals(A, B, StringComparison.CurrentCulture);
	}
}