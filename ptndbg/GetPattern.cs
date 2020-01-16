using System;
using System.Diagnostics.CodeAnalysis;
using Stringier.Patterns;
using Stringier.Patterns.Parser;
using Console = Consolator.Console;

namespace ptndbg {
	public static partial class Program {
		[SuppressMessage("Minor Code Smell", "S3626:Jump statements should not be redundant", Justification = "This is a complex method which makes use of goto's. The 'redundant' gotos actually improve readability, as weird as that sounds, in the context of this method.")]
		public static Pattern GetPattern() {
			Source patternText = new Source(Console.ReadLine(" Pattern: ", ConsoleColor.Yellow, ConsoleColor.White));
			return Expression.Parse(ref patternText).Evaluate();
		}
	}
}
