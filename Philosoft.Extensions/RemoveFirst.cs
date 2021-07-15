using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst([DisallowNull] this IRemove<Char> collection, [AllowNull] String elements) => RemoveFirst(collection, elements.AsSpan());

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] params TElement[] elements) => RemoveFirst(collection, elements.AsSpan());

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, Memory<TElement> elements) => RemoveFirst(collection, elements.Span);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, ReadOnlyMemory<TElement> elements) => RemoveFirst(collection, elements.Span);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, Span<TElement> elements) => RemoveFirst(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.RemoveFirst(elements[i]);
			}
		}

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.RemoveFirst(elements[i]);
			}
		}

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.RemoveFirst(element);
				}
			}
		}

		/// <summary>
		/// Removes the first instance of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void RemoveFirst<TElement, TEnumerator>([DisallowNull] this IRemove<TElement> collection, [AllowNull] IGetEnumerator<TElement, TEnumerator> elements) where TEnumerator : notnull, ICurrent<TElement>, IMoveNext {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.RemoveFirst(element);
				}
			}
		}
	}
}
