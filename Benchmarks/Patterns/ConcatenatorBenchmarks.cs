using System;
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
	public class ConcatenatorBenchmarks {
		readonly Regex msregex = new Regex("^Hello World");

		readonly Parser<Char, String> pidgin = Map((first, second, third) => first + second + third, String("Hello"), Char(' '), String("Hello"));

		readonly Pattern stringier = (Pattern)"Hello" & ' ' & "World";

		[Params("Hello World", "Hello", "Failure")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Result Stringier() => stringier.Consume(Source);
	}
}
