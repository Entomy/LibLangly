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
		public static Boolean Contains(String collection, Int32 count, Char element) {
			if (collection is not null) {
				for (Int32 i = 0; i < count; i++) {
					if (Equals(collection[i], element)) { return true; }
				}
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
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TElement>(TElement[] collection, Int32 count, TElement element) {
			if (collection is not null) {
				for (Int32 i = 0; i < count; i++) {
					if (Equals(collection[i], element)) { return true; }
				}
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
		public static unsafe Boolean Contains<TElement>(TElement* collection, Int32 count, TElement element) where TElement : unmanaged {
			if (collection is not null) {
				for (Int32 i = 0; i < count; i++) {
					if (Equals(collection[i], element)) { return true; }
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TNode, TElement>(TNode head, TElement element) where TNode : class, IContains<TElement>, INext<TNode?> {
			TNode? N = head;
			while (N is not null) {
				if (N.Contains(element)) { return true; }
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
		public static Boolean Contains(String collection, Int32 count, Predicate<Char>? predicate) {
			if (collection is not null) {
				for (Int32 i = 0; i < count; i++) {
					if (predicate?.Invoke(collection[i]) ?? false) { return true; }
				}
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
		public static Boolean Contains<TElement>(TElement[] collection, Int32 count, Predicate<TElement>? predicate) {
			if (collection is not null) {
				for (Int32 i = 0; i < count; i++) {
					if (predicate?.Invoke(collection[i]) ?? collection[i] is null) { return true; }
				}
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
		public static unsafe Boolean Contains<TElement>(TElement* collection, Int32 count, Predicate<TElement>? predicate) where TElement : unmanaged {
			if (collection is not null) {
				for (Int32 i = 0; i < count; i++) {
					if (predicate?.Invoke(collection[i]) ?? false) { return true; }
				}
			}
			return false;
		}

		/// <summary>
		/// Determines whether this collection contains an element matching the specified <paramref name="predicate"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="predicate">A <see cref="Predicate{T}"/> describing the element to attempt to find.</param>
		/// <returns><see langword="true"/> if an element described by the <paramref name="predicate"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Boolean Contains<TNode, TElement>(TNode head, Predicate<TElement>? predicate) where TNode : class, IContains<TElement>, INext<TNode?> {
			TNode? N = head;
			while (N is not null) {
				if (N.Contains(predicate)) { return true; }
				N = N.Next;
			}
			return false;
		}
	}
}
