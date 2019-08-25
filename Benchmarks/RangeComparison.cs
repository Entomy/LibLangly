﻿using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class RangeComparison {

		RangePattern Pattern = new RangePattern("Hello", ";");

		Regex Regex = new Regex("^Hello.*;$");

		[Params("Hello World;", "Hello World", "Goodbye World;")]
		public String Source { get; set; }

		[Benchmark]
		public Result RangeConsume() => Pattern.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}