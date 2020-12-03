using System;
using System.ComponentModel;

namespace Langly.DataStructures {
	/// <summary>
	/// Represents a limited view of an associative collection.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies being viewed.</typeparam>
	/// <typeparam name="TElement">The type of the elements being viewed.</typeparam>
	/// <typeparam name="TCollection">The type of the collection being viewed.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of this collection.</typeparam>
	public readonly struct ElementView<TIndex, TElement, TCollection, TEnumerator> : IContainable<TElement>, IEnumerable<TElement, ElementView<TIndex, TElement, TCollection, TEnumerator>.Enumerator>, IEquatable<ElementView<TIndex, TElement, TCollection, TEnumerator>> where TIndex : IEquatable<TIndex> where TCollection : IAssociator<TIndex, TElement, TCollection, TEnumerator>, IEnumerable<Association<TIndex, TElement>, TEnumerator> where TEnumerator : IEnumerator<Association<TIndex, TElement>> {
		private readonly TCollection Collection;

		internal ElementView(TCollection collection) => Collection = collection;

		public static Boolean operator !=(ElementView<TIndex, TElement, TCollection, TEnumerator> left, ElementView<TIndex, TElement, TCollection, TEnumerator> right) => !left.Equals(right);

		public static Boolean operator ==(ElementView<TIndex, TElement, TCollection, TEnumerator> left, ElementView<TIndex, TElement, TCollection, TEnumerator> right) => left.Equals(right);

		/// <inheritdoc/>
		Boolean IContainable<TElement>.Contains(TElement element) {
			foreach (Association<TIndex, TElement> association in Collection) {
				if (association.Element?.Equals(element) ?? false) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ElementView<TIndex, TElement, TCollection, TEnumerator> view:
				return Equals(view);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(ElementView<TIndex, TElement, TCollection, TEnumerator> other) => Collection.Equals(other.Collection);

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(Collection);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Int32 GetHashCode() => Collection.GetHashCode();

		public readonly struct Enumerator : IEnumerator<TElement> {
			private readonly IEnumerator<Association<TIndex, TElement>> enumerator;

			public Enumerator(TCollection collection) => enumerator = collection.GetEnumerator();

			/// <inheritdoc/>
			public TElement Current => enumerator.Current.Element;

			/// <inheritdoc/>
			public IEnumerator<TElement> GetEnumerator() => this;

			/// <inheritdoc/>
			public Boolean MoveNext() => enumerator.MoveNext();

			/// <inheritdoc/>
			public void Reset() => enumerator.Reset();
		}
	}
}
