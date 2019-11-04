using System;
using BenchmarkDotNet.Running;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;

namespace Benchmarks {
	public static class Program {
		internal static KeyChoiceSet MenuChoices;
		internal static KeyChoiceSet ChrestomathyChoices;

		public static void Main() {
			Theme.DefaultDark.Apply();
			MenuChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Chrestomathy", () => {
					Console.WriteChoices(ChrestomathyChoices);
					Console.ReadChoice(ChrestomathyChoices);
				}),
				new BackKeyChoice(ConsoleKey.Q, "Quit", () => Environment.Exit(0)));
			ChrestomathyChoices = new KeyChoiceSet(" Enter Choice: ",
				new KeyChoice(ConsoleKey.D1, "Source Construction", () => BenchmarkRunner.Run<SourceConstruction>() ),
				new KeyChoice(ConsoleKey.D2, "String Equality Benchmarks", () => BenchmarkRunner.Run<StringEquality>() ),
				new BackKeyChoice(ConsoleKey.B, "Back", () => {
					Console.WriteChoices(MenuChoices);
					Console.ReadChoice(MenuChoices);
				}));

			Console.WriteChoices(MenuChoices);
			Console.ReadChoice(MenuChoices);
		}
	}
}
