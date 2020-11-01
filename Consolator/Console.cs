using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Philosoft;
using PInvoke;
using static PInvoke.Kernel32;

namespace Consolator {
	/// <summary>
	/// Represents the standard input, output, and error streams.
	/// </summary>
	/// <remarks>
	/// This is intended as a replacement for <see cref="System.Console"/>. It bypasses much of the .NET runtime functionality, instead binding to the native console API's directly. It also operates in a uniquely different way, going for the direct API's rather than operating as a stream.
	/// </remarks>
	[SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "No. Just no.")]
	[SuppressMessage("Blocker Code Smell", "S3427:Method overloads with default parameter values should not overlap ", Justification = "Yet again, Sonar doesn't understand patterns.")]
	public static partial class Console {
		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			StdIn =
#if WINDOWS
			GetStdHandle(StdHandle.STD_INPUT_HANDLE);
#else
			null;
#endif

		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			StdOut =
#if WINDOWS
			GetStdHandle(StdHandle.STD_OUTPUT_HANDLE);
#else
			null;
#endif

		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			StdErr =
#if WINDOWS
			GetStdHandle(StdHandle.STD_ERROR_HANDLE);
#else
			null;
#endif

		/// <summary>
		/// Gets the alternate screen buffer, and actives it.
		/// </summary>
		public static ScreenBuffer Buffer {
			get {
				Internal.Write("\x1B[?1049h");
				return ScreenBuffer.Instance;
			}
		}

		/// <summary>
		/// Gets or sets the console window title.
		/// </summary>
		[SuppressMessage("Design", "CA1044:Properties should not be write only", Justification = "There's no corresponding get-title sequence we can use.")]
		[SuppressMessage("Major Code Smell", "S2376:Write-only properties should not be used", Justification = "There's no corresponding get-title sequence we can use.")]
		public static String Title {
			set {
				if (value is not null) {
					Internal.WriteLine($"\x1B]2;{value}\b");
				} else {
					using Process process = Process.GetCurrentProcess();
					Internal.WriteLine($"\x1B]2;{process.ProcessName}\b");
				}
			}
		}

		#region Read()
		#endregion

		#region ReadLine()
		#endregion

		#region Write()
		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write([MaybeNull] String text) {
			if (text is null) {
				return;
			}
			Internal.Write(text);
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text);
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
			Internal.Write(text);
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Memory<Char> text) => Internal.Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(Memory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlyMemory<Char> text) => Internal.Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(ReadOnlyMemory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Span<Char> text) => Internal.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(Span<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlySpan<Char> text) => Internal.Write(text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write(ReadOnlySpan<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text);
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
			Internal.Write(text, length);
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(text, length);
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
			Internal.Write(obj.ToString());
		}

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void Write([MaybeNull] Object obj, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(obj.ToString());
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
		public static void Write<TValue>(TValue value) where TValue : struct, IStringable<TValue> => Internal.Write(value.ToString());

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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.Write(value.ToString());
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}
		#endregion

		#region WriteLine()
		/// <summary>
		/// Writes a line terminator to the standard output stream.
		/// </summary>
		public static void WriteLine() => Internal.WriteLine();

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine([MaybeNull] String text) {
			if (text is null) {
				return;
			}
			Internal.WriteLine(text);
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text);
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
			Internal.WriteLine(text);
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Memory<Char> text) => Internal.WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(Memory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text) => Internal.WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text.Span);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Span<Char> text) => Internal.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(Span<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text);
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlySpan<Char> text) => Internal.WriteLine(text);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine(ReadOnlySpan<Char> text, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text);
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
			Internal.WriteLine(text, length);
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(text, length);
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
			Internal.WriteLine(obj.ToString());
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
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(obj.ToString());
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
		public static void WriteLine<TValue>(TValue value) where TValue : struct, IStringable<TValue> => Internal.WriteLine(value.ToString());

		/// <summary>
		/// Writes the value and a line terminator to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <param name="foreground">The foreground color to use; <see langword="null"/> to use current.</param>
		/// <param name="background">The background color to use; <see langword="null"/> to use current.</param>
		public static void WriteLine<TValue>(TValue value, [MaybeNull] Color foreground = null, [MaybeNull] Color background = null) {
			if (foreground is not null) {
				Internal.SetForeground(foreground);
			}
			if (background is not null) {
				Internal.SetBackground(background);
			}
			Internal.WriteLine(value.ToString());
			Foreground.Color = Foreground.Current;
			Background.Color = Background.Current;
		}
		#endregion

		#region WriteError()
		/// <summary>
		/// Writes the exception message to the standard error stream.
		/// </summary>
		/// <param name="exception">The exception providing the message to write.</param>
		public static void WriteError(Exception exception) {
			if (exception is null) {
				return;
			}
			Internal.SetForeground(Color.Red);
			Internal.Write(" Error: ");
			Foreground.Color = Foreground.Current;
			Internal.WriteLine(exception.Message);
		}
		#endregion
	}
}
