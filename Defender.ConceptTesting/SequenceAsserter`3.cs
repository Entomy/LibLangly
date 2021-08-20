using System.Traits.Concepts;

namespace Defender {
	/// <summary>
	/// Represents the object having assertions made against it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <typeparam name="TCollection">The type of the collection being asserted.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of the collection.</typeparam>
	public class SequenceAsserter<TElement, TCollection, TEnumerator> : EnumerableAsserter<TElement, TCollection, TEnumerator> where TCollection : ISequence<TElement, TEnumerator> where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// Initializes a new <see cref="SequenceAsserter{TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		/// <param name="actual">The actual object being asserted.</param>
		public SequenceAsserter(TCollection actual) : base(actual) { }
	}
}
