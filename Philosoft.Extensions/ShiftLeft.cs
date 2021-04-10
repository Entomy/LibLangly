using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		#region ShiftLeft(Collection)
		/// <summary>
		/// Shifts the <paramref name="collection"/> left one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult ShiftLeft<TResult>([AllowNull] this IShift<TResult> collection) where TResult : IShift<TResult> => collection is not null ? collection.ShiftLeft() : default;

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Array"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] ShiftLeft<TElement>([AllowNull] this TElement[] collection) => collection.ShiftLeft(1);

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftLeft<TElement>(this Memory<TElement> collection) => collection.ShiftLeft(1);

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftLeft<TElement>(this ReadOnlyMemory<TElement> collection) => collection.ShiftLeft(1);
		#endregion

		#region ShiftLeft(Collection, nint)
		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult ShiftLeft<TResult>([AllowNull] this IShift<TResult> collection, nint amount) where TResult : IShift<TResult> => collection is not null ? collection.ShiftLeft(amount) : default;

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Array"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] ShiftLeft<TElement>([AllowNull] this TElement[] collection, nint amount) {
			if (collection is null || amount == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			nint i = 0;
			for (nint j = amount; i < collection.Length - amount; j++) {
				Array[i++] = collection[j];
			}
			for (; i < collection.Length; i++) {
				Array[i] = default;
			}
			return Array;
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftLeft<TElement>(this Memory<TElement> collection, nint amount) {
			if (amount == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			nint i = 0;
			for (nint j = amount; i < collection.Length - amount; j++) {
				Array[i++] = collection.Span[(Int32)j];
			}
			for (; i < collection.Length; i++) {
				Array[i] = default;
			}
			return Array;
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftLeft<TElement>(this ReadOnlyMemory<TElement> collection, nint amount) {
			if (amount == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			nint i = 0;
			for (nint j = amount; i < collection.Length - amount; j++) {
				Array[i++] = collection.Span[(Int32)j];
			}
			for (; i < collection.Length; i++) {
				Array[i] = default;
			}
			return Array;
		}
		#endregion
	}
}
