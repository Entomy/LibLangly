using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using Sprache;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class NegatorComparison {

		//! Since what is being compared here has been misunderstood, let me explain exactly what is going on and why the comparisons are set up the way they are. Firstly, this isn't something Regex can do, so don't take their results too seriously. A negating parser matches and consumes anything not the pattern. Matches and consumes. And. The closest you can get in Regex to this is to negate each individual character. A negative lookahead has been suggested a few times here, but a lookahead only matches, it does not consume, which is far different behavior. Again, do not take the Regex results very seriously.

		// This isn't exactly a token negation, but is as close as you're gonna get from Regex
		readonly Regex msregex = new Regex("^[^H][^e][^l][^l][^o]");

		// This isn't exactly a token negation, but is as close as you're gonna get from Regex
		readonly Regex msregexCompiled = new Regex("^[^H][^e][^l][^l][^o]", RegexOptions.Compiled);

		// This isn't exactly a token negation, but is as close as you're gonna get from Regex
		readonly PcreRegex pcreregex = new PcreRegex("^[^H][^e][^l][^l][^o]");

		// This isn't exactly a token negation, but is as close as you're gonna get from Regex
		readonly PcreRegex pcreregexCompiled = new PcreRegex("^[^H][^e][^l][^l][^o]", PcreOptions.Compiled);

		readonly Parser<Char, Unit> pidgin = Parser.Not(Parser.String("Hello"));

		// This isn't exactly a token negation, as it behaves more closely to a negative lookahead in Regex.
		readonly Sprache.Parser<Object> sprache = Parse.String("Hello").Not();

		readonly Pattern stringier = Not("Hello");

		[Params("World", "H", "Hello")]
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegex() => pcreregex.Match(Source);

		[Benchmark]
		public Result<Char, Unit> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Object Sprache() => sprache.Parse(Source);

		[Benchmark]
		public Stringier.Patterns.Result Stringier() => stringier.Consume(Source);
	}
}
