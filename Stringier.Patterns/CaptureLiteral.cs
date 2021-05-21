using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier {
	/// <summary>
	/// Represents a capture literal pattern, a pattern matching this exact capture.
	/// </summary>
	/// <remarks>
	/// This exists to get around visibility rules. <see cref="Stringier.Pattern"/> is <see langword="internal"/> and as a result can't have a public child. <see cref="Stringier.Capture"/> needs to be public because downstream needs to allocate and use captures.
	/// </remarks>
	internal sealed class CaptureLiteral : Literal {
		/// <summary>
		/// The actual <see cref="Stringier.Capture"/> object.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly Capture CapStore;

		/// <summary>
		/// Initialize a new <see cref="CaptureLiteral"/> with the given <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Stringier.Capture"/> to parse.</param>
		internal CaptureLiteral([DisallowNull] Capture capture) : this(capture, default) { }

		/// <summary>
		/// Initialize a new <see cref="CaptureLiteral"/> with the given <paramref name="capture"/>.
		/// </summary>
		/// <param name="capture">The <see cref="Stringier.Capture"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="Case"/> to use when parsing.</param>
		internal CaptureLiteral([DisallowNull] Capture capture, Case comparisonType) : base(comparisonType) => CapStore = capture;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => CapStore.ToString();
	}
}
