using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class CollectionProviders {
		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftLeft<TElement>([AllowNull] TElement?[] collection, Int32 count, Int32 amount) => ShiftLeft(collection.AsSpan(), count, amount);

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftLeft<TElement>(Memory<TElement?> collection, Int32 count, Int32 amount) => ShiftLeft(collection.Span, count, amount);

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftLeft<TElement>(Span<TElement?> collection, Int32 count, Int32 amount) {
			if (amount != 0 && count != 0) {
				collection.Slice(amount).CopyTo(collection);
				collection.Slice(collection.Length - amount).Clear();
			}
		}
	}
}
