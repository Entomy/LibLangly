using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Numbersome;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TElement>([AllowNull] TElement[] collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAll(collection.AsSpan(), count, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TElement>(ArraySegment<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAll(collection.AsSpan(), count, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TElement>(Memory<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAll(collection.Span, count, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TElement>(ReadOnlyMemory<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAll(collection.Span, count, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TElement>(Span<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) => ContainsAll((ReadOnlySpan<TElement>)collection, count, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TElement>(ReadOnlySpan<TElement> collection, Int32 count, ReadOnlySpan<TElement> elements) {
			Boolean[] found = new Boolean[elements.Length];
			for (Int32 c = 0; c < count; c++) {
				for (Int32 e = 0; e < elements.Length; e++) {
					if (Equals(collection[c], elements[e])) found[e] = true;
				}
			}
			return found.ContainsOnlyTrue();
		}

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean ContainsAll<TElement>([AllowNull] TElement* collection, Int32 count, ReadOnlySpan<TElement> elements) where TElement : unmanaged => ContainsAll(new ReadOnlySpan<TElement>(collection, count), count, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean ContainsAll<TNode, TElement>([DisallowNull] TNode head, ReadOnlySpan<TElement> elements) where TNode : class, IContains<TElement>, INext<TNode> {
			Boolean[] found = new Boolean[elements.Length];
			TNode? N = head;
			while (N is not null) {
				for (Int32 i = 0; i < elements.Length; i++) {
					if (N.Contains(elements[i])) found[i] = true;
				}
				N = N.Next;
			}
			return found.ContainsOnlyTrue();
		}
	}
}
