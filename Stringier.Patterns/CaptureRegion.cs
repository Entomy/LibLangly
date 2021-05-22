using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Capture"/> based on tracking a region of a source.
	/// </summary>
	/// <remarks>
	/// The actual captured text isn't held directly in this <see cref="Capture"/>. Instead, this designates both the source and region of the capture, potentially reassigning the region during operations, and retreives that slice when necessary. As a result, this is only ideal when working with entirely in-memory sources.
	/// </remarks>
	internal sealed class CaptureRegion : Capture {
		/// <summary>
		/// The source of the <see cref="Capture"/>.
		/// </summary>
		public readonly ReadOnlyMemory<Char> Source;

		/// <summary>
		/// The length of the <see cref="Capture"/>.
		/// </summary>
		public Int32 Length;

		/// <summary>
		/// The starting position of the <see cref="Capture"/>.
		/// </summary>
		public Int32 Start;

		/// <summary>
		/// Initializes a new <see cref="CaptureRegion"/>.
		/// </summary>
		/// <param name="source">The source of the <see cref="Capture"/>.</param>
		public CaptureRegion(ReadOnlyMemory<Char> source) => Source = source;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Source.Slice(Start, Length).ToString();
	}
}
