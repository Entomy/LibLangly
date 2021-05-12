using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Determines whether this collection contains the specified <paramref name="element"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the collection.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to attempt to find.</param>
		/// <returns><see langword="true"/> if <paramref name="element"/> is contained in this collection; otherwise, <see langword="false"/>.</returns>
		public static Boolean Contains<TElement, TEnumerator>([DisallowNull] this ISequence<TElement, TEnumerator> collection, [AllowNull] TElement element) where TEnumerator : IEnumerator<TElement> {
			foreach (TElement item in collection) {
				if (Equals(element, item)) {
					return true;
				}
			}
			return false;
		}
	}
}
