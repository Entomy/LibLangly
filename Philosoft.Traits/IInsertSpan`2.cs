using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the collection can have elements inserted into it.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies.</typeparam>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IInsertSpan<in TIndex, TElement> : IInsertMemory<TIndex, TElement> {
		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		void Insert([DisallowNull] TIndex index, Span<TElement?> elements);

		/// <summary>
		/// Inserts the elements into the collection at the specified index, as a batch.
		/// </summary>
		/// <param name="index">The index at which the <paramref name="elements"/> should be inserted.</param>
		/// <param name="elements">The elements to insert.</param>
		void Insert([DisallowNull] TIndex index, ReadOnlySpan<TElement?> elements);
	}
}

