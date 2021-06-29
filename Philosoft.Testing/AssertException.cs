using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Thrown when an <see cref="Assert{T}"/> operation fails.
	/// </summary>
	internal sealed class AssertException : Exception {
		/// <inheritdoc/>
		public AssertException([DisallowNull] String message) : base(message) { }

		/// <inheritdoc/>
		public AssertException([DisallowNull] String message, [DisallowNull] Exception inner) : base(message, inner) { }
	}
}
