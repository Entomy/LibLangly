using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be read from.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IRead<TElement, out TResult> where TResult : IRead<TElement, TResult> {
		/// <summary>
		/// Can this be read from?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IRead{TElement, TError}"/> can be read from, but that doesn't mean it can always be read from. Rather, this being <see langword="true"/> indicates the type can currently be read from.
		/// </remarks>
		public Boolean Readable { get; }

		/// <summary>
		/// Reads a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		[return: MaybeNull]
		public TResult Read([MaybeNull] out TElement element);
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Reads a <typeparamref name="TElement"/> from the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> collection, [MaybeNull] out TElement element) where TResult : IRead<TElement, TResult> {
			if (collection is null) {
				element = default;
				return (TResult)collection;
			}
			return collection.Read(out element);
		}
	}
}
