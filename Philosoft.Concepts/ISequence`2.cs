using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Concepts {
	/// <summary>
	/// Indicates the type is a sequence of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequence<out TElement, TEnumerator> : ICount where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// Returns an enumerator that iterates through the sequence.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		[return: NotNull]
		TEnumerator GetEnumerator();

		/// <summary>
		/// Returns a string that represents this sequence, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		[return: NotNull]
		String ToString(Int32 amount);
	}
}
