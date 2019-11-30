using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class LinesBenchmarks {
		[Benchmark]
		public String[] Lines() => ("Some example text." + Path.DirectorySeparatorChar + "With some line breaks." + Path.DirectorySeparatorChar + "Which should be split up.").Lines();
	}
}
