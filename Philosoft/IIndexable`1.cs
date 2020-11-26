using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the collection is indexable, read and write.
	/// </summary>
	/// <typeparam name="TElement">The type in the collection.</typeparam>
	[SuppressMessage("Major Code Smell", "S3246:Generic type parameters should be co/contravariant when possible", Justification = "Agreed, they should. However this isn't even remotely possible in this situation.")]
	public interface IIndexable<TElement> : IIndexable<nint, TElement>, IReadOnlyIndexable<TElement> {
		/// <summary>
		/// Applies the <paramref name="func"/> to each element of this collection
		/// </summary>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates this collection rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map(Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="Philosoft"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		void Map(Func<TElement, TElement> func) {
			if (func is null) {
				return;
			}
			for (nint i = 0; i < Count; i++) {
				this[i] = func(this[i]);
			}
		}
	}

	public static partial class Extensions {
		/// <summary>
		/// Applies the <paramref name="func"/> to each element of the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="func">The <see cref="Func{T, TResult}"/> to apply to each element.</param>
		/// <remarks>
		/// This is a mutating operation. It mutates <paramref name="collection"/> rather than constructing a new collection for the result. This is done for two reasons. First is that we can't generalize <see cref="Map{TElement}(IIndexable{TElement}, Func{TElement, TElement})"/> like this while also allowing arbitrary collections to be constructed. Second is performance, as mutating in-place is substantially more efficient. <see cref="Philosoft"/> is not a pure functional programming library, it just takes inspiration in the form of more practical application of many functional principals.
		/// </remarks>
		public static void Map<TElement>(this IIndexable<TElement> collection, Func<TElement, TElement> func) {
			if (collection is null) {
				return;
			}
			collection.Map(func);
		}
	}
}
