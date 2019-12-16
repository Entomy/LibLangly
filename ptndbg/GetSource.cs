using System;
using System.Text;
using Consolator.UI;
using Consolator.UI.Theming;
using Console = Consolator.Console;
using Stringier.Patterns;

namespace ptndbg {
	public static partial class Program {
		public static Source GetSource() {
			Console.WriteLine("Enter <EOF> when done", ConsoleColor.DarkBlue);
			StringBuilder sourceText = new StringBuilder();
		GetLine:
			String line = Console.ReadLine(" Source: ", ConsoleColor.Yellow, ConsoleColor.White);
			if (String.Equals(line, "<EOF>", StringComparison.Ordinal)) {
				goto Done;
			} else {
				_ = sourceText.Append(line);
			}
			goto GetLine;
		Done:
			return new Source(sourceText.ToString());
		}
	}
}
