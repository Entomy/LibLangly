using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Internals;

namespace Langly {
	public static partial class Console {
		#region Read()
		/// <summary>
		/// Reads a grapheme from the standard input stream.
		/// </summary>
		/// <returns>The grapheme that was read.</returns>
		public static Glyph Read() => throw new NotImplementedException();
		#endregion

		#region ReadLine()
		/// <summary>
		/// Reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public static String ReadLine() {
			ConsoleComponents.Reader.ReadLine(out String result);
			return result;
		}
		#endregion
	}
}
