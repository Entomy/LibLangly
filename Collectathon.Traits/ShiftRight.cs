﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftRight<TElement>([AllowNull] TElement[] collection, nint count, nint amount) => ShiftRight(collection.AsSpan(), count, amount);

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftRight<TElement>(Memory<TElement> collection, nint count, nint amount) => ShiftRight(collection.Span, count, amount);

		/// <summary>
		/// Shifts the <paramref name="collection"/> right by <paramref name="amount"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="amount">The amount of positions to shift.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ShiftRight<TElement>(Span<TElement> collection, nint count, nint amount) {
			if (amount != 0 && count != 0) {
				collection.Slice(0, collection.Length - (Int32)amount).CopyTo(collection.Slice((Int32)amount));
				collection.Slice(0, (Int32)amount).Clear();
			}
		}
	}
}
