using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have its first element peeked at.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TSelf">The implementing type; itself.</typeparam>
	public interface IPeek<TElement, out TSelf> : IRead<TElement, TSelf> where TSelf : IPeek<TElement, TSelf> {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		[return: MaybeNull]
		TSelf Peek([MaybeNull] out TElement element);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TSelf">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The peeked element.</param>
		/// <returns>This object, unchanged.</returns>
		[return: MaybeNull]
		public static TSelf Peek<TElement, TSelf>([AllowNull] this IPeek<TElement, TSelf> collection, [MaybeNull] out TElement element) where TSelf : IPeek<TElement, TSelf> {
			if (collection is null) {
				element = default;
				return (TSelf)collection;
			}
			return collection.Peek(out element);
		}
	}
}
