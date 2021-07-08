using System.Diagnostics.CodeAnalysis;
using System.Traits;
using System.Traits.Concepts;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push([DisallowNull] this IPush<Char> collection, [AllowNull] String elements) => collection.Push(elements.AsSpan());

		/// <summary>
		/// Pushs the elements onto this collection, as a batch.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push([DisallowNull] this IPushMemory<Char> collection, [AllowNull] String elements) => collection.Push(elements.AsMemory());

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, [AllowNull] params TElement[] elements) => Push(collection, elements.AsSpan());

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, ArraySegment<TElement> elements) => Push(collection, elements.AsSpan());

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, Memory<TElement> elements) => Push(collection, elements.Span);

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, ReadOnlyMemory<TElement> elements) => Push(collection, elements.Span);

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, Span<TElement> elements) => Push(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Push(elements[i]);
			}
		}

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Push<TElement>([DisallowNull] this IPush<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Push(elements[i]);
			}
		}

		/// <summary>
		/// Pushs the elements onto this collection, as a batch.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Push<TElement>([DisallowNull] this IPushSpan<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Push(new Span<TElement>(elements, length));

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement>([DisallowNull] this IPush<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Push(element);
				}
			}
		}

		/// <summary>
		/// Pushs the elements onto this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		public static void Push<TElement, TEnumerator>([DisallowNull] this IPush<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Push(element);
				}
			}
		}
	}
}
