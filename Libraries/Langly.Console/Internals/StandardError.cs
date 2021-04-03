using System;
using System.Diagnostics.CodeAnalysis;
#if WINDOWS
using static PInvoke.Kernel32;
#endif
using Langly.Traits;

namespace Langly.Internals {
	/// <summary>
	/// Provides standard error behavior for the <see cref="Console"/>.
	/// </summary>
	internal sealed class StandardError : IConsoleError {
		private static readonly
#if WINDOWS
			IntPtr
#else
			Object
#endif
			Handle =
#if WINDOWS
			GetStdHandle(StdHandle.STD_ERROR_HANDLE);
#else
			null;
#endif

		private StandardError() { }

		/// <summary>
		/// A singleton instance of <see cref="StandardError"/>.
		/// </summary>
		internal static StandardError Instance => Singleton.Instance;

		/// <inheritdoc/>
		public Boolean Writable { get; }

		/// <inheritdoc/>
		[return: NotNull]
		unsafe IConsoleError IAdd<Char, IConsoleError>.Add(Char element) {
#if WINDOWS
			WriteConsole(Handle, &element, 1, out _, IntPtr.Zero);
			return this;
#else
			throw new PlatformNotSupportedException();
#endif
		}

		/// <inheritdoc/>
		[return: NotNull]
		unsafe IConsoleError IAddUnsafe<Char, IConsoleError>.Add([AllowNull] Char* elements, Int32 length) {
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
			internal static readonly StandardError Instance = new StandardError();

			static Singleton() { }
		}
	}
}
