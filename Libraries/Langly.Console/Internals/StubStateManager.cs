using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.Internals {
	/// <summary>
	/// Stubs out all state manager behavior.
	/// </summary>
	/// <remarks>
	/// This is primarily meant for debugging purposes, but could be used where VT Escape Sequences aren't supported.
	/// </remarks>
	[SuppressMessage("Critical Code Smell", "S1186:Methods should not be empty", Justification = "That's literally the entire point of this class.")]
	public sealed class StubStateManager : IConsoleStateManager {
		/// <inheritdoc/>
		public void SetBackground([AllowNull] Color value) { }

		/// <inheritdoc/>
		public void SetForeground([AllowNull] Color value) { }

		/// <inheritdoc/>
		public void SetTitle([AllowNull] String title) { }

		/// <inheritdoc/>
		public void UseAlternateScreenBuffer() { }

		/// <inheritdoc/>
		public void UseMainScreenBuffer() { }
	}
}
