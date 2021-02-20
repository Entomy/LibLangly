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

		private StandardInput() { }

		/// <summary>
		/// A singleton instance of <see cref="StandardInput"/>.
		/// </summary>
		internal static StandardInput Instance => Singleton.Instance;

		/// <inheritdoc/>
		public Boolean Readable => true;

		/// <inheritdoc/>
		[return: MaybeNull]
		public IConsoleReader Read(out Char element) {
#if WINDOWS
			throw new NotImplementedException();
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
