using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class NegatorComparison {

		// This isn't exactly a token negation, but is as close as you're gonna get from Regex
		readonly Regex msregex = new Regex("^[^H][^e][^l][^l][^o]");

		// This isn't exactly a token negation, but is as close as you're gonna get from Regex
		readonly PcreRegex pcreregex = new PcreRegex("^[^H][^e][^l][^l][^o]");

		readonly Parser<Char, Unit> pidgin = Not(String("Hello"));

		readonly Pattern stringier = Not("Hello");

		[Params("World", "H", "Hello")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegex() => pcreregex.Match(Source);

		[Benchmark]
		public Result<Char, Unit> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Result Stringier() => stringier.Consume(Source);
	}
}
