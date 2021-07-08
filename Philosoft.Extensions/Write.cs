using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write([DisallowNull] this IWrite<Char> collection, [AllowNull] String elements) => Write(collection, elements.AsSpan());

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, [AllowNull] params TElement[] elements) => Write(collection, elements.AsSpan());

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, ArraySegment<TElement> elements) => Write(collection, elements.AsSpan());

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, Memory<TElement> elements) => Write(collection, elements.Span);

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, ReadOnlyMemory<TElement> elements) => Write(collection, elements.Span);

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, Span<TElement> elements) => Write(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Write(elements[i]);
			}
		}

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Write<TElement>([DisallowNull] this IWrite<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Write(elements[i]);
			}
		}

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement>([DisallowNull] this IWrite<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Write(element);
				}
			}
		}

		/// <summary>
		/// Writes the <paramref name="elements"/>, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The values to write.</param>
		public static void Write<TElement, TEnumerator>([DisallowNull] this IWrite<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Write(element);
				}
			}
		}
	}
}
