using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly.DataStructures.Views {
	/// <summary>
	/// Provides a limited view of the indicies of a collection.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements of the collection.</typeparam>
	/// <typeparam name="TCollection">The type of the colletion being viewed.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
	[DebuggerDisplay("{ToString(5),nq}")]
	public readonly partial struct IndexView<TIndex, TElement, TCollection, TEnumerator>
		where TCollection : ISequence<(TIndex Index, TElement Element), TEnumerator>
		where TEnumerator : IEnumerator<(TIndex Index, TElement Element)> {
		/// <summary>
		/// The collection being viewed.
		/// </summary>
		[DisallowNull, NotNull]
		private readonly TCollection Collection;

		/// <summary>
		/// Initializes a new <see cref="IndexView{TIndex, TElement, TCollection, TEnumerator}"/>.
		/// </summary>
		/// <param name="collection">The collection to view.</param>
		public IndexView([DisallowNull] TCollection collection) => Collection = collection;

		/// <inheritdoc/>
		public nint Count => Collection.Count;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => ToString(Count);

		/// <summary>
		/// Returns a string that represents the current object, with no more than <paramref name="amount"/> elements.
		/// </summary>
		/// <param name="amount">The maximum amount of elements to display.</param>
		[return: NotNull]
		public String ToString(nint amount) { 
			StringBuilder builder = new StringBuilder();
			nint i = 0;
			foreach (TIndex index in this) {
				if (++i == Count) {
					_ = builder.Append(index);
					break;
				} else if (i == amount) {
					_ = builder.Append(index).Append("...");
					break;
				} else {
					_ = builder.Append(index).Append(", ");
				}
			}
			return $"[{builder}]";
		}
	}
}
