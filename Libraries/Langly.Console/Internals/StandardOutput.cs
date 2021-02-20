using System;
using System.Diagnostics.CodeAnalysis;
#if WINDOWS
using static PInvoke.Kernel32;
#endif

namespace Langly.Internals {
	/// <summary>
	/// Provides standard output behavior for the <see cref="Console"/>.
	/// </summary>
	internal sealed class StandardOutput : IConsoleWriter {
		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			Handle =
#if WINDOWS
			GetStdHandle(StdHandle.STD_OUTPUT_HANDLE);
#else
			null;
#endif

		private StandardOutput() { }

		/// <summary>
		/// A singleton instance of <see cref="StandardOutput"/>.
		/// </summary>
		internal static StandardOutput Instance => Singleton.Instance;

		/// <inheritdoc/>
		public Boolean Writable { get; }

		/// <inheritdoc/>
		[return: NotNull]
		public unsafe IConsoleWriter Write(Char element) {
#if WINDOWS
			WriteConsole(Handle, &element, 1, out _, IntPtr.Zero);
			return this;
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		[return: NotNull]
		public unsafe IConsoleWriter Write([AllowNull] Char* elements, Int32 length) {
			if (elements is null) {
				return this;
			}
#if WINDOWS
			WriteConsole(Handle, elements, length, out _, IntPtr.Zero);
			return this;
#else
			throw new PlatformNotSupportedException();
#endif
		}

		private static class Singleton {
			internal static readonly StandardOutput Instance = new StandardOutput();

			static Singleton() { }
		}
	}
}
