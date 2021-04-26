using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The peeked element.</param>
		/// <returns>This object, unchanged.</returns>
		[return: MaybeNull]
		public static TResult Peek<TElement, TResult>([AllowNull] this IPeek<TElement, TResult> collection, [MaybeNull] out TElement element) where TResult : IPeek<TElement, TResult> {
			if (collection is null) {
				element = default;
				return (TResult)collection;
			}
			return collection.Peek(out element);
		}
	}
}
