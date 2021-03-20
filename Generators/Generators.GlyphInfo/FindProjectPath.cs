using System;
using System.IO;
using Langly;
using Console = Langly.Console;

namespace Generators {
	public static partial class GlyphInfo {
		/// <summary>
		/// Finds the project path, ensuring it exists, and setting it for future reference.
		/// </summary>
		/// <param name="projectPath">The path of the found project.</param>
		public static void FindProjectPath(out String projectPath) {
			Console.Write("Finding project path... ", Color.Cyan);
			// Check the VisualStudio paths
			projectPath = "../../../../../Libraries/Langly.Glyph/";
			if (File.Exists(projectPath + "Langly.Glyph.csproj")) {
				Console.WriteLine("using paths for VisualStudio...", Color.Cyan);
				return;
			}
			// Check the dotnet tool paths
			projectPath = "../../Libraries/Langly.Glyph/";
			if (File.Exists(projectPath + "Langly.Glyph.csproj")) {
				Console.WriteLine("using paths for dotnet tool...", Color.Cyan);
				return;
			}
			Console.WriteLine("Couldn't figure out the project paths!", Color.Red);
			Environment.Exit(1);
		}
	}
}
