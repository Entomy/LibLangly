using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Internals;

namespace Langly {
	/// <summary>
	/// Represents the alternate screen buffer of the <see cref="Console"/>.
	/// </summary>
	/// <remarks>
	/// This is not actually a buffer, but rather, a proxy to assist the programmer in managing and understanding the lifetime of alternate screen buffer. Furthermore, because it is exposed as a non-static type, it is possible to extend the buffer features by third-party libraries. Because extension methods would have to be called off this type, and if this type exists the buffer is currently active, then screen drawing techniques which apply only to the alternate screen buffer are greatly simplified.
	/// </remarks>
	[SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP009:Add IDisposable interface.", Justification = "We can't apply interfaces on ref structs.")]
	public ref struct ScreenBuffer {
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose() => ConsoleComponents.StateManager.UseMainScreenBuffer();
	}
}
