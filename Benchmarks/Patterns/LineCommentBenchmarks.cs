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
	public class LineCommentBenchmarks {
		public static readonly Regex msregex = new Regex("^--(?:[^\u000D][^\u000A]|[^\u000A][^\u000D]|[^\u000A]|[^\u000B]|[^\u000C]|[^\u000D]|[^\u0085]|[^\u2028]|[^\u2029])+", RegexOptions.Singleline);

		public static readonly Regex msregexCompiled = new Regex("^--(?:[^\u000D][^\u000A]|[^\u000A][^\u000D]|[^\u000A]|[^\u000B]|[^\u000C]|[^\u000D]|[^\u0085]|[^\u2028]|[^\u2029])+", RegexOptions.Singleline | RegexOptions.Compiled);

		public static readonly PcreRegex pcreregex = new PcreRegex("^--(?:[^\u000D][^\u000A]|[^\u000A][^\u000D]|[^\u000A]|[^\u000B]|[^\u000C]|[^\u000D]|[^\u0085]|[^\u2028]|[^\u2029])+", PcreOptions.Singleline);

		public static readonly PcreRegex pcreregexCompiled = new PcreRegex("^--(?:[^\u000D][^\u000A]|[^\u000A][^\u000D]|[^\u000A]|[^\u000B]|[^\u000C]|[^\u000D]|[^\u0085]|[^\u2028]|[^\u2029])+", PcreOptions.Singleline | PcreOptions.Compiled);

		public static readonly Parser<Char, String> pidgin = Map((start, end) => start + end, String("--"), Not(OneOf(String("\u000D\u000A"), String("\u000A\u000D"), String("\u000A"), String("\u000B"), String("\u000C"), String("\u000D"), String("\u0085"), String("\u2028"), String("\u2029"))));

		public static readonly Pattern stringier = "--".Then(Many(Not(LineTerminator)));

		[Params("--Comment\u2028")] //NEL is chosen instead of other line terminators because it's very unlikely that any system actually handles it, despite it literally being for this exact purpose.
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
