using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Copies all the elements of the current sequence into an array.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		public static void CopyTo<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, [DisallowNull] TElement[] array) where TEnumerator : IEnumerator<TElement> => CopyTo(collection, array.AsSpan());

		/// <summary>
		/// Copies all the elements of the current sequence into a memory region.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		public static void CopyTo<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, Memory<TElement> memory) where TEnumerator : IEnumerator<TElement> => CopyTo(collection, memory.Span);

		/// <summary>
		/// Copyes all the elements of the current sequence into the span.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		public static void CopyTo<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, Span<TElement> span) where TEnumerator : IEnumerator<TElement> {
			if (collection.Count > span.Length) {
				throw new ArgumentException();
			}
			Int32 i = 0;
			foreach (TElement item in collection) {
				span[i++] = item;
			}
		}
	}
}
