using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Unicode;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphTables {
		/// <summary>
		/// Generates the info table.
		/// </summary>
		/// <param name="projectPath">The project path to generate files into.</param>
		public static void GenerateInfoTable(String projectPath) {
			Console.WriteLine("Generating info table...", Color.Cyan);
			using StreamWriter file = new StreamWriter(new FileStream(projectPath + "Glyph.Info.cs", FileMode.Create, FileAccess.Write), Encoding.UTF8);
			Int32 current = 0;
			Int32 codepoint = 0;
			file.WriteLine(@"//!! This file was generated, do not edit it by hand!
using System;
using System.Collections.Generic;
namespace Stringier {
	public partial struct Glyph {
		internal static readonly Table Info = new Table() {");
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
						file.WriteLine($"\t\t\t{{ \"\\u{current:X4}\", 0x{(Int32)(Char.ToLower((Char)current)):X4}, 0x{(Int32)(UnicodeInfo.GetCharInfo(current).SimpleTitleCaseMapping?[0] ?? Char.ToUpper((Char)current)):X4}, 0x{(Int32)(Char.ToUpper((Char)current)):X4}, 1, 1 }}, // {current:X4}");
					}
					current++;
				}
				file.WriteLine($"\t\t\t{{ \"{match["Grapheme"]}\", 0x{match["Lower"]}, 0x{match["Title"]}, 0x{match["Upper"]}, {match["UTF8"]}, {match["UTF16"]} }}, // {current:X4}");
				current++;
			}
			file.WriteLine(@"
		};
	}
}");
		}
	}
}
