using System;
using System.Text.RegularExpressions;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphTables {
		private const String GraphemeFile = "Graphemes.txt";

		private static readonly Regex Record = new Regex(@"(?<Grapheme>[^;]*);(?<Code>[^;]*);(?<Sequences>[^;]*);(?<Lower>[^;]*);(?<Title>[^;]*);(?<Upper>[^;]*);(?<UTF8>[^;]*);(?<UTF16>[^;]*)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		/// <summary>
		/// Main entrypoint.
		/// </summary>
		public static void Main() {
			FindProjectPath(out String projectPath);
			FindGraphemesFile();
			GenerateEquivalenciesTable(projectPath);
			GenerateInfoTable(projectPath);
			Console.WriteLine("All done!", Color.Green);
		}
	}
}
