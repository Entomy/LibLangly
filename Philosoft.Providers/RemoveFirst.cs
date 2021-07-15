using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Removes the first instance of the element from this object.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to remove.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RemoveFirst<TElement>([DisallowNull] TElement[] collection, ref Int32 count, [AllowNull] TElement element) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(collection[i], element)) {
					collection.AsSpan(i).CopyTo(collection.AsSpan(--i));
					count--;
					return;
				}
			}
		}
	}
}
