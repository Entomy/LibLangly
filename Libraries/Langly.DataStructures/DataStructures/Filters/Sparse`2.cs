using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Filters {
	/// <summary>
	/// Represents a sparse filter, which handles index out of bounds situations without an exception.
	/// </summary>
	/// <typeparam name="TIndex">The type of the indicies of the collection being filtered.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection being filtered.</typeparam>
	internal sealed class Sparse<TIndex, TElement> : Filter<TIndex, TElement> {
		/// <summary>
		/// The default element.
		/// </summary>
		[MaybeNull]
		private static readonly TElement Default;

		/// <summary>
		/// Initializes a new <see cref="Sparse{TIndex, TElement}"/> filter.
		/// </summary>
		private Sparse() { }

		/// <summary>
		/// A <see cref="Sparse{TIndex, TElement}"/> filter singleton.
		/// </summary>
		public static Sparse<TIndex, TElement> Instance => Singleton.Instance;

		/// <inheritdoc/>
		[return: MaybeNull]
		public override ref readonly TElement IndexOutOfBounds([DisallowNull] IIndexRef<TIndex, TElement> collection, [AllowNull] TIndex index) => ref Default;

		/// <inheritdoc/>
		[return: MaybeNull]
		public override TElement IndexOutOfBounds([DisallowNull] IIndexReadOnly<TIndex, TElement> collection, [AllowNull] TIndex index) => Default;

		/// <inheritdoc/>
		[return: MaybeNull]
		public override ref readonly TElement IndexOutOfBounds([DisallowNull] IIndexRefReadOnly<TIndex, TElement> collection, [AllowNull] TIndex index) => ref Default;

		private static class Singleton {
			internal static readonly Sparse<TIndex, TElement> Instance = new Sparse<TIndex, TElement>();

			static Singleton() { }
		}
	}
}
