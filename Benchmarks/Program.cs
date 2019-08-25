using System;
using BenchmarkDotNet.Running;

namespace Benchmarks {
	static class Program {
		static void Main() {
		ListChoice:
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write(" [0] ");
			Console.ResetColor();
			Console.Write("Chrestomathy Benchmarks");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(" (Run these if interested in finding ways to optimize parsers)");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write(" [1] ");
			Console.ResetColor();
			Console.Write("Concept Benchmarks");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(" (Run these if interested in optimizing parsers)");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.DarkYellow;
			Console.Write(" [2] ");
			Console.ResetColor();
			Console.Write("Real World Benchmarks");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(" (Run these if interested in serious performance against alternative models)");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write(" [Q] ");
			Console.ResetColor();
			Console.WriteLine("Quit");
		EnterChoice:
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.Write(" Choice: ");
			Console.ResetColor();
			ConsoleKeyInfo Choice = Console.ReadKey();
			Console.WriteLine();
			Console.WriteLine();
			switch (Choice.KeyChar.ToUpperInvariant()) {
			case '1':
				BenchmarkRunner.Run<AlternatorComparison>();
				BenchmarkRunner.Run<ConcatenatorComparison>();
				BenchmarkRunner.Run<LiteralComparison>();
				BenchmarkRunner.Run<NegatorComparison>();
				BenchmarkRunner.Run<OptorComparison>();
				BenchmarkRunner.Run<RangeComparison>();
				BenchmarkRunner.Run<RepeaterComparison>();
				BenchmarkRunner.Run<SpannerComparison>();
				break;
			case '2':
				BenchmarkRunner.Run<CompoundPatternComparison>();
				break;
			case '0':
				BenchmarkRunner.Run<Int32ParseCharComparison>();
				BenchmarkRunner.Run<Int32ParseStringComparison>();
				BenchmarkRunner.Run<SliceSubstringComparison>();
				break;
			case 'Q':
				return;
			default:
				goto EnterChoice;
			}
			goto ListChoice;
		}
	}
}
