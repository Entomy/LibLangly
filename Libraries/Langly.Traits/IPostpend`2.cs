using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPostpend<TElement, out TResult> {
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <param name="element">The element to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend([AllowNull] TElement element);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend([AllowNull] params TElement[] elements) {
			if (elements is null) {
				return (TResult)this;
			}
			return Postpend(elements.AsMemory());
		}

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(Memory<TElement> elements) => Postpend((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements.Span);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(Span<TElement> elements) => Postpend((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(ReadOnlySpan<TElement> elements) {
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				_ = Postpend(elements[i]);
			}
			return (TResult)this;
		}
	}
	
	public static partial class TraitExtensions {
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] TElement element) => collection is not null ? collection.Postpend(element) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] params TElement[] elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, Memory<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, Span<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, ReadOnlySpan<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;
	}
}
