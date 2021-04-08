using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class Batch {
		/// <summary>
		/// Creates a new memory region over each of the inner target arrays.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">The collection to convert.</param>
		/// <returns>A jagged array with each of the inner arrays converted to a memory representation.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static ReadOnlyMemory<TElement>[] AsReadOnlyMemory<TElement>([AllowNull] TElement[][] collection) {
			if (collection is null) {
				return null;
			}
			ReadOnlyMemory<TElement>[] result = new ReadOnlyMemory<TElement>[collection.Length];
			if (collection is not null) {
				for (nint i = 0; i < collection.Length; i++) {
					result[i] = collection[i].AsMemory();
				}
			}
			return result;
		}
	}
}
