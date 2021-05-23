using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Capture"/> based on tracking a region of a source.
	/// </summary>
	internal sealed unsafe partial class CapturePointer : Capture {
		/// <summary>
		/// The length of the <see cref="Capture"/>.
		/// </summary>
		public readonly Int32 Length;

		/// <summary>
		/// The starting address of the <see cref="Capture"/>.
		/// </summary>
		[DisallowNull, NotNull]
		public readonly Char* Pointer;

		/// <summary>
		/// Initializes a new <see cref="CapturePointer"/>.
		/// </summary>
		/// <param name="pointer">The starting address of the <see cref="Capture"/>.</param>
		/// <param name="length">The length of the <see cref="Capture"/>.</param>
		public CapturePointer([DisallowNull] Char* pointer, Int32 length) {
			Pointer = pointer;
			Length = length;
		}

		/// <inheritdoc/>
		public override nint Count => Length;

		/// <inheritdoc/>
		public override Char this[nint index] => Pointer[index];

		/// <inheritdoc/>
		[return: NotNull]
		public override IEnumerator<Char> GetEnumerator() => new Enumerator(Pointer, Length);

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => new String(Pointer, 0, Length);
	}
}
