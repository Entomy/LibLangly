using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have its first element peeked at.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPeek<TElement, out TResult> {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <param name="element">The peeked element.</param>
		/// <returns>This object, unchanged.</returns>
		[return: NotNull]
		TResult Peek([MaybeNull] out TElement element);
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Peeks at the first element.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The peeked element.</param>
		/// <returns>This object, unchanged.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Peek<TElement, TResult>([AllowNull] this IPeek<TElement, TResult> collection, [MaybeNull] out TElement element) {
			if (collection is null) {
				element = default;
				return (TResult)collection;
			}
			return collection.Peek(out element);
		}
	}
}
