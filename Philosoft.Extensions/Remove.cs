using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove([DisallowNull] this IRemove<Char> collection, [AllowNull] String elements) => Remove(collection, elements.AsSpan());

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] params TElement[] elements) => Remove(collection, elements.AsSpan());

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, Memory<TElement> elements) => Remove(collection, elements.Span);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, ReadOnlyMemory<TElement> elements) => Remove(collection, elements.Span);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, Span<TElement> elements) => Remove(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Removes all instances of the elements from this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to remove.</param>
		public static void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, ReadOnlySpan<TElement> elements) {
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
		public static unsafe void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
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
		public static void Remove<TElement>([DisallowNull] this IRemove<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
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
		public static void Remove<TElement, TEnumerator>([DisallowNull] this IRemove<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : notnull, ICount, ICurrent<TElement>, IMoveNext, IReset {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Remove(element);
				}
			}
		}
	}
}
