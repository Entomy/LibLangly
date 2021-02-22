using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is indexable by unsafe elements, read only.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	[CLSCompliant(false)]
	public interface IIndexReadOnlyUnsafe<in TIndex, out TElement> : IIndexReadOnly<TIndex, TElement> where TIndex : unmanaged {
		/// <summary>
		/// Gets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <param name="length">The length of the <paramref name="index"/>.</param>
		/// <returns>The element at the specified index.</returns>
		[MaybeNull]
		unsafe TElement this[[DisallowNull] TIndex* index, Int32 length] { get; }
	}
}
