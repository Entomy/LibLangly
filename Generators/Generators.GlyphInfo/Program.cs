using System;
using System.Text.RegularExpressions;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphInfo {
		private const String GraphemeFile = "GlyphInfo.txt";

		private static readonly Regex Record = new Regex(@"(?<Grapheme>[^;]*);(?<Code>[^;]*);(?<Sequences>[^;]*);(?<Lower>[^;]*);(?<Title>[^;]*);(?<Upper>[^;]*);(?<UTF8>[^;]*);(?<UTF16>[^;]*)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		/// <summary>
		/// Main entrypoint.
		/// </summary>
		public static void Main() {
			FindProjectPath(out String projectPath);
			FindDataFile(projectPath);
			GenerateParser(projectPath);
			GenerateTable(projectPath);
			Console.WriteLine("All done!", Color.Green);
		}
	}
}
