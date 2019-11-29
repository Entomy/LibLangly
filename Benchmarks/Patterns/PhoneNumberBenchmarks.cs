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
	public class PhoneNumberBenchmarks {
		readonly Regex msregex = new Regex(@"\d{3}-\d{3}-\d{4}");

		readonly PcreRegex pcreregex = new PcreRegex(@"\d{3}-\d{3}-\d{4}");

		readonly Parser<Char, String> pidgin = Digit.RepeatString(3).Then(Char('-')).Then(Digit.RepeatString(3)).Then(Char('-')).Then(Digit.RepeatString(4));

		readonly Pattern stringier = (Pattern.DecimalDigitNumber * 3) & '-' & (Pattern.DecimalDigitNumber * 3) & '-' & (Pattern.DecimalDigitNumber * 4);

		[Params("555-555-5555")]
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
