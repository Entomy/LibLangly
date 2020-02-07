using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using Stringier.Patterns;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class StringLiteralBenchmarks {
		public static readonly Regex msregex = new Regex("^\"(?:\\.|[^\"])*\"");

		public static readonly Regex msregexCompiled = new Regex("^\"(?:\\.|[^\"])*\"", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^\"(?:\\.|[^\"])*\"");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^\"(?:\\.|[^\"])*\"", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Char('\"').OfType<String>().Then(String("\\\"").Or(Not(Char('\"')).OfType<String>())).Then(Char('\"').OfType<String>());

		public static readonly Pattern stringier = Pattern.Range('\"', '\"', "\\\"");

		[Params("\"Hello World\"", "\"Hello\\\"World\"")]
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
