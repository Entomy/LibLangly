using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Capture"/> which doesn't actually do anything.
	/// </summary>
	/// <remarks>
	/// This is meant to handle the situation where <see cref="MutablePattern.Capture(out Capture)"/> is called when the <see cref="MutablePattern"/> hasn't been assigned.
	/// </remarks>
	internal sealed class CaptureDummy : Capture {
		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => String.Empty;
	}
}
