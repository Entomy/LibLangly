using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Traits;
using System.Traits.Concepts;

namespace Collectathon.Enumerators {
	/// <summary>
	/// Provides enumeration over contiguous regions of memory.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements being enumerated.</typeparam>
	[StructLayout(LayoutKind.Auto)]
	public struct ArrayEnumerator<TElement> : IEnumerator<TElement> {
		/// <summary>
		/// The <see cref="ReadOnlyMemory{T}"/> being enumerated.
		/// </summary>
		private readonly ReadOnlyMemory<TElement> Memory;

		/// <summary>
		/// The current index into the <see cref="Memory"/>.
		/// </summary>
		private Int32 i;

		/// <summary>
		/// Initializes a new <see cref="ArrayEnumerator{TElement}"/>.
		/// </summary>
		/// <param name="memory">The memory to enumerate over.</param>
		/// <param name="length">The length of the active <paramref name="memory"/>.</param>
		/// <remarks>
		/// At first it might seem like <paramref name="length"/> is superfluous, as <see cref="ReadOnlyMemory{T}"/> has a known length. However, many data structures use an array as an allocated chunk of memory, with the actual array as a portion of this, up to the entire chunk. <paramref name="length"/> is the actually used portion.
		/// </remarks>
		public ArrayEnumerator(ReadOnlyMemory<TElement> memory, Int32 length) {
			Memory = memory;
			Count = length;
			i = -1;
		}

		/// <inheritdoc/>
		[MaybeNull]
		public TElement Current => Memory.Span[i];

		/// <inheritdoc/>
		public Int32 Count { get; }

		/// <inheritdoc/>
		public Boolean MoveNext() => ++i < Count;

		/// <inheritdoc/>
		public void Reset() => i = -1;
	}
}
