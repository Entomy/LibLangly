using System.Runtime.CompilerServices;

namespace System.Traits.Providers {
	public static partial class Collection {
		/// <summary>
		/// Resize the collection to the specified <paramref name="capacity"/>.
		/// </summary>
		/// <param name="collection">The collection to resize.</param>
		/// <param name="capacity">The new capacity of the collection.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TElement[] Resize<TElement>(TElement[] collection, Int32 capacity) {
			TElement[] newBuffer = new TElement[capacity];
			collection.AsSpan(0, capacity > collection.Length ? collection.Length : capacity).CopyTo(newBuffer);
			return newBuffer;
		}
	}
}
