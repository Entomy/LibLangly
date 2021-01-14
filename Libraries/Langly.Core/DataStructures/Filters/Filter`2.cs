using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Filters {
	/// <summary>
	/// Represents a filter, a psuedostructure which helps a proper data structure to behave differently.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection being filtered.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection being filtered.</typeparam>
	/// <remarks>
	/// This uses combinator theory to mix filter behavior into one single object, which greatly simplifies hooking up a filter to a data structure, which is done per data structure.
	/// </remarks>
	public abstract class Filter<TIndex, TElement> : Object {
		/// <summary>
		/// Initializes a new <see cref="Filter{TIndex, TElement}"/>.
		/// </summary>
		protected Filter() { }

		/// <summary>
		/// Modifies the <paramref name="index"/> in accordance to this filter.
		/// </summary>
		/// <param name="index">The original index.</param>
		/// <returns>The filtered index.</returns>
		[return: NotNull]
		public virtual TIndex Index([DisallowNull] TIndex index) => index;

		/// <summary>
		/// Handles the <paramref name="index"/> being out of bounds.
		/// </summary>
		/// <param name="collection">The collection that was indexed.</param>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if the filter can't handle the <paramref name="index"/> being out of bounds.</exception>
		[return: MaybeNull]
		public virtual TElement IndexOutOfBounds([DisallowNull] IIndexReadOnly<TIndex, TElement> collection, [AllowNull] TIndex index) => throw new IndexOutOfRangeException();

		/// <summary>
		/// Handles the <paramref name="index"/> being out of bounds.
		/// </summary>
		/// <param name="collection">The collection that was indexed.</param>
		/// <param name="index">The index of the element to set.</param>
		/// <param name="element"></param>
		/// <exception cref="IndexOutOfRangeException">Thrown if the filter can't handle the <paramref name="index"/> being out of bounds.</exception>
		[return: MaybeNull]
		public virtual void IndexOutOfBounds([DisallowNull] IIndex<TIndex, TElement> collection, [AllowNull] TIndex index, [AllowNull] TElement element) => throw new IndexOutOfRangeException();

		/// <summary>
		/// Handles the <paramref name="index"/> being out of bounds.
		/// </summary>
		/// <param name="collection">The collection that was indexed.</param>
		/// <param name="index">The index of the element to reference.</param>
		/// <returns>A readonly reference to the element at the specified index.</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if the filter can't handle the <paramref name="index"/> being out of bounds.</exception>
		[return: MaybeNull]
		public virtual ref readonly TElement IndexOutOfBounds([DisallowNull] IIndexRefReadOnly<TIndex, TElement> collection, [AllowNull] TIndex index) => throw new IndexOutOfRangeException();

		/// <summary>
		/// Handles the <paramref name="index"/> being out of bounds.
		/// </summary>
		/// <param name="collection">The collection that was indexed.</param>
		/// <param name="index">The index of the element to reference.</param>
		/// <returns>A readonly reference to the element at the specified index.</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if the filter can't handle the <paramref name="index"/> being out of bounds.</exception>
		[return: MaybeNull]
		public virtual ref readonly TElement IndexOutOfBounds([DisallowNull] IIndexRef<TIndex, TElement> collection, [AllowNull] TIndex index) => throw new IndexOutOfRangeException();
	}
}
