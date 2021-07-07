using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TElement>([AllowNull] TElement[] collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAny(collection.AsSpan(), count, elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TElement>(ArraySegment<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAny(collection.AsSpan(), count, elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TElement>(Memory<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAny(collection.Span, count, elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TElement>(ReadOnlyMemory<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAny(collection.Span, count, elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TElement>(Span<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAny((ReadOnlySpan<TElement>)collection, count, elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TElement>(ReadOnlySpan<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) {
			Boolean[] found = new Boolean[elements.Length];
			for (Int32 c = 0; c < count; c++) {
				for (Int32 e = 0; e < elements.Length; e++) {
					if (Equals(collection[c], elements[e])) return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean ContainsAny<TElement>([AllowNull] TElement* collection, Int32 count, ReadOnlySpan<TElement> elements) where TElement : unmanaged => ContainsAny(new ReadOnlySpan<TElement>(collection, count), count, elements);

		/// <summary>
		/// Determines whether this collection contains any of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if any of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAny<TNode, TElement>([DisallowNull] TNode head, ReadOnlySpan<TElement> elements) where TNode : class, IContains<TElement>, INext<TNode> {
			Boolean[] found = new Boolean[elements.Length];
			TNode? N = head;
			while (N is not null) {
				for (Int32 i = 0; i < elements.Length; i++) {
					if (N.Contains(elements[i])) return true;
				}
				N = N.Next;
			}
			return false;
		}
	}
}
