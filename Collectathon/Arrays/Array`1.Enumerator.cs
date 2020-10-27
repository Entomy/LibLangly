using System;
using Philosoft;

namespace Collectathon.Arrays {
	public partial class Array<TElement, TSelf> : IEnumerable<TElement, Array<TElement, TSelf>.Enumerator> {
		/// <inheritdoc/>
		public sealed override Enumerator GetEnumerator() => new Enumerator(Elements, Length);

		/// <summary>
		/// Provides forward enumeration over <see cref="Array{TElement, TSelf}"/>.
		/// </summary>
		public struct Enumerator : IEnumerator<TElement> {
			private readonly Memory<TElement> Elements;

			private readonly nint Length;

			private nint i;

			/// <summary>
			/// Initializes a new <see cref="Enumerator"/>.
			/// </summary>
			/// <param name="elements">The elements to enumerate over.</param>
			/// <param name="length">The length of the <paramref name="elements"/>.</param>
			/// <remarks>
			/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="Array"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actual used portion.
			/// </remarks>
			public Enumerator(Memory<TElement> elements, nint length) {
				Elements = elements;
				Length = length;
				i = -1;
			}

			/// <inheritdoc/>
			public TElement Current => Elements.Span[(Int32)i];

			/// <inheritdoc/>
			public Boolean MoveNext() => ++i < Length;

			/// <inheritdoc/>
			public void Reset() => i = -1;
		}
	}
}
