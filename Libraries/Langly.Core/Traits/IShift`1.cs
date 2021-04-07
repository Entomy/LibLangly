using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can be shifted in position.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IShift<out TResult> where TResult : IShift<TResult> {
		/// <summary>
		/// Shifts the collection left one position.
		/// </summary>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftLeft() => ShiftLeft(1);

		/// <summary>
		/// Shifts the collection left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftLeft(nint amount);

		/// <summary>
		/// Shifts the collection right one position.
		/// </summary>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftRight() => ShiftRight(1);

		/// <summary>
		/// Shifts the collection right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>A <typeparamref name="TResult"/> after the elements are shifted.</returns>
		[return: NotNull]
		TResult ShiftRight(nint amount);
	}
}

namespace Langly {
	public static partial class TraitExtensions {
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
