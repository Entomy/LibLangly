using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks {
	[SimpleJob(RuntimeMoniker.NetCoreApp31)]
	[SimpleJob(RuntimeMoniker.CoreRt31)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class LinesBenchmarks {
		[Benchmark]
		public String[] Lines() => ("Some example text." + Path.DirectorySeparatorChar + "With some line breaks." + Path.DirectorySeparatorChar + "Which should be split up.").Lines();
	}
}
