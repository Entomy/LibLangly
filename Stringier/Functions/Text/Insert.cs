using System;
using System.Diagnostics.CodeAnalysis;
using Rune = System.Text.Rune;

namespace Langly {
	public static partial class Text {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, Char element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, Rune element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, [AllowNull] String element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, Memory<Char> element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, ReadOnlyMemory<Char> element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, Span<Char> element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		[CLSCompliant(false)]
		public static void Insert([AllowNull] this IInsertableText collection, nint index, ReadOnlySpan<Char> element) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element);
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		/// <param name="length">The length of the <paramref name="element"/>.</param>
		[CLSCompliant(false)]
		public static unsafe void Insert([AllowNull] this IInsertableText collection, nint index, [AllowNull] Char* element, Int32 length) {
			if (collection is null) {
				return;
			}
			collection.Insert(index, element, length);
		}
	}
}
