using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
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
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<Char> ShiftLeft([AllowNull] this String collection) {
			if (collection is null || collection.Length == 0) {
				return collection.AsMemory();
			}
			return ShiftLeftKernel<Char>(collection, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftLeft<TElement>([AllowNull] this TElement[] collection) {
			if (collection is null || collection.Length == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftLeft<TElement>(this Memory<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection.Span, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftLeft<TElement>(this ReadOnlyMemory<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection.Span, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="Span{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Span<TElement> ShiftLeft<TElement>(this Span<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection, 1);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by one position.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <returns>An <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlySpan<TElement> ShiftLeft<TElement>(this ReadOnlySpan<TElement> collection) {
			if (collection.Length == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection, 1);
		}
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
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<Char> ShiftLeft([AllowNull] this String collection, nint amount) {
			if (collection is null || collection.Length == 0 || amount == 0) {
				return collection.AsMemory();
			}
			return ShiftLeftKernel<Char>(collection, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftLeft<TElement>([AllowNull] this TElement[] collection, nint amount) {
			if (collection is null || collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Memory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Memory<TElement> ShiftLeft<TElement>(this Memory<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection.Span, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlyMemory<TElement> ShiftLeft<TElement>(this ReadOnlyMemory<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection.Span, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="Span{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static Span<TElement> ShiftLeft<TElement>(this Span<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection, amount);
		}

		/// <summary>
		/// Shifts the <paramref name="collection"/> left by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		/// <returns>An <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> after the elements are shifted.</returns>
		public static ReadOnlySpan<TElement> ShiftLeft<TElement>(this ReadOnlySpan<TElement> collection, nint amount) {
			if (collection.Length == 0 || amount == 0) {
				return collection;
			}
			return ShiftLeftKernel<TElement>(collection, amount);
		}
		#endregion

		private static TElement[] ShiftLeftKernel<TElement>(ReadOnlySpan<TElement> collection, nint amount) {
			TElement[] array = new TElement[collection.Length];
			collection.Slice(amount).CopyTo(array);
			return array;
		}
	}
}
