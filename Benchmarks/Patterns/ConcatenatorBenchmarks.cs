using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier.Patterns;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class ConcatenatorBenchmarks {
		readonly Regex msregex = new Regex("^Hello World");

		readonly Regex msregexCompiled = new Regex("^Hello World", RegexOptions.Compiled);

		readonly PcreRegex pcreregex = new PcreRegex("^Hello World");

		readonly PcreRegex pcreregexCompiled = new PcreRegex("^Hello World", PcreOptions.Compiled);

		readonly Parser<Char, String> pidgin = Parser.String("Hello").Then(Parser.Char(' ')).Then(Parser.String("World"));

		readonly Sprache.Parser<String> sprache = Parse.String("Hello").Then(_ => Parse.Char(' ')).Then(_ => Parse.String("World")).Text();

		readonly Pattern stringier = "Hello".Then(' ').Then("World");

		[Params("Hello World", "Hello", "Failure")]
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
		public String Sprache() => sprache.Parse(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Stringier.Patterns.Result Stringier() => stringier.Consume(Source);
	}
}
