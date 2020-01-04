using System;
using System.Diagnostics.CodeAnalysis;
using Consolator.UI.Theming;
using Console = Consolator.Console;
using Stringier.Patterns;
using Stringier.Patterns.Debugging;

namespace ptndbg {
	public static partial class Program {
		[SuppressMessage("Redundancy", "RCS1038:Remove empty statement.", Justification = "They are used for break-points, they don't hurt anything, stfu.")]
		[SuppressMessage("Minor Code Smell", "S1116:Empty statements should be removed", Justification = "They are used for break-points, they don't hurt anything, stfu.")]
		[SuppressMessage("Usage", "MA0037:Remove empty statement", Justification = "They are used for break-points, they don't hurt anything, stfu.")]
		public static void Main() {
			Theme.DefaultDark.Apply();

			Source source = GetSource();
			Pattern pattern = GetPattern();
			ITrace trace = new Trace();

			_ = pattern.Consume(ref source, trace);

			foreach (IStep step in trace) {
				Console.Write($"{step.Position.ToString().PadLeft(5)}: ", ConsoleColor.Yellow);
				Console.Write("|", ConsoleColor.DarkBlue);
				Console.Write(step);
				Console.WriteLine("|", ConsoleColor.DarkRed);
			}
		}
	}
}