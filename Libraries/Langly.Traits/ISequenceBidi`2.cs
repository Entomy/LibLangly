using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is a bidirectional sequence of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
	/// <remarks>
	/// This interface devirtualizes the enumerator, and simplifies numerous parts of the interface through well defined defaults.
	/// </remarks>
	public interface ISequenceBidi<TElement, TEnumerator> : ISequence<TElement, TEnumerator> where TEnumerator : IEnumeratorBidi<TElement> {
		/// <summary>
		/// Gets a view of the members of this collection in reverse order.
		/// </summary>
		[return: NotNull]
		IEnumerator<TElement> Reverse();
	}
}
