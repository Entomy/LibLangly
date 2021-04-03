using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can have its first element peeked at.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPeek<TElement, out TResult> : IRead<TElement, TResult> where TResult : IPeek<TElement, TResult> {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		[return: MaybeNull]
		TResult Peek([MaybeNull] out TElement element);
	}
}

namespace Langly {
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
