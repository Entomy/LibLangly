using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphInfo {
		/// <summary>
		/// Generates the equivalencies table.
		/// </summary>
		/// <param name="projectPath">The project path to generate files into.</param>
		public static void GenerateParser(String projectPath) {
			Console.WriteLine("Generating Glyph parser...", Color.Cyan);
			using StreamWriter file = new StreamWriter(new FileStream(projectPath + "Glyph.Parser.cs", FileMode.Create, FileAccess.Write), System.Text.Encoding.UTF8);
			Int32 current = 0;
			Int32 codepoint = 0;
			file.WriteLine(@"//!! This file was generated, do not edit it by hand!
using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial struct Glyph {
		/// <summary>
		/// A <see cref=""Dictionary{TElement}"" /> specially constructed to allow for parsing <see cref=""Glyph"" /> from UTF-16 LE sequences.
		/// </summary>
		[DisallowNull, NotNull]
		internal static readonly Dictionary<Int32> Parser = new Dictionary<Int32>() {
			// A few entries have to manually be put in front, to get around elaboration order issues. This is simpler than tweaking the code to handle out-of-order additions.
			{ ""ı"", 0x0131 },
			// Now we have the normal auto-generated portion");
			// Grapheme part
			foreach (String line in File.ReadAllLines(projectPath + GraphemeFile, System.Text.Encoding.UTF8)) {
				if (String.IsNullOrEmpty(line) || line.StartsWith("#", StringComparison.Ordinal)) {
					// This is a comment or empty line, so skip it.
					continue;
				}
				GroupCollection match = Record.Match(line).Groups;
				codepoint = Int32.Parse(match["Code"].Value, NumberStyles.HexNumber);
				while (current < codepoint) {
					if (current < Char.MaxValue) {
						file.WriteLine($"\t\t\t{{ \"\\u{current:X4}\", 0x{current:X4} }},");
					}
					current++;
				}
				foreach (String sequence in Sequences(match["Sequences"].Value)) {
					file.WriteLine($"\t\t\t{{ \"{sequence}\", 0x{match["Code"]} }}, // {match["Grapheme"]}");
				}
				current++;
			}
			file.WriteLine(@"
		};
	}
}");
		}
	}
}
