using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class CompoundPatternComparison {
		readonly static Pattern commentPattern = "--" & +!(Pattern)"\n";

		[Benchmark]
		public Result CommentPattern() => commentPattern.Consume("--Comment");

		readonly static Regex commentRegex = new Regex("^--.*", RegexOptions.IgnoreCase | RegexOptions.Singleline);

		[Benchmark]
		public Match CommentRegex() => commentRegex.Match("--Comment");

		readonly static Pattern identifierPattern = Pattern.Letter & +(Pattern.Letter | Pattern.DecimalDigitNumber | '_');

		[Benchmark]
		public Result IdentifierPattern() => identifierPattern.Consume("Hello_World");

		readonly static Regex identifierRegex = new Regex("\\w(\\w|_)+", RegexOptions.IgnoreCase);

		[Benchmark]
		public Match IdentifierRegex() => identifierRegex.Match("Hello_World");

		readonly static Pattern ipv4Digit = (-(((Pattern)'1' | '2') & Pattern.DecimalDigitNumber) | Pattern.DecimalDigitNumber) & -Pattern.DecimalDigitNumber;
		readonly static Pattern ipv4AddressPattern = ipv4Digit & "." & ipv4Digit & "." & ipv4Digit & "." & ipv4Digit;

		[Benchmark]
		public Result IPv4AddressPattern() => ipv4AddressPattern.Consume("192.168.1.1");

		readonly static Regex ipv4AddressRegex = new Regex(@"[12]?\d{1,2}.[12]?\d{1,2}.[12]?\d{1,2}.[12]?\d{1,2}", RegexOptions.IgnoreCase);

		[Benchmark]
		public Match IPv4AddressRegex() => ipv4AddressRegex.Match("192.168.1.1");

		readonly static Pattern nestedPackagePattern = (
				From: "package" & +Pattern.SpaceSeparator & identifierPattern.Capture(out System.Text.Patterns.Capture Name),
				To: "end" & +Pattern.SpaceSeparator & Name & ';');

		[Benchmark]
		public Result NestedPackagePattern() => nestedPackagePattern.Consume("package Top\npackage Nest\nend Nest;\nend Top;");

		readonly static Regex nestedPackageRegex = new Regex(@"package\s+(?<Name>\w(\w|\d|_)*).*end\s+\k<Name>;", RegexOptions.IgnoreCase | RegexOptions.Singleline);

		[Benchmark]
		public Match NestedPackageRegex() => nestedPackageRegex.Match("package Top\npackage Nest\nend Nest;\nend Top;");

		readonly static Pattern phoneNumberPattern = Pattern.Number * 3 & '-' & Pattern.Number * 3 & '-' & Pattern.Number * 4;

		[Benchmark]
		public Result PhoneNumberPattern() => phoneNumberPattern.Consume("555-555-5555");

		readonly static Regex phoneNumberRegex = new Regex(@"\d{3}-\d{3}-\d{4}", RegexOptions.IgnoreCase);

		[Benchmark]
		public Match PhoneNumberRegex() => phoneNumberRegex.Match("555-555-5555");

		readonly static Pattern stringPattern = (From: "\"", To: "\"", Escape: "\\\"");

		[Benchmark]
		public Result StringPattern() => stringPattern.Consume("\"Hello\\\"World\"");

		readonly static Regex stringRegex = new Regex("\"(\\.|[^\"])*\"", RegexOptions.IgnoreCase);

		[Benchmark]
		public Match StringRegex() => stringRegex.Match("\"Hello\\\"World\"");

		readonly static Pattern webAddressPattern =
			-("http" & -(Pattern)'s' & "://")
			& +(Pattern.Letter | Pattern.Number | "-") & "." & (Pattern.Letter * 3 & Source.End | +(Pattern.Letter | Pattern.Number | "-") & "." & Pattern.Letter * 3)
			& -+('/' & +(Pattern.Letter | Pattern.Number | '-' | '_'));

		[Benchmark]
		public Result WebAddressPattern() => webAddressPattern.Consume("http://www.google.com/about");

		readonly static Regex webAddressRegex = new Regex(@"https?://((\w|-)+\.)?(\w|_)+\.\w{3}(/(\w|\d|-|_)+)*", RegexOptions.IgnoreCase);

		[Benchmark]
		public Match WebAddressRegex() => webAddressRegex.Match("http://www.google.com/about");
	}
}
