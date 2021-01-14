using System.ComponentModel;

namespace Langly.DataStructures.Views {
	/// <summary>
	/// Represents a limited view of a collection as a simple sequence.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TCollection">The type of the collection being viewed.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of this collection.</typeparam>
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public readonly struct SequenceView<TElement, TCollection, TEnumerator> :
		ISequence<TElement, TEnumerator>
		where TCollection : ISequence<TElement, TEnumerator>
		where TEnumerator : IEnumerator<TElement> {
		/// <summary>
		/// The collection being viewed.
		/// </summary>
		private readonly TCollection Collection;

		/// <summary>
		/// Initialize a new <see cref="SequenceView{TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		/// <param name="collection">The collection to view.</param>
		public SequenceView(TCollection collection) => Collection = collection;

		/// <inheritdoc/>
		public nint Count => Collection.Count;

		/// <inheritdoc/>
		public TEnumerator GetEnumerator() => Collection.GetEnumerator();
	}
}
