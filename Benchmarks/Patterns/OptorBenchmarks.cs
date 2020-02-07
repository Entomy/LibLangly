using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class OptorBenchmarks {
		public static readonly Regex msregex = new Regex("^(?:Hello)?");

		public static readonly Regex msregexCompiled = new Regex("^(?:Hello)?", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^(?:Hello)?");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^(?:Hello)?", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Parser.Try(Parser.String("Hello"));

		public static readonly Sprache.Parser<IOption<String>> sprache = Parse.Optional(Parse.String("Hello").Text());

		public static readonly Pattern stringier = Maybe("Hello");

		[Params("Hello", "World")]
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
		public String Sprache() => sprache.Parse(Source).GetOrElse("");

		[Benchmark]
		public Stringier.Patterns.Result Stringier() => stringier.Consume(Source);
	}
}
