using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast([DisallowNull] this IRemove<Char> collection, [AllowNull] String elements) => RemoveLast(collection, elements.AsSpan());

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] params TElement[] elements) => RemoveLast(collection, elements.AsSpan());

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, Memory<TElement> elements) => RemoveLast(collection, elements.Span);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, ReadOnlyMemory<TElement> elements) => RemoveLast(collection, elements.Span);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, Span<TElement> elements) => RemoveLast(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.RemoveLast(elements[i]);
			}
		}

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.RemoveLast(elements[i]);
			}
		}

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.RemoveLast(element);
				}
			}
		}

		/// <summary>
		/// Removes the last instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveLast<TElement, TEnumerator>([DisallowNull] this IRemove<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.RemoveLast(element);
				}
			}
		}
	}
}
