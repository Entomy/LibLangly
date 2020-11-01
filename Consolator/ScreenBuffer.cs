using Defender.Patterns;
using System;

namespace Consolator {
	/// <summary>
	/// Represents the alternate screen buffer of the <see cref="Console"/>.
	/// </summary>
	/// <remarks>
	/// This is not actually a buffer, but rather, a proxy to assist the programmer in managing and understanding the lifetime of alternate screen buffer. Furthermore, because it is exposed as a singleton, it is possible to extend the buffer features by third-party libraries. Because extension methods would have to be called off this type, and if this type exists the buffer is currently active, then screen drawing techniques which apply only to the alternate screen buffer are greatly simplified.
	/// </remarks>
	public sealed class ScreenBuffer : Controlled {
		/// <summary>
		/// Initializes a new <see cref="ScreenBuffer"/> instance.
		/// </summary>
		private ScreenBuffer() { }

		/// <summary>
		/// Gets a singleton instance of the <see cref="ScreenBuffer"/>.
		/// </summary>
		internal static ScreenBuffer Instance => Singleton.Instance;

		private static class Singleton {
			internal static readonly ScreenBuffer Instance = new ScreenBuffer();

			static Singleton() { }
		}

		/// <inheritdoc/>
		protected override void DisposeUnmanaged() => Console.Internal.Write("\x1B[?1049l");
	}
}
