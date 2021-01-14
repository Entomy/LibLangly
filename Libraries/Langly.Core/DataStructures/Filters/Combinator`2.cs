using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Filters {
	/// <summary>
	/// Represents the combination of multiple <see cref="Filter{TIndex, TElement}"/>.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection being filtered.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection being filtered.</typeparam>
	internal sealed class Combinator<TIndex, TElement> : Filter<TIndex, TElement> {
		/// <summary>
		/// The first filter.
		/// </summary>
		[NotNull, DisallowNull]
		private readonly Filter<TIndex, TElement> First;

		/// <summary>
		/// The second filter.
		/// </summary>
		[NotNull, DisallowNull]
		private readonly Filter<TIndex, TElement> Second;

		/// <summary>
		/// Initializes a new <see cref="Combinator{TIndex, TElement}"/>.
		/// </summary>
		/// <param name="first">The first filter.</param>
		/// <param name="second">The second filter.</param>
		public Combinator([DisallowNull] Filter<TIndex, TElement> first, [DisallowNull] Filter<TIndex, TElement> second) {
			First = first;
			Second = second;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override TIndex Index([DisallowNull] TIndex index) => Second.Index(First.Index(index));
	}
}
