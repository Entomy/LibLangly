using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is indexable by unsafe elements.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	[CLSCompliant(false)]
	public interface IIndexUnsafe<TIndex, TElement> : IIndex<TIndex, TElement>, IIndexReadOnlyUnsafe<TIndex, TElement> where TIndex : unmanaged {
		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <param name="length">The length of the <paramref name="index"/>.</param>
		/// <returns>The element at the specified index.</returns>
		[AllowNull, MaybeNull]
		new unsafe TElement this[[DisallowNull] TIndex* index, Int32 length] { get; set; }

		/// <inheritdoc/>
		[MaybeNull]
		unsafe TElement IIndexReadOnlyUnsafe<TIndex, TElement>.this[[DisallowNull] TIndex* index, Int32 length] => this[index, length];
	}
}
