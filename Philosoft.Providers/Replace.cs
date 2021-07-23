﻿using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="collection">The elements of this collection.</param>
		/// <param name="count">The amount of elements in the collection; the amount currently in use.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TElement>(TElement[] collection, Int32 count, TElement search, TElement replace) {
			for (Int32 i = 0; i < count; i++) {
				if (Equals(collection[i], search)) {
					collection[i] = replace;
				}
			}
		}

		/// <summary>
		/// Replaces all instances of <paramref name="search"/> with <paramref name="replace"/>.
		/// </summary>
		/// <param name="head">The head node of this collection.</param>
		/// <param name="search">The element to replace.</param>
		/// <param name="replace">The element to use instead.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Replace<TNode, TElement>(TNode head, TElement search, TElement replace) where TNode : class, INext<TNode?>, IReplace<TElement> {
			TNode? N = head;
			while (N is not null) {
				N.Replace(search, replace);
				N = N.Next;
			}
		}
	}
}
