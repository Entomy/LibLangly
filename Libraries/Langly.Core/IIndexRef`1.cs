using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type is indexable by reference, read and write.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	/// <remarks>
	/// This is just a convenience for the most common case of <see cref="IIndexRef{TIndex, TElement}"/>: indexed by integer.
	/// </remarks>
	public interface IIndexRef<TElement> : IIndexRef<nint, TElement>, IIndexRefReadOnly<TElement> {
		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the collection.
		/// </summary>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates the collection rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map(Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="Langly"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		void Map([DisallowNull] Func<TElement, TElement> func) {
			for (nint i = 0; i < Count; i++) {
				this[i] = func(this[i]);
			}
		}
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexRef{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="Langly"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static void Map<TElement>([AllowNull] this IIndexRef<TElement> collection, [AllowNull] Func<TElement, TElement> func) {
			if (collection is null || func is null) {
				return;
			}
			collection.Map(func);
		}
	}
}
