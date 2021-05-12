using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IInsertSpan<in TIndex, TElement> : IInsertMemory<TIndex, TElement> {
#if !NETSTANDARD1_3
		/// <inheritdoc/>
		void IInsertMemory<TIndex, TElement>.Insert([DisallowNull] TIndex index, [AllowNull] params TElement[] elements) => Insert(index, elements.AsSpan());

		/// <inheritdoc/>
		void IInsertMemory<TIndex, TElement>.Insert([DisallowNull] TIndex index, Memory<TElement> elements) => Insert(index, elements.Span);

		/// <inheritdoc/>
		void IInsertMemory<TIndex, TElement>.Insert([DisallowNull] TIndex index, ReadOnlyMemory<TElement> elements) => Insert(index, elements.Span);
#endif

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		void Insert([DisallowNull] TIndex index, Span<TElement> elements)
#if !NETSTANDARD1_3
			=> Insert(index, (ReadOnlySpan<TElement>)elements)
#endif
			;

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		void Insert([DisallowNull] TIndex index, ReadOnlySpan<TElement> elements);
	}
}

