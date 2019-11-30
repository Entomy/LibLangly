using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using Stringier;
using Stringier.Patterns;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class IdentifierBenchmarks {
		readonly Regex msregex = new Regex("\\w(?:\\w|_)+", RegexOptions.IgnoreCase);

		readonly PcreRegex pcreregex = new PcreRegex("\\w(?:\\w|_)+", PcreOptions.IgnoreCase);

		readonly Parser<Char, String> pidgin =
			Letter
			.Then(Letter.Or(Char('_')).ManyString())
			.Then(Try(Letter.Or(Char('_'))).OfType<String>());

		readonly Pattern stringier = Pattern.Check(nameof(stringier),
			(Char) => Char.IsLetter(), true,
			(Char) => Char.IsLetter() || Char == '_', true,
			(Char) => Char.IsLetter() || Char == '_', false);

		[Params("Hello_World")]
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
