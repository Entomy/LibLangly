using System;
using Benchmarks.Extensions;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Benchmarks {
	public static class Program {
		internal static KeyChoiceSet MenuChoices;
		internal static KeyChoiceSet ExtensionsChoices;

		public static void Main() {
			Theme.DefaultDark.Apply();
			MenuChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Extensions", () => {
					Console.WriteChoices(ExtensionsChoices);
					Console.ReadChoice(ExtensionsChoices);
				}),
				new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));
			ExtensionsChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Chop", () => BenchmarkRunner.Run<ChopBenchmarks>() ),
				new KeyChoice(ConsoleKey.D2, "Clean", () => BenchmarkRunner.Run<CleanBenchmarks>() ),
				new KeyChoice(ConsoleKey.D3, "Contains", () => {
					_ = BenchmarkRunner.Run<ContainsCharStringBenchmarks>();
					_ = BenchmarkRunner.Run<ContainsCharIEnumerableBenchmarks>();
					_ = BenchmarkRunner.Run<ContainsStringIEnumerableBenchmarks>();
				}),
				new KeyChoice(ConsoleKey.D4, "Ensure", () => BenchmarkRunner.Run<EnsureBenchmarks>() ),
				new BackKeyChoice(ConsoleKey.B, "Back", () => {
					Console.WriteChoices(MenuChoices);
					Console.ReadChoice(MenuChoices);
				}));

			Console.WriteChoices(MenuChoices);
			Console.ReadChoice(MenuChoices);
		}
	}
}
