using System;
using Collectathon;
using Collectathon.Views;

namespace Langly {
	/// <summary>
	/// Indicates the type associates values of two other types.
	/// </summary>
	/// <typeparam name="TIndex">The type of the index.</typeparam>
	/// <typeparam name="TElement">The type of the element.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	/// <typeparam name="TEnumerator">The type of the enumerator of this collection.</typeparam>
	public interface IAssociator<TIndex, TElement, TSelf, TEnumerator> where TIndex : IEquatable<TIndex> where TSelf : IAssociator<TIndex, TElement, TSelf, TEnumerator>, IEnumerable<Association<TIndex, TElement>, TEnumerator> where TEnumerator : IEnumerator<Association<TIndex, TElement>> {
		/// <summary>
		/// Gets a view of the indicies of this collection.
		/// </summary>
		IndexView<TIndex, TElement, TSelf, TEnumerator> Indicies { get; }

		/// <summary>
		/// Gets a view of the elements of this collection.
		/// </summary>
		ElementView<TIndex, TElement, TSelf, TEnumerator> Elements { get; }
	}
}
