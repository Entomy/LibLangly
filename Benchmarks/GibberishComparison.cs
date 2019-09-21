using System;
using System.IO;
using System.Text;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class GibberishComparison {

		public String gibberish = Gibberish.Generate(4);

		public String badGibberish = Gibberish.Generate(4, Bad: true);

		readonly Pattern pattern = +(+Pattern.Check("Letter", (Char) => 'a' <= Char && Char <= 'z') | +(Pattern)' ') & Source.End;

		readonly Regex regex = new Regex(@"(?:[a-z]+| +)+$", RegexOptions.Singleline);

		[Benchmark]
		public void PatternGood() {
			Source Source = new Source(gibberish);
			pattern.Consume(ref Source);
		}

		[Benchmark]
		public void PatternBad() {
			Source Source = new Source(badGibberish);
			pattern.Consume(ref Source);
		}

		[Benchmark]
		public void RegexGood() {
			regex.Match(gibberish);
		}

		[Benchmark]
		public void RegexBad() {
			regex.Match(badGibberish);
		}
	}
}
