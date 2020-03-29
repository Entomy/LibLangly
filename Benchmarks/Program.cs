using System;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Benchmarks {
	public static class Program {
		internal readonly static KeyChoiceSet MenuChoices = new KeyChoiceSet(" Enter Choice: ",
			new KeyChoice(ConsoleKey.D1, "Edit Distance (Same Length)", () => BenchmarkRunner.Run<FixedEditDistanceBenchmarks>()),
			new KeyChoice(ConsoleKey.D2, "String Search", () => BenchmarkRunner.Run<SearchBenchmarks>()),
			new KeyChoice(ConsoleKey.D3, "Chop", () => BenchmarkRunner.Run<ChopBenchmarks>()),
			new KeyChoice(ConsoleKey.D4, "Clean", () => BenchmarkRunner.Run<CleanBenchmarks>()),
			new KeyChoice(ConsoleKey.D5, "Contains", () => {
				_ = BenchmarkRunner.Run<ContainsCharStringBenchmarks>();
				_ = BenchmarkRunner.Run<ContainsCharIEnumerableBenchmarks>();
				_ = BenchmarkRunner.Run<ContainsStringIEnumerableBenchmarks>();
			}),
			new KeyChoice(ConsoleKey.D6, "Ensure", () => BenchmarkRunner.Run<EnsureBenchmarks>()),
			new KeyChoice(ConsoleKey.D7, "Join", () => BenchmarkRunner.Run<JoinBenchmarks>()),
			new KeyChoice(ConsoleKey.D8, "Lines", () => BenchmarkRunner.Run<LinesBenchmarks>()),
			new KeyChoice(ConsoleKey.D9, "Occurrences", () => BenchmarkRunner.Run<OccurrencesBenchmarks>()),
			new KeyChoice(ConsoleKey.A, "Pad", () => BenchmarkRunner.Run<PadBenchmarks>()),
			new KeyChoice(ConsoleKey.B, "Repeat", () => BenchmarkRunner.Run<RepeatBenchmarks>()),
			new KeyChoice(ConsoleKey.C, "Replace", () => BenchmarkRunner.Run<ReplaceBenchmarks>()),
			new KeyChoice(ConsoleKey.D, "Split", () => BenchmarkRunner.Run<SplitBenchmarks>()),
			new KeyChoice(ConsoleKey.E, "UTF-8", () => BenchmarkRunner.Run<Utf8Benchmarks>()),
			new KeyChoice(ConsoleKey.F, "UTF-16", () => BenchmarkRunner.Run<Utf16Benchmarks>()),
			new KeyChoice(ConsoleKey.V, "ValueString", () => {
				Console.WriteChoices(ValueStringChoices);
				Console.ReadChoice(ValueStringChoices);
			}),
			new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));

		internal readonly static KeyChoiceSet ValueStringChoices = new KeyChoiceSet(" Enter Choice: ",
			new KeyChoice(ConsoleKey.D1, "Constructor", () => BenchmarkRunner.Run<ValueStrings.ConstructorBenchmarks>()),
			new KeyChoice(ConsoleKey.D2, "Enumerator", () => BenchmarkRunner.Run<ValueStrings.EnumeratorBenchmarks>()),
			new KeyChoice(ConsoleKey.D3, "Equals", () => BenchmarkRunner.Run<ValueStrings.EqualsBenchmarks>()),
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
