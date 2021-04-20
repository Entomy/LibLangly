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
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<Char> ShiftRight([AllowNull] this String collection) {
			if (collection is null || collection.Length == 0) {
				return collection.AsMemory();
			}
			return ShiftRightKernel<Char>(collection.AsSpan(), 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftRight<TElement>([AllowNull] this TElement[] collection) {
			if (collection is null || collection.Length == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection.AsSpan(), 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftRight<TElement>(this Memory<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection.Span, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftRight<TElement>(this ReadOnlyMemory<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection.Span, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Span{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Span<TElement> ShiftRight<TElement>(this Span<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlySpan<TElement> ShiftRight<TElement>(this ReadOnlySpan<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection, 1);
		}
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
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<Char> ShiftRight([AllowNull] this String collection, nint amount) {
			if (collection is null || collection.Length == 0 || amount == 0) {
				return collection.AsMemory();
			}
			return ShiftRightKernel<Char>(collection, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftRight<TElement>([AllowNull] this TElement[] collection, nint amount) {
			if (collection is null || collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftRight<TElement>(this Memory<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection.Span, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftRight<TElement>(this ReadOnlyMemory<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection.Span, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Span{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Span<TElement> ShiftRight<TElement>(this Span<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlySpan<TElement> ShiftRight<TElement>(this ReadOnlySpan<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftRightKernel<TElement>(collection, amount);
		}
		#endregion

		[return: NotNull]
		private static TElement[] ShiftRightKernel<TElement>(ReadOnlySpan<TElement> collection, nint amount) {
			TElement[] array = new TElement[collection.Length];
			collection.Slice(0, collection.Length - amount).CopyTo(array.Slice(amount));
			return array;
		}
	}
}
