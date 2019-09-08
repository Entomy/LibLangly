using System;
using System.Text.Patterns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Benchmarks {
	static class Program {
		static void Main() {
			Boolean All = false;
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
			switch (Choice.KeyChar.ToUpperInvariant()) {
			case '0':
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [1] ");
				Console.ResetColor();
				Console.WriteLine("Alternator vs Checker");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [2] ");
				Console.ResetColor();
				Console.WriteLine("Int32.Parse(Char) vs Char.ParseInt32()");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [3] ");
				Console.ResetColor();
				Console.WriteLine("Int32.Parse(String) vs String.ParseInt32()");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [4] ");
				Console.ResetColor();
				Console.WriteLine("String[x..y] vs String.Substring(x, l)");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [5] ");
				Console.ResetColor();
				Console.WriteLine("String Culture Comparison");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [6] ");
				Console.ResetColor();
				Console.WriteLine("String Equality Approaches");
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [A] ");
				Console.ResetColor();
				Console.WriteLine("All Benchmarks");
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write(" [B] ");
				Console.ResetColor();
				Console.WriteLine("Back");
			EnterChrestomathyChoice:
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write(" Choice: ");
				Console.ResetColor();
				Choice = Console.ReadKey();
				Console.WriteLine();
				switch (Choice.KeyChar.ToUpperInvariant()) {
				case 'A':
					All = true;
					goto case '1';
				case '1':
					BenchmarkRunner.Run<CheckerComparison>();
					if (All) { goto case '2'; } else { break; }
				case '2':
					BenchmarkRunner.Run<Int32ParseCharComparison>();
					if (All) { goto case '3'; } else { break; }
				case '3':
					BenchmarkRunner.Run<Int32ParseStringComparison>();
					if (All) { goto case '4'; } else { break; }
				case '4':
					BenchmarkRunner.Run<SliceSubstringComparison>();
					break;
				case '5':
					BenchmarkRunner.Run<StringCultureComparison>();
					break;
				case '6':
					BenchmarkRunner.Run<StringEqualsComparison>();
					break;
				case 'B':
					goto ListChoice;
				default:
					goto EnterChrestomathyChoice;
				}
				break;
			case '1':
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [1] ");
				Console.ResetColor();
				Console.WriteLine("Alternator Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [2] ");
				Console.ResetColor();
				Console.WriteLine("Concatenator Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [3] ");
				Console.ResetColor();
				Console.WriteLine("Literal Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [4] ");
				Console.ResetColor();
				Console.WriteLine("Negator Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [5] ");
				Console.ResetColor();
				Console.WriteLine("Optor Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [6] ");
				Console.ResetColor();
				Console.WriteLine("Range Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [7] ");
				Console.ResetColor();
				Console.WriteLine("Repeater Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [8] ");
				Console.ResetColor();
				Console.WriteLine("Spanner Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.Write(" [A] ");
				Console.ResetColor();
				Console.WriteLine("All Benchmarks");
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write(" [B] ");
				Console.ResetColor();
				Console.WriteLine("Back");
				Console.ResetColor();
			EnterConceptChoice:
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write(" Choice: ");
				Console.ResetColor();
				Choice = Console.ReadKey();
				Console.WriteLine();
				switch (Choice.KeyChar.ToUpperInvariant()) {
				case 'A':
					All = true;
					goto case '1';
				case '1':
					BenchmarkRunner.Run<AlternatorComparison>();
					if (All) { goto case '2'; } else { break; }
				case '2':
					BenchmarkRunner.Run<ConcatenatorComparison>();
					if (All) { goto case '3'; } else { break; }
				case '3':
					BenchmarkRunner.Run<LiteralComparison>();
					if (All) { goto case '4'; } else { break; }
				case '4':
					BenchmarkRunner.Run<NegatorComparison>();
					if (All) { goto case '5'; } else { break; }
				case '5':
					BenchmarkRunner.Run<OptorComparison>();
					if (All) { goto case '6'; } else { break; }
				case '6':
					BenchmarkRunner.Run<RangeComparison>();
					if (All) { goto case '7'; } else { break; }
				case '7':
					BenchmarkRunner.Run<RepeaterComparison>();
					if (All) { goto case '8'; } else { break; }
				case '8':
					BenchmarkRunner.Run<SpannerComparison>();
					break;
				case 'B':
					goto ListChoice;
				default:
					goto EnterConceptChoice;
				}
				break;
			case '2':
				BenchmarkRunner.Run<CompoundPatternComparison>();
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
