using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class KleeneClosureBenchmarks {
		public static readonly Regex msregex = new Regex("^(?:Hi!)*");

		public static readonly Regex msregexCompiled = new Regex("^(?:Hi!)*", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^(?:Hi!)*");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^(?:Hi!)*", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Parser.String("Hi!").ManyString();

		public static readonly Sprache.Parser<IEnumerable<String>> sprache = Parse.String("Hi!").Text().Many();

		public static readonly Pattern stringier = Maybe(Many("Hi!"));

		[Params("Hi!", "HiHi!", "Hi!Hi!Hi!", "Okay?")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public Match MSRegexCompiled() => msregexCompiled.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegex() => pcreregex.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegexCompiled() => pcreregexCompiled.Match(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public void Sprache() => sprache.Parse(Source);

		[Benchmark]
		public Stringier.Patterns.Result Stringier() => stringier.Consume(Source);
	}
}
