using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Unicode;
using Consolator;
using Console = Consolator.Console;

namespace Generator {
	public static class Program {
		private const String GraphemeFile = "Graphemes.txt";

		private static readonly Regex Record = new Regex(@"(?<Grapheme>[^;]*);(?<Code>[^;]*);(?<Sequences>[^;]*);(?<Lower>[^;]*);(?<Title>[^;]*);(?<Upper>[^;]*);(?<UTF8>[^;]*);(?<UTF16>[^;]*)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline);

		private static String ProjectPath = "";

		/// <summary>
		/// Main entrypoint.
		/// </summary>
		/// <exception cref="IOException"></exception>
		/// <exception cref="UnauthorizedAccessException"></exception>
		/// <exception cref="SecurityException"></exception>
		/// <exception cref="RegexMatchTimeoutException"></exception>
		public static void Main() {
			Console.Write("Finding project path... ", Color.Cyan);
			// Check the VisualStudio paths
			ProjectPath = "../../../../../Stringier/";
			if (File.Exists(ProjectPath + "Stringier.csproj")) {
				Console.WriteLine("using paths for VisualStudio...", Color.Cyan);
				goto Generate;
			}
			// Check the dotnet tool paths
			ProjectPath = "../../Stringier/";
			if (File.Exists(ProjectPath + "Stringier.csproj")) {
				Console.WriteLine("using paths for dotnet tool...", Color.Cyan);
				goto Generate;
			}
			Console.WriteLine("Couldn't figure out the project paths!", Color.Red);
			return;
		Generate:
			Int32 current = 0;
			Int32 codepoint = 0;
			Console.WriteLine("Finding equivalencies file...", Color.Cyan);
			if (!File.Exists(GraphemeFile)) {
				Console.WriteLine($"Missing {GraphemeFile}!", Color.Red);
			}
			Console.WriteLine("Generating equivalencies table...", Color.Cyan);
			StreamWriter file = new StreamWriter(new FileStream(ProjectPath + "Glyph.Equivalencies.cs", FileMode.Create, FileAccess.Write), Encoding.UTF8);
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
			file.Dispose();
			Console.WriteLine("Generating info table...", Color.Cyan);
			file = new StreamWriter(new FileStream(ProjectPath + "Glyph.Info.cs", FileMode.Create, FileAccess.Write), Encoding.UTF8);
			current = 0;
			codepoint = 0;
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
			file.Dispose();
		Done:
			Console.WriteLine("All done!", Color.Green);
		}

		private static IEnumerable<String> Sequences(String entry) {
			StringBuilder result = new StringBuilder();
			foreach (String sequence in entry.Split(',')) {
				_ = result.Clear();
				foreach (String part in sequence.Split(' ')) {
					_ = result.Append("\\u").Append(part);
				}
				yield return result.ToString();
			}
		}
	}
}
