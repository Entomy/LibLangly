using System;

namespace Defender {
	/// <summary>
	/// Thrown when an <see cref="Asserter{T}"/> operation fails.
	/// </summary>
	internal sealed class AssertException : Exception {
		/// <inheritdoc/>
		public AssertException(String message) : base(message) { }

		/// <inheritdoc/>
		public AssertException(String message, Exception inner) : base(message, inner) { }
	}
}
