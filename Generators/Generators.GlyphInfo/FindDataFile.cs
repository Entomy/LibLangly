using System;
using System.IO;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphInfo {
		/// <summary>
		/// Finds the grapheme file, ensuring it exists.
		/// </summary>
		/// <param name="projectPath">The project path to find files from.</param>
		public static void FindDataFile(String projectPath) {
			Console.WriteLine("Finding data file...", Color.Cyan);
			if (!File.Exists(projectPath + GraphemeFile)) {
				Console.WriteLine($"Missing {GraphemeFile}!", Color.Red);
				Environment.Exit(1);
			}
		}
	}
}
