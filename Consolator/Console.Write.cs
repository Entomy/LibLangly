using System;
using System.Diagnostics.CodeAnalysis;
using Langly;

namespace Langly {
	public static partial class Console {
		#region Write()
		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write([MaybeNull] String text) {
			if (text is null) {
				return;
			}
			Internals.Writer.Write(text);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([MaybeNull] String text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (text is null) {
				return;
			}
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write([MaybeNull] Char[] text) {
			if (text is null) {
				return;
			}
			Internals.Writer.Write(text);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([MaybeNull] Char[] text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (text is null) {
				return;
			}
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Memory<Char> text) => Internals.Writer.Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(Memory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlyMemory<Char> text) => Internals.Writer.Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(ReadOnlyMemory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Span<Char> text) => Internals.Writer.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(Span<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlySpan<Char> text) => Internals.Writer.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(ReadOnlySpan<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Write([MaybeNull] Char* text, Int32 length) {
			if (text is null) {
				return;
			}
			Internals.Writer.Write(text, length);
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		[CLSCompliant(false)]
		public static unsafe void Write([MaybeNull] Char* text, Int32 length, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(text, length);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public static void Write([MaybeNull] Object obj) {
			if (obj is null) {
				return;
			}
			Internals.Writer.Write(obj.ToString());
		}

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([MaybeNull] Object obj, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(obj.ToString());
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the value to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <remarks>
		/// This is a special devirtualizing overload. If the type being written is both a value type and implements <see cref="IStringable{TSelf}"/>, then the devirtualized <see cref="IStringable{TSelf}.ToString()"/> will be used instead of <see cref="Object.ToString()"/>. This saves a heap allocation through boxing just to call a method.
		/// </remarks>
		public static void Write<TValue>(TValue value) where TValue : struct, IStringable<TValue> => Internals.Writer.Write(value.ToString());

		/// <summary>
		/// Writes the value to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		/// <remarks>
		/// This is a special devirtualizing overload. If the type being written is both a value type and implements <see cref="IStringable{TSelf}"/>, then the devirtualized <see cref="IStringable{TSelf}.ToString()"/> will be used instead of <see cref="Object.ToString()"/>. This saves a heap allocation through boxing just to call a method.
		/// </remarks>
		public static void Write<TValue>(TValue value, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.Write(value.ToString());
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}
		#endregion

		#region WriteLine()
		/// <summary>
		/// Writes a line terminator to the standard output stream.
		/// </summary>
		public static void WriteLine() => Internals.Writer.WriteLine();

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine([MaybeNull] String text) {
			if (text is null) {
				return;
			}
			Internals.Writer.WriteLine(text);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine([MaybeNull] String text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (text is null) {
				return;
			}
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine([MaybeNull] Char[] text) {
			if (text is null) {
				return;
			}
			Internals.Writer.WriteLine(text);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine([MaybeNull] Char[] text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (text is null) {
				return;
			}
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Memory<Char> text) => Internals.Writer.WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(Memory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text) => Internals.Writer.WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Span<Char> text) => Internals.Writer.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(Span<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlySpan<Char> text) => Internals.Writer.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(ReadOnlySpan<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void WriteLine([MaybeNull] Char* text, Int32 length) {
			if (text is null) {
				return;
			}
			Internals.Writer.WriteLine(text, length);
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		[CLSCompliant(false)]
		public static unsafe void WriteLine([MaybeNull] Char* text, Int32 length, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(text, length);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}


		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public static void WriteLine([MaybeNull] Object obj) {
			if (obj is null) {
				return;
			}
			Internals.Writer.WriteLine(obj.ToString());
		}

		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine([MaybeNull] Object obj, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (obj is null) {
				return;
			}
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(obj.ToString());
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the value and a line terminator to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <remarks>
		/// This is a special devirtualizing overload. If the type being written is both a value type and implements <see cref="IStringable{TSelf}"/>, then the devirtualized <see cref="IStringable{TSelf}.ToString()"/> will be used instead of <see cref="Object.ToString()"/>. This saves a heap allocation through boxing just to call a method.
		/// </remarks>
		public static void WriteLine<TValue>(TValue value) where TValue : struct, IStringable<TValue> => Internals.Writer.WriteLine(value.ToString());

		/// <summary>
		/// Writes the value and a line terminator to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine<TValue>(TValue value, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internals.StateManager.SetForeground(foreground);
			}
			if (background is not null) {
				Internals.StateManager.SetBackground(background);
			}
			Internals.Writer.WriteLine(value.ToString());
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}
		#endregion
	}
}
