using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Creates an array from a <see cref="ISequence{TElement, TEnumerator}"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <returns>An array that contains the elements from the input sequence.</returns>
		[return: NotNull]
		public static TElement[] ToArray<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection) where TEnumerator : IEnumerator<TElement> {
			TElement[] array = new TElement[collection.Count];
			collection.CopyTo(array);
			return array;
		}
	}
}
