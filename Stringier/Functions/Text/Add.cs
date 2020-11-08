using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Philosoft;

namespace Stringier {
	public static partial class Text {
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
