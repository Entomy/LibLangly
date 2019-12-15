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
	public class SpannerBenchmarks {

		readonly Regex msregex = new Regex("^(?:Hi!)+");

		readonly Regex msregexCompiled = new Regex("^(?:Hi!)+", RegexOptions.Compiled);

		readonly PcreRegex pcreregex = new PcreRegex("^(?:Hi!)+");

		readonly PcreRegex pcreregexCompiled = new PcreRegex("^(?:Hi!)+", PcreOptions.Compiled);

		readonly Parser<Char, String> pidgin = String("Hi!").AtLeastOnceString();

		readonly Pattern stringier = Many("Hi!");

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
		public Result Stringier() => stringier.Consume(Source);
	}
}
