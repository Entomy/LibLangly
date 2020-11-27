using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphTables {
		/// <summary>
		/// Generates the equivalencies table.
		/// </summary>
		/// <param name="projectPath">The project path to generate files into.</param>
		public static void GenerateEquivalenciesTable(String projectPath) {
			Console.WriteLine("Generating equivalencies table...", Color.Cyan);
			using StreamWriter file = new StreamWriter(new FileStream(projectPath + "Glyph.Equivalencies.cs", FileMode.Create, FileAccess.Write), Encoding.UTF8);
			Int32 current = 0;
			Int32 codepoint = 0;
			file.WriteLine(@"//!! This file was generated, do not edit it by hand!
using System;
using System.Collections.Generic;
namespace Stringier {
	public partial struct Glyph {
		internal static readonly Trie Equivalencies = new Trie() {
			// A few entries have to manually be put in front, to get around elaboration order issues. This is simpler than tweaking the code to handle out-of-order additions.
			{ ""ı"", 0x0131 },
			// Now we have the normal auto-generated portion");
			// Grapheme part
			foreach (String line in File.ReadAllLines(GraphemeFile, Encoding.UTF8)) {
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
