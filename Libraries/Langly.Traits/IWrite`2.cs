using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be written to.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IWrite<TElement, out TResult> where TResult : IWrite<TElement, TResult> {
		/// <summary>
		/// Can this be written to?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IWrite{TElement, TResult}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
		/// </remarks>
		public Boolean Writable { get; }

		/// <summary>
		/// Writes a <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public TResult Write([AllowNull] TElement element);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public TResult Write([AllowNull] params TElement[] elements) => Write(elements.AsMemory());

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public TResult Write(Memory<TElement> elements) => Write(elements.Span);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public TResult Write(ReadOnlyMemory<TElement> elements) => Write(elements.Span);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public TResult Write(Span<TElement> elements) => Write((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public TResult Write(ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				Write(element);
			}
			return (TResult)this;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="element"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="element">The element to write.</param>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IWrite<TElement, TResult> => collection is not null ? collection.Write(element) : (TResult)collection;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> collection, [AllowNull] TElement[] elements) where TResult : IWrite<TElement, TResult> => collection is not null ? collection.Write(elements) : (TResult)collection;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> collection, Memory<TElement> elements) where TResult : IWrite<TElement, TResult> => collection is not null ? collection.Write(elements) : (TResult)collection;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IWrite<TElement, TResult> => collection is not null ? collection.Write(elements) : (TResult)collection;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> collection, Span<TElement> elements) where TResult : IWrite<TElement, TResult> => collection is not null ? collection.Write(elements) : (TResult)collection;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IWrite<TElement, TResult> => collection is not null ? collection.Write(elements) : (TResult)collection;
	}
}
