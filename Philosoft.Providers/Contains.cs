using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class Collection {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>([AllowNull] TElement[] collection, Int32 count, [AllowNull] TElement element) => Contains(collection.AsSpan(), count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(Memory<TElement> collection, Int32 count, [AllowNull] TElement element) => Contains(collection.Span, count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ReadOnlyMemory<TElement> collection, Int32 count, [AllowNull] TElement element) => Contains(collection.Span, count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(Span<TElement> collection, Int32 count, [AllowNull] TElement element) => Contains((ReadOnlySpan<TElement>)collection, count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ReadOnlySpan<TElement> collection, Int32 count, [AllowNull] TElement element) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(collection[i], element)) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean Contains<TElement>([AllowNull] TElement* collection, Int32 count, [AllowNull] TElement element) where TElement : unmanaged => Contains(new ReadOnlySpan<TElement>(collection, count), count, element);


		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TNode, TElement>([DisallowNull] TNode head, [AllowNull] TElement element) where TNode : class, IContains<TElement>, INext<TNode> {
			TNode? N = head;
			while (N is not null) {
				if (N.Contains(element)) return true;
				N = N.Next;
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>([AllowNull] TElement[] collection, Int32 count, [AllowNull] Predicate<TElement> predicate) => Contains(collection.AsSpan(), count, predicate);

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ArraySegment<TElement> collection, Int32 count, [AllowNull] Predicate<TElement> predicate) => Contains(collection.AsSpan(), count, predicate);

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(Memory<TElement> collection, Int32 count, [AllowNull] Predicate<TElement> predicate) => Contains(collection.Span, count, predicate);

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ReadOnlyMemory<TElement> collection, Int32 count, [AllowNull] Predicate<TElement> predicate) => Contains(collection.Span, count, predicate);

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(Span<TElement> collection, Int32 count, [AllowNull] Predicate<TElement> predicate) => Contains((ReadOnlySpan<TElement>)collection, count, predicate);

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ReadOnlySpan<TElement> collection, Int32 count, [AllowNull] Predicate<TElement> predicate) {
			for (Int32 i = 0; i < count; i++) {
				// If both are null
				if (ReferenceEquals(collection[i], predicate)) return true;
				// Otherwise, actually check
				if (predicate!(collection[i])) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean Contains<TElement>([AllowNull] TElement* collection, Int32 count, [AllowNull] Predicate<TElement> predicate) where TElement : unmanaged => Contains(new ReadOnlySpan<TElement>(collection, count), count, predicate);

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TNode, TElement>([DisallowNull] TNode head, [AllowNull] Predicate<TElement> predicate) where TNode : class, IContains<TElement>, INext<TNode> {
			TNode? N = head;
			while (N is not null) {
				if (N.Contains(predicate)) return true;
				N = N.Next;
			}
			return false;
		}
	}
}
