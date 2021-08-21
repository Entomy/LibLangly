namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type is a sequence of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequence<TElement, TEnumerator> :
		ICount,
		IEquatable<TElement[]?>, IEquatable<ArraySegment<TElement>>, IEquatable<Memory<TElement>>, IEquatable<ReadOnlyMemory<TElement>>,
		IGetEnumerator<TElement, TEnumerator>
		where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.</returns>
		Boolean Equals(Span<TElement> other);

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.</returns>
		Boolean Equals(ReadOnlySpan<TElement> other);

		/// <summary>
		/// Returns a string that represents this sequence, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		String ToString(Int32 amount);
	}
}
