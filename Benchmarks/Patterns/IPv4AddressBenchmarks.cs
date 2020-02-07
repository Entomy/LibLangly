using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using Stringier.Patterns;

namespace Benchmarks.Patterns {
#if NETFRAMEWORK
	[SimpleJob(RuntimeMoniker.Net48)]
#endif
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	[SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Oh ffs Sonar, IPv4 is a very well known tech thing.")]
	public class IPv4AddressBenchmarks {
		public static readonly Regex msregex = new Regex("^[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}");

		public static readonly Regex msregexCompiled = new Regex("^[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}", RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}");

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}.[012]?[0-9]{1,2}", PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidginDigit = 
			Try(OneOf('0', '1', '2'))
			.Then(Try(Digit).OfType<String>())
			.Then(Digit.OfType<String>());
		public static readonly Parser<Char, String> pidgin = pidginDigit.Then(Char('.')).Then(pidginDigit).Then(Char('.')).Then(pidginDigit).Then(Char('.')).Then(pidginDigit);

		public static readonly Pattern stringierDigit = Pattern.Check(nameof(stringierDigit),
			(Char) => '0' <= Char && Char <= '2', false,
			(Char) => '0' <= Char && Char <= '9', false,
			(Char) => '0' <= Char && Char <= '9', true);
		public static readonly Pattern stringier = stringierDigit.Then(".").Then(stringierDigit).Then(".").Then(stringierDigit).Then(".").Then(stringierDigit);

		[Params("192.168.1.1")]
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
