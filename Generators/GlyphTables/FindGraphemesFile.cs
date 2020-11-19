using System;
using System.IO;
using Consolator;
using Console = Consolator.Console;

namespace Generators {
	public static partial class GlyphTables {
		/// <summary>
		/// Finds the grapheme file, ensuring it exists.
		/// </summary>
		public static void FindGraphemesFile() {
			Console.WriteLine("Finding equivalencies file...", Color.Cyan);
			if (!File.Exists(GraphemeFile)) {
				Console.WriteLine($"Missing {GraphemeFile}!", Color.Red);
				Environment.Exit(1);
			}
		}
	}
}
