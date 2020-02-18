using System;
using Benchmarks.Core;
using Benchmarks.Extensions;
using Benchmarks.Patterns;
using Benchmarks.Streams;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Benchmarks {
	public static class Program {
		internal readonly static KeyChoiceSet MenuChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Core", () => {
					Console.WriteChoices(AlgorithmsChoices);
					Console.ReadChoice(AlgorithmsChoices);
				}),
				new KeyChoice(ConsoleKey.D2, "Extensions", () => {
					Console.WriteChoices(ExtensionsChoices);
					Console.ReadChoice(ExtensionsChoices);
				}),
				new KeyChoice(ConsoleKey.D3, "Patterns", () => {
					Console.WriteChoices(PatternsChoices);
					Console.ReadChoice(PatternsChoices);
				}),
				new KeyChoice(ConsoleKey.D4, "Streams", () => {
					Console.WriteChoices(StreamsChoices);
					Console.ReadChoice(StreamsChoices);
				}),
				new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));

		internal readonly static KeyChoiceSet AlgorithmsChoices = new KeyChoiceSet(" Enter Choice: ",
			new KeyChoice(ConsoleKey.D1, "Edit Distance (Same Length)", () => BenchmarkRunner.Run<FixedEditDistanceBenchmarks>()),
			new KeyChoice(ConsoleKey.D2, "Glyph", () => {
				_ = BenchmarkRunner.Run<GlyphConstructorBenchmarks>();
				_ = BenchmarkRunner.Run<GlyphEqualsBenchmarks>();
				_ = BenchmarkRunner.Run<GlyphGetGlyphAtBenchmarks>();
				_ = BenchmarkRunner.Run<GlyphSplitBenchmarks>();
			}),
			new KeyChoice(ConsoleKey.D3, "String Search", () => BenchmarkRunner.Run<SearchBenchmarks>()),
			new BackKeyChoice(ConsoleKey.B, "Back", () => { }));

		internal readonly static KeyChoiceSet ExtensionsChoices = new KeyChoiceSet(" Enter Choice: ",
			new KeyChoice(ConsoleKey.D1, "Chop", () => BenchmarkRunner.Run<ChopBenchmarks>()),
			new KeyChoice(ConsoleKey.D2, "Clean", () => BenchmarkRunner.Run<CleanBenchmarks>()),
			new KeyChoice(ConsoleKey.D3, "Contains", () => {
				_ = BenchmarkRunner.Run<ContainsCharStringBenchmarks>();
				_ = BenchmarkRunner.Run<ContainsCharIEnumerableBenchmarks>();
				_ = BenchmarkRunner.Run<ContainsStringIEnumerableBenchmarks>();
			}),
			new KeyChoice(ConsoleKey.D4, "Ensure", () => BenchmarkRunner.Run<EnsureBenchmarks>()),
			new KeyChoice(ConsoleKey.D5, "IsPalindrome", () => BenchmarkRunner.Run<IsPalindromeBenchmarks>()),
			new KeyChoice(ConsoleKey.D6, "Join", () => BenchmarkRunner.Run<JoinBenchmarks>()),
			new KeyChoice(ConsoleKey.D7, "Lines", () => BenchmarkRunner.Run<LinesBenchmarks>()),
			new KeyChoice(ConsoleKey.D8, "Occurrences", () => BenchmarkRunner.Run<OccurrencesBenchmarks>()),
			new KeyChoice(ConsoleKey.D9, "Pad", () => BenchmarkRunner.Run<PadBenchmarks>()),
			new KeyChoice(ConsoleKey.A, "Split", () => BenchmarkRunner.Run<SplitBenchmarks>()),
			new BackKeyChoice(ConsoleKey.B, "Back", () => { }),
			new KeyChoice(ConsoleKey.C, "Repeat", () => BenchmarkRunner.Run<RepeatBenchmarks>()));

		internal readonly static KeyChoiceSet PatternsChoices = new KeyChoiceSet(" Enter Choice: ",
			new KeyChoice(ConsoleKey.D1, "Literal", () => BenchmarkRunner.Run<LiteralBenchmarks>()),
			new KeyChoice(ConsoleKey.D2, "Alternator", () => BenchmarkRunner.Run<AlternatorBenchmarks>()),
			new KeyChoice(ConsoleKey.D3, "Concatenator", () => BenchmarkRunner.Run<ConcatenatorBenchmarks>()),
			new KeyChoice(ConsoleKey.D4, "Kleene's Closure", () => BenchmarkRunner.Run<KleeneClosureBenchmarks>()),
			new KeyChoice(ConsoleKey.D5, "Fuzzer", () => BenchmarkRunner.Run<FuzzerBenchmarks>()),
			new KeyChoice(ConsoleKey.D6, "Negator", () => BenchmarkRunner.Run<NegatorBenchmarks>()),
			new KeyChoice(ConsoleKey.D7, "Optor", () => BenchmarkRunner.Run<OptorBenchmarks>()),
			new KeyChoice(ConsoleKey.D8, "Ranger", () => BenchmarkRunner.Run<RangerBenchmarks>()),
			new KeyChoice(ConsoleKey.D9, "Repeater", () => BenchmarkRunner.Run<RepeaterBenchmarks>()),
			new KeyChoice(ConsoleKey.A, "Spanner", () => BenchmarkRunner.Run<SpannerBenchmarks>()),
			new BackKeyChoice(ConsoleKey.B, "Back", () => { }),
			new KeyChoice(ConsoleKey.C, "Identifier", () => BenchmarkRunner.Run<IdentifierBenchmarks>()),
			new KeyChoice(ConsoleKey.D, "Checker", () => BenchmarkRunner.Run<CheckerBenchmarks>()),
			new KeyChoice(ConsoleKey.E, "IPv4 Address", () => BenchmarkRunner.Run<IPv4AddressBenchmarks>()),
			new KeyChoice(ConsoleKey.F, "LineComment", () => BenchmarkRunner.Run<LineCommentBenchmarks>()),
			new KeyChoice(ConsoleKey.G, "Phone Number", () => BenchmarkRunner.Run<PhoneNumberBenchmarks>()),
			new KeyChoice(ConsoleKey.H, "String Literal", () => BenchmarkRunner.Run<StringLiteralBenchmarks>()));

		internal readonly static KeyChoiceSet StreamsChoices = new KeyChoiceSet(" Enter Choice: ",
			new KeyChoice(ConsoleKey.D1, "StringStream", () => BenchmarkRunner.Run<StringStreamBenchmarks>()),
			new BackKeyChoice(ConsoleKey.B, "Back", () => { }));

		public static void Main() {
			Theme.DefaultDark.Apply();

			while (true) {
				Console.WriteChoices(MenuChoices);
				Console.ReadChoice(MenuChoices);
			}
		}
	}
}
