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
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class StringLiteralBenchmarks {
		readonly Regex msregex = new Regex("^\"(?:\\.|[^\"])*\"");

		readonly PcreRegex pcreregex = new PcreRegex("^\"(?:\\.|[^\"])*\"");

		readonly Parser<Char, String> pidgin = Char('\"').OfType<String>().Then(String("\\\"").Or(Not(Char('\"')).OfType<String>())).Then(Char('\"').OfType<String>());

		readonly Pattern stringier = Pattern.Range('\"', '\"', "\\\"");

		[Params("\"Hello World\"", "\"Hello\\\"World\"")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegex() => pcreregex.Match(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Result Stringier() => stringier.Consume(Source);
	}
}
