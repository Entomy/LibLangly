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
	public class IPv4AddressBenchmarks {
		readonly Regex msregex = new Regex(@"[012]?\d{1,2}.[012]?\d{1,2}.[012]?\d{1,2}.[012]?\d{1,2}");

		readonly PcreRegex pcreregex = new PcreRegex(@"[012]?\d{1,2}.[012]?\d{1,2}.[012]?\d{1,2}.[012]?\d{1,2}");

		readonly static Parser<Char, String> pidginDigit = 
			Try(OneOf('0', '1', '2'))
			.Then(Try(Digit).OfType<String>())
			.Then(Digit.OfType<String>());
		readonly Parser<Char, String> pidgin = pidginDigit.Then(Char('.')).Then(pidginDigit).Then(Char('.')).Then(pidginDigit).Then(Char('.')).Then(pidginDigit);

		readonly static Pattern stringierDigit = Pattern.Check(nameof(stringierDigit),
			(Char) => '0' <= Char && Char <= '2', false,
			(Char) => '0' <= Char && Char <= '9', false,
			(Char) => '0' <= Char && Char <= '9', true);
		readonly Pattern stringier = stringierDigit.Then(".").Then(stringierDigit).Then(".").Then(stringierDigit).Then(".").Then(stringierDigit);

		[Params("192.168.1.1")]
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
