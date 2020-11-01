using System;
using System.Diagnostics.CodeAnalysis;
using static PInvoke.Kernel32;

namespace Consolator {
	public static partial class Console {
		/// <summary>
		/// Internal implementation details to <see cref="Console"/>.
		/// </summary>
		/// <remarks>
		/// This is mostly to provide wrappers around system specific behavior while also not including <see cref="Consolator"/> behavior, like avoiding events. Everything should be implemented with these functions.
		/// </remarks>
		internal static class Internal {
			/// <summary>
			/// Sets the background color to the <paramref name="value"/>.
			/// </summary>
			/// <param name="value">The <see cref="Color"/> to set.</param>
			internal static void SetBackground([MaybeNull] Color value) {
				switch (value) {
				case SimpleColor color:
					Write($"\x1B[{40 + color.Code}m");
					break;
				case ComplexColor color:
					Write($"\x1B[48;2;{color.Red};{color.Green};{color.Blue}m");
					break;
				default:
					Write("\x1B[49m");
					break;
				}
			}

			/// <summary>
			/// Sets the foreground color to the <paramref name="value"/>.
			/// </summary>
			/// <param name="value">The <see cref="Color"/> to set.</param>
			internal static void SetForeground([MaybeNull] Color value) {
				switch (value) {
				case SimpleColor color:
					Write($"\x1B[{30 + color.Code}m");
					break;
				case ComplexColor color:
					Write($"\x1B[38;2;{color.Red};{color.Green};{color.Blue}m");
					break;
				default:
					Write("\x1B[39m");
					break;
				}
			}

			/// <summary>
			/// Writes the text to the standard output stream.
			/// </summary>
			/// <param name="text">The text to write.</param>
			public static unsafe void Write(ReadOnlySpan<Char> text) {
				fixed (void* buffer = text) {
					_ = WriteConsole(StdOut, buffer, text.Length, out _, IntPtr.Zero);
				}
			}

			/// <summary>
			/// Writes the text to the standard output stream.
			/// </summary>
			/// <param name="text">The characters of the text to write.</param>
			/// <param name="length">The length of the <paramref name="text"/>.</param>
			[CLSCompliant(false)]
			public static unsafe void Write([NotNull] Char* text, Int32 length) => WriteConsole(StdOut, text, length, out _, IntPtr.Zero);

			/// <summary>
			/// Writes a line terminator to the standard output stream.
			/// </summary>
			public static unsafe void WriteLine() {
				fixed (void* buffer = "\r\n") {
					WriteConsole(StdOut, buffer, 2, out _, IntPtr.Zero);
				}
			}

			/// <summary>
			/// Writes the text and a line terminator to the standard output stream.
			/// </summary>
			/// <param name="text">The text to write.</param>
			public static void WriteLine(ReadOnlySpan<Char> text) {
				Write(text);
				WriteLine();
			}

			/// <summary>
			/// Writes the text and a line terminator to the standard output stream.
			/// </summary>
			/// <param name="text">The text to write.</param>
			/// <param name="length">The length of the <paramref name="text"/>.</param>
			public static unsafe void WriteLine([NotNull] Char* text, Int32 length) {
				Write(text, length);
				WriteLine();
			}
		}
	}
}
