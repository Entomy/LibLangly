using System;
using System.Diagnostics.CodeAnalysis;
using static PInvoke.Kernel32;

namespace Langly.Internals {
	/// <summary>
	/// Provides the standard <see cref="Console"/> behavior.
	/// </summary>
	internal sealed class StandardConsole : IConsoleReader, IConsoleWriter, IConsoleErrorWriter {
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

		private StandardConsole() { }

		internal static StandardConsole Instance => Singleton.Instance;

		/// <inheritdoc/>
		unsafe void IConsoleWriter.Write(ReadOnlySpan<Char> text) {
#if WINDOWS
			fixed (void* buffer = text) {
				_ = WriteConsole(StdOut, buffer, text.Length, out _, IntPtr.Zero);
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		unsafe void IConsoleWriter.Write([NotNull] Char* text, Int32 length) {
#if WINDOWS
			WriteConsole(StdOut, text, length, out _, IntPtr.Zero);
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		unsafe void IConsoleErrorWriter.Write(ReadOnlySpan<Char> text) {
#if WINDOWS
			fixed (void* buffer = text) {
				_ = WriteConsole(StdErr, buffer, text.Length, out _, IntPtr.Zero);
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		unsafe void IConsoleErrorWriter.Write(Char* text, Int32 length) {
#if WINDOWS
			WriteConsole(StdErr, text, length, out _, IntPtr.Zero);
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		unsafe void IConsoleWriter.WriteLine() {
#if WINDOWS
			fixed (void* buffer = "\r\n") {
				WriteConsole(StdOut, buffer, 2, out _, IntPtr.Zero);
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		unsafe void IConsoleErrorWriter.WriteLine() {
#if WINDOWS
			fixed (void* buffer = "\r\n") {
				WriteConsole(StdErr, buffer, 2, out _, IntPtr.Zero);
			}
#else
			throw new PlatformNotSupportedException();
#endif
		}

		private static class Singleton {
			internal static readonly StandardConsole Instance = new StandardConsole();

			static Singleton() { }
		}
	}
}
