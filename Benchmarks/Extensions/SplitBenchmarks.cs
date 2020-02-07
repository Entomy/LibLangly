using System;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Stringier;

namespace Benchmarks.Extensions {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	public class SplitBenchmarks {
		[Benchmark]
		public String[] SplitChar() => "commma,separated,values".Split(',');

		[Benchmark]
		public String[] SplitString() => "comma, separated, values, 1,300".Split(", ");

		[SuppressMessage("Minor Bug", "S3220:Review this call, which partially matches an overload without 'params'.", Justification = "Sonar claims \"The rules for method resolution are complex, and perhaps not properly understood by all coders...\". The irony of this is that the method Sonar beleives might be confused here could never possibly be. The method they suspect is a static method belonging to a static class, who's first parameter is a Char. Our first parameter is a 'this String', and belongs to an entirely different static class, and has entirely different parameters. These are not alike for so many reasons, and hilariously means Sonar is the one who doesn't understand the very rule they are complaining about here.")]
		[Benchmark]
		public String[] SplitArray() => "comma,or;semicolon;separated,values".Split(',', ';');
	}
}
