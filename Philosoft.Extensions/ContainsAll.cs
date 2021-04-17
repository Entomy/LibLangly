using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>([AllowNull] this IContains<TElement> collection, [AllowNull] params TElement[] elements) => collection?.ContainsAll(elements) ?? false;

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll([AllowNull] this String collection, [AllowNull] params Char[] elements) => collection is not null ? ContainsAll(collection.AsSpan(), elements) : false;

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) => collection is not null ? ContainsAll(collection.AsSpan(), elements) : false;

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>(this Memory<TElement> collection, [AllowNull] params TElement[] elements) => ContainsAll(collection.Span, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] params TElement[] elements) => ContainsAll(collection.Span, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>(this Span<TElement> collection, [AllowNull] params TElement[] elements) => ContainsAll((ReadOnlySpan<TElement>)collection, elements);

		/// <summary>
		/// Determines whether this collection contains all of the specified <paramref name="elements"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in this collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to attempt to find.</param>
		/// <returns><see langword="true"/> if all of the <paramref name="elements"/> are contained in this collection; otherwise <see langword="false"/>.</returns>
		public static Boolean ContainsAll<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] params TElement[] elements) {
			if (elements is not null) {
				foreach (TElement element in elements) {
					if (!collection.Contains(element)) {
						return false;
					}
				}
			}
			return true;
		}
	}
}
