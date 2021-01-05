using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Arrays {
	/// <summary>
	/// Represents any array type.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the array.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <remarks>
	/// This is intended as a reusable base for implementing special behaviors on top of rank 1 arrays.
	/// </remarks>
	public abstract partial class Array<TElement, TSelf> : DataStructure<TElement, TSelf, Array<TElement, TSelf>.Enumerator>,
		ICapacity,
		IIndexRef<TElement>,
		IShift
		where TSelf : Array<TElement, TSelf> {
		/// <summary>
		/// The backing memory.
		/// </summary>
		protected Memory<TElement> Elements;

		/// <summary>
		/// Initializes a new <see cref="Array{TElement, TSelf}"/> with the given <paramref name="capacity"/>.
		/// </summary>
		/// <param name="capacity">The capacity; how many elements it can hold.</param>
		[SuppressMessage("Performance", "HAA0501:Explicit new array type allocation", Justification = "This has to allocate by definition.")]
		protected Array(nint capacity) => Elements = new TElement[capacity];

		/// <summary>
		/// Initializes a new <see cref="Array{TElement, TSelf}"/> with the given <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The elements of the array.</param>
		protected Array(Memory<TElement> elements) => Elements = elements;

		/// <inheritdoc/>
		public nint Capacity => Elements.Length;

		/// <inheritdoc/>
		public override nint Count => Elements.Length;

		/// <inheritdoc/>
		public ref TElement this[nint index] => ref Elements.Span[(Int32)index];

		/// <inheritdoc/>
		ref readonly TElement IIndexRefReadOnly<nint, TElement>.this[nint index] => ref this[index];

		/// <inheritdoc/>
		void IShift.ShiftLeft(nint amount) {
			Int32 i = 0;
			for (; i < Count - amount; i++) {
				Elements.Span[i] = Elements.Span[(Int32)(i + amount)];
			}
			for (; i < Count; i++) {
				Elements.Span[i] = default;
			}
		}

		/// <inheritdoc/>
		void IShift.ShiftRight(nint amount) {
			Int32 i = (Int32)(Count - 1);
			for (; i >= amount; i--) {
				Elements.Span[i] = Elements.Span[(Int32)(i - amount)];
			}
			for (; i >= 0; i--) {
				Elements.Span[i] = default;
			}
		}
	}
}
