using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier.Patterns;

namespace Benchmarks.Patterns {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class RepeaterBenchmarks {

		public static readonly Regex msregex = new Regex("^(?:Hi!){5}");

		public static readonly Regex msregexCompiled = new Regex("^(?:Hi!){5}", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^(?:Hi!){5}");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^(?:Hi!){5}", PcreOptions.Compiled);

		public static readonly Parser<Char, IEnumerable<String>> pidgin = Parser.String("Hi!").Repeat(5);

		public static readonly Sprache.Parser<IEnumerable<String>> sprache = Parse.String("Hi!").Text().Repeat(5);

		public static readonly Pattern stringier = "Hi!".Repeat(5);

		[Params("Hi!", "Hi!Hi!Hi!Hi!Hi!")]
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
		public Result<Char, IEnumerable<String>> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public IEnumerable<String> Sprache() => sprache.Parse(Source);

		[Benchmark]
		public Stringier.Patterns.Result Stringier() => stringier.Consume(Source);
	}
}
