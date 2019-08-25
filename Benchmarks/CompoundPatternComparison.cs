﻿using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[CoreJob, CoreRtJob]
	public class CompoundPatternComparison {

		[Benchmark]
		public Result CommentPattern() {
			RangePattern Range = new RangePattern("--", Pattern.LineTerminator);
			return Range.Consume("--Comment");
		}

		[Benchmark]
		public Match CommentRegex() => new Regex("^--.*", RegexOptions.Singleline).Match("--Comment");

		[Benchmark]
		public Result IdentifierPattern() {
			Pattern Pattern = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | '_');
			return Pattern.Consume("Hello_World");
		}

		[Benchmark]
		public Match IdentifierRegex() => new Regex("\\w(\\w|_)+").Match("Hello_World");

		[Benchmark]
		public Result IPv4AddressPattern() {
			Pattern Digit = (~(((Pattern)'1' | '2') & Pattern.DecimalDigitNumber) | Pattern.DecimalDigitNumber) & ~Pattern.DecimalDigitNumber;
			Pattern Address = Digit & "." & Digit & "." & Digit & "." & Digit;
			return Address.Consume("192.168.1.1");
		}

		[Benchmark]
		public Match IPv4AddressRegex() => new Regex(@"[12]?\d{1,2}.[12]?\d{1,2}.[12]?\d{1,2}.[12]?\d{1,2}").Match("192.168.1.1");

		[Benchmark]
		public Result PhoneNumberPattern() {
			Pattern Pattern = Pattern.Number * 3 & '-' & Pattern.Number * 3 & '-' & Pattern.Number * 4;
			return Pattern.Consume("555-555-5555");
		}

		[Benchmark]
		public Match PhoneNumberRegex() => new Regex(@"\d{3}-\d{3}-\d{4}").Match("555-555-5555");

		[Benchmark]
		public Result StringPattern() {
			RangePattern Range = new RangePattern("\"", "\"", "\\\"");
			return Range.Consume("\"Hello\\\"World\"");
		}

		[Benchmark]
		public Match StringRegex() => new Regex("\"(\\.|[^\"])*\"").Match("\"Hello\\\"World\"");

		[Benchmark]
		public Result WebAddressPattern() {
			Pattern Protocol = "http" & ~(Pattern)'s' & "://";
			Pattern Host = +(Pattern.Letter | Pattern.Number | '-') & '.' & ~(+(Pattern.Letter | Pattern.Number | '-') & '.') & Pattern.Letter * 3;
			Pattern Location = +('/' & +(Pattern.Letter | Pattern.Number | '-' | '_'));
			Pattern Address = ~Protocol & Host & ~Location;
			return Address.Consume("http://www.google.com/about");
		}

		[Benchmark]
		public Match WebAddressRegex() => new Regex(@"https?://((\w|-)+\.)?(\w|_)+\.\w{3}(/(\w|\d|-|_)+)*").Match("http://www.google.com/about");

	}
}