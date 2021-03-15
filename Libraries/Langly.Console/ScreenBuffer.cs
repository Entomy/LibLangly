using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Internals;

namespace Langly {
	/// <summary>
	/// Represents the alternate screen buffer of the <see cref="Console"/>.
	/// </summary>
	/// <remarks>
	/// This is not actually a buffer, but rather, a proxy to assist the programmer in managing and understanding the lifetime of alternate screen buffer. Furthermore, because it is exposed as a non-static type, it is possible to extend the buffer features by third-party libraries. Because extension methods would have to be called off this type, and if this type exists the buffer is currently active, then screen drawing techniques which apply only to the alternate screen buffer are greatly simplified.
	/// </remarks>
	[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP009:Add IDisposable interface.", Justification = "We can't apply interfaces on ref structs.")]
	[SuppressMessage("Design", "CC0091:Use static method", Justification = "I fully get the reasoning, but these should show up off the instance to remain orthogonal with extensions. If you're not using the alternate screen buffer, you'd be using Console with its static calls.")]
	public ref struct ScreenBuffer {
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose() => ConsoleComponents.StateManager.UseMainScreenBuffer();

		#region Read()
		/// <summary>
		/// Reads a grapheme from the standard input stream.
		/// </summary>
		/// <returns>The grapheme that was read.</returns>
		public Glyph Read() => Console.Read();
		#endregion

		#region ReadLine()
		/// <summary>
		/// Reads everything up to a line terminator from the standard input stream.
		/// </summary>
		/// <returns>The line that was read, excluding the line terminator.</returns>
		[return: NotNull]
		public String ReadLine() => Console.ReadLine();
		#endregion

		#region Write()
		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write([AllowNull] String text) => Console.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write([AllowNull] String text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, foreground, background);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write([AllowNull] Char[] text) => Console.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write([AllowNull] Char[] text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, foreground, background);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write(Memory<Char> text) => Console.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write(Memory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, foreground, background);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write(ReadOnlyMemory<Char> text) => Console.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write(ReadOnlyMemory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, foreground, background);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write(Span<Char> text) => Console.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write(Span<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, foreground, background);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void Write(ReadOnlySpan<Char> text) => Console.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write(ReadOnlySpan<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, foreground, background);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public unsafe void Write([AllowNull] Char* text, Int32 length) => Console.Write(text, length);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		[CLSCompliant(false)]
		public unsafe void Write([AllowNull] Char* text, Int32 length, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(text, length, foreground, background);

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public void Write([AllowNull] System.Object obj) => Console.Write(obj);

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void Write([AllowNull] System.Object obj, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.Write(obj, foreground, background);
		#endregion

		#region WriteLine()
		/// <summary>
		/// Writes a line terminator to the standard output stream.
		/// </summary>
		public void WriteLine() => Console.WriteLine();

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine([AllowNull] String text) => Console.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine([AllowNull] String text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, foreground, background);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine([AllowNull] Char[] text) => Console.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine([AllowNull] Char[] text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, foreground, background);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine(Memory<Char> text) => Console.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine(Memory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, foreground, background);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine(ReadOnlyMemory<Char> text) => Console.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine(ReadOnlyMemory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, foreground, background);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine(Span<Char> text) => Console.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine(Span<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, foreground, background);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public void WriteLine(ReadOnlySpan<Char> text) => Console.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine(ReadOnlySpan<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, foreground, background);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public unsafe void WriteLine([AllowNull] Char* text, Int32 length) => Console.WriteLine(text, length);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		[CLSCompliant(false)]
		public unsafe void WriteLine([AllowNull] Char* text, Int32 length, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(text, length, foreground, background);

		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public void WriteLine([AllowNull] System.Object obj) => Console.WriteLine(obj);

		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public void WriteLine([AllowNull] System.Object obj, [AllowNull] Color foreground = null, [AllowNull] Color background = null) => Console.WriteLine(obj, foreground, background);
		#endregion
	}
}
