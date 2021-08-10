using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend(this IPostpend<Char> collection, String elements) => Postpend(collection, elements.AsSpan());

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend(this IPostpendMemory<Char> collection, String elements) => collection.Postpend(elements.AsMemory());

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, params TElement[] elements) => Postpend(collection, elements.AsSpan());

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, ArraySegment<TElement> elements) => Postpend(collection, elements.AsSpan());

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, Memory<TElement> elements) => Postpend(collection, elements.Span);

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, ReadOnlyMemory<TElement> elements) => Postpend(collection, elements.Span);

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, Span<TElement> elements) => Postpend(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Postpend(elements[i]);
			}
		}

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Postpend<TElement>(this IPostpend<TElement> collection, TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Postpend(elements[i]);
			}
		}

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Postpend<TElement>(this IPostpendSpan<TElement> collection, TElement* elements, Int32 length) where TElement : unmanaged => collection.Postpend(new Span<TElement>(elements, length));

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement>(this IPostpend<TElement> collection, Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Postpend(element);
				}
			}
		}

		/// <summary>
		/// Postpends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		public static void Postpend<TElement, TEnumerator>(this IPostpend<TElement> collection, IGetEnumerator<TElement, TEnumerator> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Postpend(element);
				}
			}
		}
	}
}
