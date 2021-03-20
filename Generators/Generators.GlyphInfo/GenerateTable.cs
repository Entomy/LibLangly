using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Unicode;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphInfo {
		/// <summary>
		/// Generates the info table.
		/// </summary>
		/// <param name="projectPath">The project path to generate files into.</param>
		public static void GenerateTable(String projectPath) {
			Console.WriteLine("Generating Glyph info table...", Color.Cyan);
			using StreamWriter file = new StreamWriter(new FileStream(projectPath + "Glyph.Table.cs", FileMode.Create, FileAccess.Write), System.Text.Encoding.UTF8);
			Int32 current = 0;
			Int32 codepoint = 0;
			file.WriteLine(@"//!! This file was generated, do not edit it by hand!
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial struct Glyph {
		/// <summary>
		/// Lookup table for <see cref=""GlyphInfo"" /> based on <see cref=""Glyph"" /> values.
		/// </summary>
		[DisallowNull, NotNull]
		internal static readonly GlyphInfo[] Table = new GlyphInfo[] {");
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
						file.WriteLine($"\t\t\tnew(\"\\u{current:X4}\", 0x{(Int32)(Char.ToLower((Char)current)):X4}, 0x{(Int32)(UnicodeInfo.GetCharInfo(current).SimpleTitleCaseMapping?[0] ?? Char.ToUpper((Char)current)):X4}, 0x{(Int32)(Char.ToUpper((Char)current)):X4}, 1, 1), // {current:X4}");
					}
					current++;
				}
				file.WriteLine($"\t\t\tnew(\"{match["Grapheme"]}\", 0x{match["Lower"]}, 0x{match["Title"]}, 0x{match["Upper"]}, {match["UTF8"]}, {match["UTF16"]}), // {current:X4}");
				current++;
			}
			file.WriteLine(@"
		};
	}
}");
		}
	}
}
