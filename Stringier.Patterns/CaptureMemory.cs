using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Capture"/> based on tracking a region of a source.
	/// </summary>
	internal sealed partial class CaptureMemory : Capture {
		/// <summary>
		/// The source of the <see cref="Capture"/>.
		/// </summary>
		public readonly ReadOnlyMemory<Char> Memory;

		/// <summary>
		/// Initializes a new <see cref="CaptureMemory"/>.
		/// </summary>
		/// <param name="source">The source of the <see cref="Capture"/>.</param>
		public CaptureMemory(ReadOnlyMemory<Char> source) => Memory = source;

		/// <inheritdoc/>
		public override nint Count => Memory.Length;

		/// <inheritdoc/>
		public override Char this[nint index] => Memory.Span[(Int32)index];

		/// <inheritdoc/>
		[return: NotNull]
		public override IEnumerator<Char> GetEnumerator() => new Enumerator(Memory);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Memory.ToString();
	}
}
