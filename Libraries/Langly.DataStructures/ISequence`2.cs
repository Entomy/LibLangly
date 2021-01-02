using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is a sequence of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequence<out TElement, out TEnumerator> : System.Collections.Generic.IEnumerable<TElement> where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// Returns an enumerator that iterates through the sequence.
		/// </summary>
		/// <returns>An enumerator that can be used to iterate through the collection.</returns>
		[return: NotNull]
		new TEnumerator GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.Generic.IEnumerator<TElement> System.Collections.Generic.IEnumerable<TElement>.GetEnumerator() => GetEnumerator();

		/// <inheritdoc/>
		[return: NotNull]
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
