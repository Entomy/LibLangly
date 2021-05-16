using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add([DisallowNull] this IAdd<Char> collection, [AllowNull] String elements) => collection.Add(elements.AsSpan());

		/// <summary>
		/// Adds the elements to this collection, as a batch.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add([DisallowNull] this IAddMemory<Char> collection, [AllowNull] String elements) => collection.Add(elements.AsMemory());

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([DisallowNull] this IAdd<TElement> collection, [AllowNull] params TElement[] elements) => Add(collection, elements.AsSpan());

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([DisallowNull] this IAdd<TElement> collection, Memory<TElement> elements) => Add(collection, elements.Span);

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([DisallowNull] this IAdd<TElement> collection, ReadOnlyMemory<TElement> elements) => Add(collection, elements.Span);

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([DisallowNull] this IAdd<TElement> collection, Span<TElement> elements) => Add(collection, (ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([DisallowNull] this IAdd<TElement> collection, ReadOnlySpan<TElement> elements) {
			for (Int32 i = 0; i < elements.Length; i++) {
				collection.Add(elements[i]);
			}
		}

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe void Add<TElement>([DisallowNull] this IAdd<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged {
			for (Int32 i = 0; i < length; i++) {
				collection.Add(elements[i]);
			}
		}

		/// <summary>
		/// Adds the elements to this collection, as a batch.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe void Add<TElement>([DisallowNull] this IAddSpan<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Add(new Span<TElement>(elements, length));

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement>([DisallowNull] this IAdd<TElement> collection, [AllowNull] Collections.Generic.IEnumerable<TElement> elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Add(element);
				}
			}
		}

		/// <summary>
		/// Adds the elements to this collection, one by one.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static void Add<TElement, TEnumerator>([DisallowNull] this IAdd<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					collection.Add(element);
				}
			}
		}
	}
}
