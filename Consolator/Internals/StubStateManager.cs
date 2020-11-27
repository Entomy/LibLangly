using System.Diagnostics.CodeAnalysis;

namespace Langly.Internals {
	/// <summary>
	/// Stubs out all state manager behavior.
	/// </summary>
	/// <remarks>
	/// This is primarily meant for debugging purposes, but could be used where VT Escape Sequences aren't supported.
	/// </remarks>
	public sealed class StubStateManager : IConsoleStateManager {
		/// <inheritdoc/>
		public void SetBackground([MaybeNull] Color value) { }

		/// <inheritdoc/>
		public void SetForeground([MaybeNull] Color value) { }
	}
}
