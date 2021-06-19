using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits {
	public static partial class Collection {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="elements">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>([AllowNull] TElement[] elements, nint count, [AllowNull] TElement element) => Contains(elements.AsSpan(), count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="elements">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(Memory<TElement> elements, nint count, [AllowNull] TElement element) => Contains(elements.Span, count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="elements">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ReadOnlyMemory<TElement> elements, nint count, [AllowNull] TElement element) => Contains(elements.Span, count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="elements">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(Span<TElement> elements, nint count, [AllowNull] TElement element) => Contains((ReadOnlySpan<TElement>)elements, count, element);

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="elements">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(ReadOnlySpan<TElement> elements, nint count, [AllowNull] TElement element) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(elements[i], element)) return true;
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="elements">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[CLSCompliant(false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static unsafe Boolean Contains<TElement>([AllowNull] TElement* elements, nint count, [AllowNull] TElement element) where TElement : unmanaged => Contains(new ReadOnlySpan<TElement>(elements, (Int32)count), count, element);

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
	}
}
