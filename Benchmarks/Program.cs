using System;
using Benchmarks.Extensions;
using Benchmarks.Patterns;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Benchmarks {
	public static class Program {
		internal static KeyChoiceSet MenuChoices;
		internal static KeyChoiceSet ExtensionsChoices;
		internal static KeyChoiceSet PatternsChoices;

		public static void Main() {
			Theme.DefaultDark.Apply();
			MenuChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Extensions", () => {
					Console.WriteChoices(ExtensionsChoices);
					Console.ReadChoice(ExtensionsChoices);
				}),
				new KeyChoice(ConsoleKey.D2, "Patterns", () => {
					Console.WriteChoices(PatternsChoices);
					Console.ReadChoice(PatternsChoices);
				}),
				new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));
			ExtensionsChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Chop", () => BenchmarkRunner.Run<ChopBenchmarks>()),
				new KeyChoice(ConsoleKey.D2, "Clean", () => BenchmarkRunner.Run<CleanBenchmarks>()),
				new KeyChoice(ConsoleKey.D3, "Contains", () => {
					_ = BenchmarkRunner.Run<ContainsCharStringBenchmarks>();
					_ = BenchmarkRunner.Run<ContainsCharIEnumerableBenchmarks>();
					_ = BenchmarkRunner.Run<ContainsStringIEnumerableBenchmarks>();
				}),
				new KeyChoice(ConsoleKey.D4, "Ensure", () => BenchmarkRunner.Run<EnsureBenchmarks>()),
				new KeyChoice(ConsoleKey.D5, "Join", () => BenchmarkRunner.Run<JoinBenchmarks>()),
				new KeyChoice(ConsoleKey.D6, "Lines", () => BenchmarkRunner.Run<LinesBenchmarks>()),
				new KeyChoice(ConsoleKey.D7, "Occurrences", () => BenchmarkRunner.Run<OccurrencesBenchmarks>()),
				new KeyChoice(ConsoleKey.D8, "Pad", () => BenchmarkRunner.Run<PadBenchmarks>()),
				new KeyChoice(ConsoleKey.D9, "Repeat", () => BenchmarkRunner.Run<RepeatBenchmarks>()),
				new KeyChoice(ConsoleKey.A, "Split", () => BenchmarkRunner.Run<SplitBenchmarks>()),
				new BackKeyChoice(ConsoleKey.B, "Back", () => { }));
			PatternsChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Literal", () => BenchmarkRunner.Run<LiteralBenchmarks>()));

			while (true) {
				Console.WriteChoices(MenuChoices);
				Console.ReadChoice(MenuChoices);
			}
		}
	}
}
