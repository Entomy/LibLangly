using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftRight<TElement>(TElement[] collection, Int32 count, Int32 amount) {
			if (amount != 0 && count != 0) {
				collection.AsSpan(0, collection.Length - amount).CopyTo(collection.AsSpan(amount));
				collection.AsSpan(0, amount).Clear();
			}
		}
	}
}
