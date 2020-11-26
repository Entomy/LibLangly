using System;
using Langly;

namespace Collectathon.Views {
	/// <summary>
	/// Represents a reverse view of a collection.
	/// </summary>
	/// <typeparam name="TMember">The type being enumerated.</typeparam>
	/// <typeparam name="TCollection">The type of the collection being viewed.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of this collection.</typeparam>
	public readonly struct ReverseView<TMember, TCollection, TEnumerator> : IEnumerable<TMember, ReverseView<TMember, TCollection, TEnumerator>.Enumerator>, IEquatable<ReverseView<TMember, TCollection, TEnumerator>> where TCollection : IReversibleEnumerable<TMember, TCollection, TEnumerator> where TEnumerator : IReversibleEnumerator<TMember> {
		private readonly TCollection Collection;

		internal ReverseView(TCollection collection) => Collection = collection;

		public static Boolean operator !=(ReverseView<TMember, TCollection, TEnumerator> left, ReverseView<TMember, TCollection, TEnumerator> right) => !left.Equals(right);

		public static Boolean operator ==(ReverseView<TMember, TCollection, TEnumerator> left, ReverseView<TMember, TCollection, TEnumerator> right) => left.Equals(right);

		/// <inheritdoc/>
		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ReverseView<TMember, TCollection, TEnumerator> view:
				return Equals(view);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals(ReverseView<TMember, TCollection, TEnumerator> other) => Collection.Equals(other.Collection);

		/// <inheritdoc/>
		public override Int32 GetHashCode() => Collection.GetHashCode();

		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(Collection);

		public readonly struct Enumerator : IEnumerator<TMember> {
			private readonly TEnumerator enumerator;

			public Enumerator(TCollection collection) {
				enumerator = collection.GetEnumerator();
				enumerator.ResetEnding(); //Enumerators are initialized for the beginning by default, because that's the only enumerator .NET supports. We have to manually adjust this.
			}

			/// <inheritdoc/>
			public TMember Current => enumerator.Current;

			/// <inheritdoc/>
			public Boolean MoveNext() => enumerator.MovePrevious();

			/// <inheritdoc/>
			public void Reset() => enumerator.ResetEnding();
		}
	}
}
