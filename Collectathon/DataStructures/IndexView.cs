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
	public readonly struct IndexView<TIndex, TElement, TCollection, TEnumerator> : IContainable<TIndex>, IEnumerable<TIndex, IndexView<TIndex, TElement, TCollection, TEnumerator>.Enumerator>, IEquatable<IndexView<TIndex, TElement, TCollection, TEnumerator>> where TIndex : IEquatable<TIndex> where TCollection : IAssociator<TIndex, TElement, TCollection, TEnumerator>, IEnumerable<Association<TIndex, TElement>, TEnumerator> where TEnumerator : IEnumerator<Association<TIndex, TElement>> {
		private readonly TCollection Collection;

		internal IndexView(TCollection collection) => Collection = collection;

		public static Boolean operator !=(IndexView<TIndex, TElement, TCollection, TEnumerator> left, IndexView<TIndex, TElement, TCollection, TEnumerator> right) => !left.Equals(right);

		public static Boolean operator ==(IndexView<TIndex, TElement, TCollection, TEnumerator> left, IndexView<TIndex, TElement, TCollection, TEnumerator> right) => left.Equals(right);

		/// <inheritdoc/>
		Boolean IContainable<TIndex>.Contains(TIndex element) {
			foreach (Association<TIndex, TElement> association in Collection) {
				if (association.Index?.Equals(element) ?? false) {
					return true;
				}
			}
			return false;
		}

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case IndexView<TIndex, TElement, TCollection, TEnumerator> view:
				return Equals(view);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(IndexView<TIndex, TElement, TCollection, TEnumerator> other) => Collection.Equals(other.Collection);

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(Collection);

		/// <inheritdoc/>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Int32 GetHashCode() => Collection.GetHashCode();

		public readonly struct Enumerator : IEnumerator<TIndex> {
			private readonly IEnumerator<Association<TIndex, TElement>> enumerator;

			public Enumerator(TCollection collection) => enumerator = collection.GetEnumerator();

			/// <inheritdoc/>
			public TIndex Current => enumerator.Current.Index;

			/// <inheritdoc/>
			public IEnumerator<TIndex> GetEnumerator() => this;

			/// <inheritdoc/>
			public Boolean MoveNext() => enumerator.MoveNext();

			/// <inheritdoc/>
			public void Reset() => enumerator.Reset();
		}
	}
}
