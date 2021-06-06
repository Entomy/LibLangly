using System;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Running;
using Spectre.Console;
using Console = Spectre.Console.AnsiConsole;

namespace Langly {
	public static class Program {
		[SuppressMessage("Performance", "HAA0101:Array allocation for params parameter", Justification = "Yes, this is a simple benchmarking interface, it's fine.")]
		[SuppressMessage("Performance", "HLQ010:Consider using a 'for' loop instead.", Justification = "Yes, this is a simple benchmarking interface, it's fine.")]
		public static void Main() {
			Console.Render(new FigletText("LibLangly").Color(Color.Chartreuse1));
			Console.Render(new FigletText("Benchmarks").Color(Color.Magenta1));
			foreach (String selection in Console.Prompt(new MultiSelectionPrompt<String>()
				.PageSize(10)
				.NotRequired()
				.MoreChoicesText("[grey](Move up and down to reveal more benchmarks)[/]")
				.InstructionsText("[grey](Press [blue]<space>[/] to toggle a benchmark, [green]<enter>[/] to accept and run)[/]")
				.AddChoiceGroup(nameof(Collectathon), new[] {
					nameof(Construction),
				})
				.AddChoiceGroup(nameof(Langly), new[] {
					""
				})
				.AddChoiceGroup(nameof(Numbersome), new[] {
					""
				})
				.AddChoiceGroup(nameof(Streamy), new[] {
					""
				})
				.AddChoiceGroup(nameof(Stringier), new[] {
					""
				}))) {
				switch (selection) {
				case nameof(Construction):
					BenchmarkRunner.Run<Construction>();
					break;
				default:
					break;
				}
			}
		}
	}
}
