using System;
using System.Diagnostics.CodeAnalysis;
using Rune = System.Text.Rune;

namespace Langly {
	public static partial class Text {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, Char element) {
			if (collection is null) {
				return;
			}
			collection.Add(element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, [AllowNull] params Char[] elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, Rune element) {
			if (collection is null) {
				return;
			}
			collection.Add(element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, [AllowNull] String elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, [AllowNull] params String[] elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, Memory<Char> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, ReadOnlyMemory<Char> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, Span<Char> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add([AllowNull] this IAddableText collection, ReadOnlySpan<Char> elements) {
			if (collection is null) {
				return;
			}
			collection.Add(elements);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="elements">The elements to add to the collection.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe void Add([AllowNull] this IAddableText collection, Char* elements, Int32 length) {
			if (collection is null) {
				return;
			}
			collection.Add(elements, length);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, Char index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, Rune index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, String index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, Memory<Char> index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, ReadOnlyMemory<Char> index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, Span<Char> index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static void Add<TElement>([AllowNull] this IAddableText<TElement> collection, ReadOnlySpan<Char> index, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, element);
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="length">The length of the <paramref name="index"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		[CLSCompliant(false)]
		public static unsafe void Add<TElement>([AllowNull] this IAddableText<TElement> collection, Char* index, Int32 length, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Add(index, length, element);
		}
	}
}
