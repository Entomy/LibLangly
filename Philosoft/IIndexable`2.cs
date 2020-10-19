using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the collection is indexable, read and write.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "Agreed, they should. However this isn't even remotely possible in this situation.")]
	public interface IIndexable<in TIndex, TElement> : IReadOnlyIndexable<TIndex, TElement> {
		/// <summary>
		/// Gets or sets the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get or set.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="IIndexable{TIndex, TElement}"/>.</exception>
		/// <exception cref="NotSupportedException">The property is set and the <see cref="IIndexable{TIndex, TElement}"/> is read-only.</exception>
		new ref TElement this[TIndex index] { get; }
	}
}
