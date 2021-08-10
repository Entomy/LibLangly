using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove(this IRemove<Char> collection, String? elements) => Remove(collection, elements.AsSpan());

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>(this IRemove<TElement> collection, params TElement[]? elements) => Remove(collection, elements.AsSpan());

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>(this IRemove<TElement> collection, Memory<TElement> elements) => Remove(collection, elements.Span);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>(this IRemove<TElement> collection, ReadOnlyMemory<TElement> elements) => Remove(collection, elements.Span);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>(this IRemove<TElement> collection, Span<TElement> elements) => Remove(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>(this IRemove<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Remove(elements[i]);
			}
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Remove<TElement>(this IRemove<TElement> collection, TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Remove(elements[i]);
			}
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>(this IRemove<TElement> collection, Collections.Generic.IEnumerable<TElement>? elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Remove(element);
				}
			}
		}

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement, TEnumerator>(this IRemove<TElement> collection, IGetEnumerator<TElement, TEnumerator>? elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Remove(element);
				}
			}
		}
	}
}
