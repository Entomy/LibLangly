using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Removes all instances of the element from this object.
		/// </summary>
		/// <param name="collection">The elements in this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to remove.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Remove<TElement>(Span<TElement> collection, ref nint count, [AllowNull] TElement element) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(collection[i], element)) {
					collection[i] = collection[i + 1];
					i--;
					count--;
				}
			}
		}
	}
}
