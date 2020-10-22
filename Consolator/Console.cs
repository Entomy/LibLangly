using System;
using System.Diagnostics.CodeAnalysis;
using static Consolator.UnsafeNativeMethods;
using Philosoft;
using System.ComponentModel;

namespace Consolator {
	/// <summary>
	/// Represents the standard input, output, and error streams.
	/// </summary>
	/// <remarks>
	/// This is intended as a replacement for <see cref="System.Console"/>. It bypasses much of the .NET runtime functionality, instead binding to the native console API's directly. It also operates in a uniquely different way, going for the direct API's rather than operating as a stream.
	/// </remarks>
	[SuppressMessage("Class Design", "AV1008:Class should not be static", Justification = "No. Just no.")]
	public static class Console {
		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			StdIn =
#if WINDOWS
			GetStdHandle(StdHandle.Input);
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
			GetStdHandle(StdHandle.Output);
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
			GetStdHandle(StdHandle.Error);
#else
			null;
#endif

		#region Read()
		#endregion

		#region ReadLine()
		#endregion

		#region Write()
		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(String text) {
			if (text is null) {
				return;
			}
			Write(text.AsSpan());
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Char[] text) {
			if (text is null) {
				return;
			}
			Write(text.AsSpan());
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Memory<Char> text) => Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(ReadOnlyMemory<Char> text) => Write(text.Span);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void Write(Span<Char> text) => Write((ReadOnlySpan<Char>)text);

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static unsafe void Write(ReadOnlySpan<Char> text) {
#if WINDOWS
			fixed (void* buffer = text) {
				if (!WriteConsole(StdOut, buffer, text.Length, out _, null)) {
					throw new Win32Exception(GetLastError());
				}
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <summary>
		/// Writes the text to the standard output stream.
		/// </summary>
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Write(Char* text, Int32 length) {
			if (text is null) {
				return;
			}
			Write(new ReadOnlySpan<Char>(text, length));
		}

		/// <summary>
		/// Writes the object to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public static void Write(Object obj) {
			if (obj is null) {
				return;
			}
			Write(obj.ToString());
		}

		/// <summary>
		/// Writes the value to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <remarks>
		/// This is a special devirtualizing overload. If the type being written is both a value type and implements <see cref="IStringable{TSelf}"/>, then the devirtualized <see cref="IStringable{TSelf}.ToString()"/> will be used instead of <see cref="Object.ToString()"/>. This saves a heap allocation through boxing just to call a method.
		/// </remarks>
		public static void Write<TValue>(TValue value) where TValue : struct, IStringable<TValue> => Write(value.ToString());
		#endregion

		#region WriteLine()
		/// <summary>
		/// Writes a line terminator to the standard output stream.
		/// </summary>
		public static void WriteLine() => WriteLine(Environment.NewLine);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(String text) {
			if (text is null) {
				return;
			}
			WriteLine(text.AsSpan());
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Char[] text) {
			if (text is null) {
				return;
			}
			WriteLine(text.AsSpan());
		}

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Memory<Char> text) => WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(ReadOnlyMemory<Char> text) => WriteLine(text.Span);

		/// <summary>
		/// Writes the text and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteLine(Span<Char> text) => WriteLine((ReadOnlySpan<Char>)text);

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
		/// <param name="text">The characters of the text to write.</param>
		/// <param name="length">The length of the <paramref name="text"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void WriteLine(Char* text, Int32 length) {
			if (text is null) {
				return;
			}
			WriteLine(new ReadOnlySpan<Char>(text, length));
		}

		/// <summary>
		/// Writes the object and a line terminator to the standard output stream.
		/// </summary>
		/// <param name="obj">The object to write.</param>
		public static void WriteLine(Object obj) {
			if (obj is null) {
				return;
			}
			WriteLine(obj.ToString());
		}

		/// <summary>
		/// Writes the value and a line terminator to the standard output stream.
		/// </summary>
		/// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
		/// <param name="value">The value to write.</param>
		/// <remarks>
		/// This is a special devirtualizing overload. If the type being written is both a value type and implements <see cref="IStringable{TSelf}"/>, then the devirtualized <see cref="IStringable{TSelf}.ToString()"/> will be used instead of <see cref="Object.ToString()"/>. This saves a heap allocation through boxing just to call a method.
		/// </remarks>
		public static void WriteLine<TValue>(TValue value) where TValue : struct, IStringable<TValue> => WriteLine(value.ToString());
		#endregion

		#region WriteError()
		/// <summary>
		/// Writes the text to the standard error stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public static void WriteError(String text) => throw new NotImplementedException();

		/// <summary>
		/// Writes the exception message to the standard error stream.
		/// </summary>
		/// <param name="exception">The exception providing the message to write.</param>
		public static void WriteError(Exception exception) => throw new NotImplementedException();
		#endregion

		/// <summary>
		/// Static initializer for <see cref="Console"/>.
		/// </summary>
		/// <remarks>
		/// This does any set up that is required on the operating system for appropriate console operations. Since we're making p/invoke calls, we can't do inline field initialization.
		/// </remarks>
		static Console() {
#if WINDOWS
			_ = SetMode(FileNo(GetStdHandle(StdHandle.Error)), FileControl.U16Text);
			_ = SetMode(FileNo(GetStdHandle(StdHandle.Input)), FileControl.U16Text);
			_ = SetMode(FileNo(GetStdHandle(StdHandle.Output)), FileControl.U16Text);
#endif
		}
	}
}
