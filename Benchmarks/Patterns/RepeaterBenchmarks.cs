using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
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
	public class RepeaterBenchmarks {

		readonly Regex msregex = new Regex("^(?:Hi!){5}");

		readonly Regex msregexCompiled = new Regex("^(?:Hi!){5}", RegexOptions.Compiled);

		readonly PcreRegex pcreregex = new PcreRegex("^(?:Hi!){5}");

		readonly PcreRegex pcreregexCompiled = new PcreRegex("^(?:Hi!){5}", PcreOptions.Compiled);

		readonly Parser<Char, IEnumerable<String>> pidgin = String("Hi!").Repeat(5);

		readonly Pattern stringier = "Hi!".Repeat(5);

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
		public Result Stringier() => stringier.Consume(Source);
	}
}
