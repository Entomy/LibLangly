using System;
using System.Diagnostics.CodeAnalysis;
#if WINDOWS
using static PInvoke.Kernel32;
#endif

namespace Langly.Internals {
	/// <summary>
	/// Provides standard input behavior for the <see cref="Console"/>.
	/// </summary>
	internal sealed class StandardInput : IConsoleReader {
		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			Handle =
#if WINDOWS
			GetStdHandle(StdHandle.STD_INPUT_HANDLE);
#else
			null;
#endif

		/// <summary>
		/// The buffer for reads.
		/// </summary>
		private readonly Memory<Char> Buffer;

		/// <summary>
		/// The length of the actual <see cref="Buffer"/>.
		/// </summary>
		private Int32 Length;

		/// <summary>
		/// The position within the <see cref="Buffer"/>.
		/// </summary>
		private Int32 Position;

		private StandardInput() {
			Buffer = new Char[256];
			Length = 0;
			Position = 0;
		}

		/// <summary>
		/// A singleton instance of <see cref="StandardInput"/>.
		/// </summary>
		internal static StandardInput Instance => Singleton.Instance;

		/// <inheritdoc/>
		public Boolean Readable => true;

		/// <inheritdoc/>
		[return: NotNull]
		public IConsoleReader Peek(out Char element) {
			if (Position == Length) {
				FillBuffer();
			}
			element = Buffer.Span[Position];
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public IConsoleReader Read(out Char element) {
			if (Position == Length) {
				FillBuffer();
			}
			element = Buffer.Span[Position++];
			return this;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public IConsoleReader ReadLine([NotNull] out String elements) {
			if (Position == Length) {
				FillBuffer();
			}
			Int32 i = 0;
#if WINDOWS
			Boolean MaybeEnding = false;
#endif
			foreach (Char item in Buffer.Span.Slice(Position)) {
#if WINDOWS
				if (MaybeEnding && item == '\n') {
					break;
				} else if (item == '\r') {
					MaybeEnding = true;
				}
#else
				if (item == '\n') {
					break;
				}
#endif
				i++;
			}
			elements = new String(Buffer.Span.Slice(Position, i));
			Position = i;
			return this;
		}

		private unsafe void FillBuffer() {
#if WINDOWS
			ReadConsole(Handle, Buffer.Span, out Length, null);
			Position = 0;
#else
			throw new PlatformNotSupportedException();
#endif
		}

		private static class Singleton {
			internal static readonly StandardInput Instance = new StandardInput();

			static Singleton() { }
		}
	}
}
