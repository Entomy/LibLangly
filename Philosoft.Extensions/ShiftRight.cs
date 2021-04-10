using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		#region ShiftRight(Collection)
		/// <summary>
		/// Shifts the <paramref name="collection"/> right one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult ShiftRight<TResult>([AllowNull] this IShift<TResult> collection) where TResult : IShift<TResult> => collection is not null ? collection.ShiftRight() : default;

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Array"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] ShiftRight<TElement>([AllowNull] this TElement[] collection) => collection.ShiftRight(1);

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftRight<TElement>(this Memory<TElement> collection) => collection.ShiftRight(1);

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftRight<TElement>(this ReadOnlyMemory<TElement> collection) => collection.ShiftRight(1);
		#endregion

		#region ShiftRight(Collection, nint)
		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult ShiftRight<TResult>([AllowNull] this IShift<TResult> collection, nint amount) where TResult : IShift<TResult> => collection is not null ? collection.ShiftRight(amount) : default;

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Array"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TElement[] ShiftRight<TElement>([AllowNull] this TElement[] collection, nint amount) {
			if (collection is null || amount == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			nint i = 0;
			for (; i < amount; i++) {
				Array[i] = default;
			}
			for (nint j = 0; i < collection.Length; j++) {
				Array[i++] = collection[j];
			}
			return Array;
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftRight<TElement>(this Memory<TElement> collection, nint amount) {
			if (amount == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			nint i = 0;
			for (; i < amount; i++) {
				Array[i] = default;
			}
			for (nint j = 0; i < collection.Length; j++) {
				Array[i++] = collection.Span[(Int32)j];
			}
			return Array;
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftRight<TElement>(this ReadOnlyMemory<TElement> collection, nint amount) {
			if (amount == 0) {
				return collection;
			}
			TElement[] Array = new TElement[collection.Length];
			nint i = 0;
			for (; i < amount; i++) {
				Array[i] = default;
			}
			for (nint j = 0; i < collection.Length; j++) {
				Array[i++] = collection.Span[(Int32)j];
			}
			return Array;
		}
		#endregion
	}
}
