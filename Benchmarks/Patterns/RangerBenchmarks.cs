using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using Stringier.Patterns;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class RangerBenchmarks {

		readonly Regex msregex = new Regex("^Hello.*;$");

		readonly Parser<Char, String> pidgin = Map((start, between, end) => start + between + end, String("Hello"), Not(Char(';')), Char(';'));

		readonly Pattern stringier = Pattern.Range("Hello", ";");

		[Params("Hello World;", "Hello World", "Goodbye World;")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Result Stringier() => stringier.Consume(Source);
	}
}
