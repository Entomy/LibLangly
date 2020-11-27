using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Internals {
	/// <summary>
	/// Indicates the type provides error-write behavior for the <see cref="Console"/>.
	/// </summary>
	[CLSCompliant(false)]
	public interface IConsoleErrorWriter {
		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write(ReadOnlySpan<Char> text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		public unsafe void Write([NotNull] Char* text, Int32 length);

		/// <summary>
		/// Writes a line terminator to the standard output stream.
		/// </summary>
		public void WriteLine();

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine(ReadOnlySpan<Char> text) {
			Write(text);
			WriteLine();
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		public unsafe void WriteLine([NotNull] Char* text, Int32 length) {
			Write(text, length);
			WriteLine();
		}
	}
}
