using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits.Concepts;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over contiguous regions of memory.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies being enumerated.</typeparam>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct ArrayEnumerator<TIndex, TElement> : IEnumerator<(TIndex Index, TElement Element)> where TIndex : notnull {
		/// <summary>
		/// The <see cref="Array"/> of indicies being enumerated.
		/// </summary>
		private readonly TIndex[] Indicies;

		/// <summary>
		/// The <see cref="Array"/> of elements being enumerated.
		/// </summary>
		private readonly TElement[] Elements;

		/// <summary>
		/// The current index into the array./
		/// </summary>
		private Int32 i;

		/// <summary>
		/// Initializes a new <see cref="ArrayEnumerator{TElement}"/>.
		/// </summary>
		/// <param name="indicies">The indicies being enumerated.</param>
		/// <param name="elements">The elements being enumerated.</param>
		/// <param name="length">The length of the active array.</param>
		/// <remarks>
		/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="ReadOnlyMemory{T}"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actually used portion.
		/// </remarks>
		public ArrayEnumerator([DisallowNull] TIndex[] indicies, [DisallowNull] TElement[] elements, Int32 length) {
			Indicies = indicies;
			Elements = elements;
			Count = length;
			i = -1;
		}

		/// <inheritdoc/>
		public (TIndex Index, TElement Element) Current => (Indicies[i], Elements[i]);

		/// <inheritdoc/>
		public Int32 Count { get; }

		/// <inheritdoc/>
		public Boolean MoveNext() => ++i < Count;

		/// <inheritdoc/>
		public void Reset() => i = -1;
	}
}
