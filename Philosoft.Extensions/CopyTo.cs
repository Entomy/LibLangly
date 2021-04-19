using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		#region CopyTo(Collection, TElement[])
		/// <summary>
		/// Copies all the elements of the current sequence into an array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">This sequence to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence, [DisallowNull] TElement[] array) where TEnumerator : IEnumerator<TElement> {
			if (array is null) {
				throw new ArgumentNullException();
			} else if (sequence is not null) {
				sequence.CopyTo(array);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the array.
		/// </summary>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo([AllowNull] this String collection, [DisallowNull] Char[] array) {
			if (collection is not null) {
				CopyTo(collection.AsSpan(), array);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement>([AllowNull] this TElement[] collection, [DisallowNull] TElement[] array) {
			if (collection is not null) {
				CopyTo(collection.AsSpan(), array);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement>(this Memory<TElement> collection, [DisallowNull] TElement[] array) => CopyTo(collection.Span, array);

		/// <summary>
		/// Copies all the elements of the current collection into the array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement>(this ReadOnlyMemory<TElement> collection, [DisallowNull] TElement[] array) => CopyTo(collection.Span, array);

		/// <summary>
		/// Copies all the elements of the current collection into the array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement>(this Span<TElement> collection, [DisallowNull] TElement[] array) {
			if (array is null) {
				throw new ArgumentNullException();
			}
			CopyTo(collection, array.AsSpan());
		}

		/// <summary>
		/// Copies all the elements of the current collection into the array.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement>(this ReadOnlySpan<TElement> collection, [DisallowNull] TElement[] array) {
			if (array is null) {
				throw new ArgumentNullException();
			}
			CopyTo(collection, array.AsSpan());
		}
		#endregion

		#region CopyTo(Collection, Memory<TElement>)
		/// <summary>
		/// Copies all the elements of the current sequence into a memory region.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">This sequence to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		public static void CopyTo<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence, Memory<TElement> memory) where TEnumerator : IEnumerator<TElement> {
			if (sequence is not null) {
				sequence.CopyTo(memory);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the memory.
		/// </summary>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo([AllowNull] this String collection, Memory<Char> memory) {
			if (collection is not null) {
				CopyTo(collection.AsSpan(), memory.Span);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the memory.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>([AllowNull] TElement[] collection, Memory<TElement> memory) {
			if (collection is not null) {
				CopyTo(collection.AsSpan(), memory.Span);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the memory.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this Memory<TElement> collection, Memory<TElement> memory) => CopyTo(collection, memory.Span);

		/// <summary>
		/// Copies all the elements of the current collection into the memory.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this ReadOnlyMemory<TElement> collection, Memory<TElement> memory) => CopyTo(collection, memory.Span);

		/// <summary>
		/// Copies all the elements of the current collection into the memory.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this Span<TElement> collection, Memory<TElement> memory) => CopyTo(collection, memory.Span);

		/// <summary>
		/// Copies all the elements of the current collection into the memory.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this ReadOnlySpan<TElement> collection, Memory<TElement> memory) => CopyTo(collection, memory.Span);
		#endregion

		#region CopyTo(Collection, Span<TElement>)
		/// <summary>
		/// Copies all the elements of the current sequence into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for this sequence.</typeparam>
		/// <param name="sequence">This sequence to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		public static void CopyTo<TElement, TEnumerator>([AllowNull] this ISequence<TElement, TEnumerator> sequence, Span<TElement> span) where TEnumerator : IEnumerator<TElement> {
			if (sequence is not null) {
				sequence.CopyTo(span);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the span.
		/// </summary>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo([AllowNull] this String collection, Span<Char> span) {
			if (collection is not null) {
				CopyTo(collection.AsSpan(), span);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>([AllowNull] TElement[] collection, Span<TElement> span) {
			if (collection is not null) {
				CopyTo(collection.AsSpan(), span);
			}
		}

		/// <summary>
		/// Copies all the elements of the current collection into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this Memory<TElement> collection, Span<TElement> span) => CopyTo(collection.Span, span);

		/// <summary>
		/// Copies all the elements of the current collection into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this ReadOnlyMemory<TElement> collection, Span<TElement> span) => CopyTo(collection.Span, span);

		/// <summary>
		/// Copies all the elements of the current collection into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this Span<TElement> collection, Span<TElement> span) => CopyTo((ReadOnlySpan<TElement>)collection, span);

		/// <summary>
		/// Copies all the elements of the current collection into the span.
		/// </summary>
		/// <typeparam name="TElement">The type of elements in the sequence.</typeparam>
		/// <param name="collection">This collection to copy.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this collection.</exception>
		public static void CopyTo<TElement>(this ReadOnlySpan<TElement> collection, Span<TElement> span) => collection.CopyTo(span);
		#endregion
	}
}
