#if NET5_0_OR_GREATER
using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Capture"/> which doesn't actually do anything.
	/// </summary>
	/// <remarks>
	/// This is meant to handle the situation where <see cref="MutablePattern.Capture(out Capture)"/> is called when the <see cref="MutablePattern"/> hasn't been assigned.
	/// </remarks>
	internal sealed class CaptureDummy : Capture {
		/// <inheritdoc/>
		public override nint Count => 0;

		/// <inheritdoc/>
		public override Char this[[DisallowNull] nint index] => throw new IndexOutOfRangeException();

		/// <inheritdoc/>
		[return: NotNull]
		public override IEnumerator<Char> GetEnumerator() => new Enumerator();

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => String.Empty;

		/// <summary>
		/// Provides enumeration over a <see cref="CaptureDummy"/>.
		/// </summary>
		private readonly struct Enumerator : IEnumerator<Char> {
			/// <inheritdoc/>
			public Char Current => throw new InvalidOperationException();

			/// <inheritdoc/>
			public nint Count => 0;

			/// <inheritdoc/>
			public Boolean MoveNext() => false;

			/// <inheritdoc/>
			public void Reset() { /* No-op */ }

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => String.Empty;

			/// <inheritdoc/>
			[return: NotNull]
			public String ToString(nint amount) => String.Empty;
		}
	}
}
#endif
