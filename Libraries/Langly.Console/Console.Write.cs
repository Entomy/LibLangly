using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Internals;

namespace Langly {
	public static partial class Console {
		#region Write()
		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write([AllowNull] String text) {
			if (text is null) {
				return;
			}
			ConsoleComponents.Writer.Write(text);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([AllowNull] String text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (text is null) {
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write([AllowNull] Char[] text) {
			if (text is null) {
				return;
			}
			ConsoleComponents.Writer.Write(text);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([AllowNull] Char[] text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (text is null) {
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Memory<Char> text) => ConsoleComponents.Writer.Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(Memory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text.Span);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlyMemory<Char> text) => ConsoleComponents.Writer.Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(ReadOnlyMemory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text.Span);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Span<Char> text) => ConsoleComponents.Writer.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(Span<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlySpan<Char> text) => ConsoleComponents.Writer.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(ReadOnlySpan<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Write([AllowNull] Char* text, Int32 length) {
			if (text is null) {
				return;
			}
			ConsoleComponents.Writer.Write(text, length);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		[CLSCompliant(false)]
		public static unsafe void Write([AllowNull] Char* text, Int32 length, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(text, length);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public static void Write([AllowNull] System.Object obj) {
			if (obj is null) {
				return;
			}
			ConsoleComponents.Writer.Write(obj.ToString());
		}

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([AllowNull] System.Object obj, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (obj is null) {
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.Write(obj.ToString());
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}
		#endregion

		#region WriteLine()
		/// <summary>
		/// Writes a line terminator to the standard output stream.
		/// </summary>
		public static void WriteLine() => ConsoleComponents.Writer.WriteLine();

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine([AllowNull] String text) {
			if (text is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			ConsoleComponents.Writer.WriteLine(text);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine([AllowNull] String text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (text is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine([AllowNull] Char[] text) {
			if (text is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			ConsoleComponents.Writer.WriteLine(text);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine([AllowNull] Char[] text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (text is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Memory<Char> text) => ConsoleComponents.Writer.WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(Memory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text.Span);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text) => ConsoleComponents.Writer.WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text.Span);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Span<Char> text) => ConsoleComponents.Writer.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(Span<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlySpan<Char> text) => ConsoleComponents.Writer.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(ReadOnlySpan<Char> text, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void WriteLine([AllowNull] Char* text, Int32 length) {
			if (text is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			ConsoleComponents.Writer.WriteLine(text, length);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		[CLSCompliant(false)]
		public static unsafe void WriteLine([AllowNull] Char* text, Int32 length, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (text is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(text, length);
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}


		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public static void WriteLine([AllowNull] System.Object obj) {
			if (obj is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			ConsoleComponents.Writer.WriteLine(obj.ToString());
		}

		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine([AllowNull] System.Object obj, [AllowNull] Color foreground = null, [AllowNull] Color background = null) {
			if (obj is null) {
				ConsoleComponents.Writer.WriteLine();
				return;
			}
			if (foreground is not null) {
				ConsoleComponents.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				ConsoleComponents.StateManager.SetBackground(background);
			}
			ConsoleComponents.Writer.WriteLine(obj.ToString());
			ConsoleComponents.StateManager.SetForeground(Foreground);
			ConsoleComponents.StateManager.SetBackground(Background);
		}
		#endregion
	}
}
