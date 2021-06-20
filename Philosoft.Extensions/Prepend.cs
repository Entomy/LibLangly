using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend([DisallowNull] this IPrepend<Char> collection, [AllowNull] String elements) => Prepend(collection, elements.AsSpan());

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend([DisallowNull] this IPrependMemory<Char> collection, [AllowNull] String elements) => collection.Prepend(elements.AsMemory());

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, [AllowNull] params TElement[] elements) => Prepend(collection, elements.AsSpan());

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, ArraySegment<TElement> elements) => Prepend(collection, elements.AsSpan());

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, Memory<TElement> elements) => Prepend(collection, elements.Span);

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, ReadOnlyMemory<TElement> elements) => Prepend(collection, elements.Span);

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, Span<TElement> elements) => Prepend(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				collection.Prepend(elements[i]);
			}
		}

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, [DisallowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = length - 1; i >= 0; i--) {
				collection.Prepend(elements[i]);
			}
		}

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Prepend<TElement>([DisallowNull] this IPrependSpan<TElement> collection, [DisallowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Prepend(new Span<TElement>(elements, length));

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement>([DisallowNull] this IPrepend<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Prepend(element);
				}
			}
		}

		/// <summary>
		/// Prepends the elements onto this object, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		public static void Prepend<TElement, TEnumerator>([DisallowNull] this IPrepend<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Prepend(element);
				}
			}
		}
	}
}
