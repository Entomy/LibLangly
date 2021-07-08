using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Traits.Concepts {
	public static partial class CollectionProviders {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TNode, TElement>([DisallowNull] TNode head, [AllowNull] TElement search, [AllowNull] TElement replace) where TNode : class, INext<TNode>, IReplace<TElement> {
			TNode? N = head;
			while (N is not null) {
				N.Replace(search, replace);
				N = N.Next;
			}
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TElement>([AllowNull] TElement?[] collection, Int32 count, [AllowNull] TElement search, [AllowNull] TElement replace) => Replace(collection.AsSpan(), count, search, replace);

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TElement>(Memory<TElement?> collection, Int32 count, [AllowNull] TElement search, [AllowNull] TElement replace) => Replace(collection.Span, count, search, replace);

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TElement>(Span<TElement?> collection, Int32 count, [AllowNull] TElement search, [AllowNull] TElement replace) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(collection[i], search)) {
					collection[i] = replace;
				}
			}
		}
	}
}
