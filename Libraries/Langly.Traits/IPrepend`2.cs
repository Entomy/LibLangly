using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPrepend<TElement, out TResult> where TResult : IPrepend<TElement, TResult> {
		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <param name="element">The element to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend([AllowNull] TElement element);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend([AllowNull] params TElement[] elements) => elements is not null ? Prepend(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend(Memory<TElement> elements) => Prepend((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend(ReadOnlyMemory<TElement> elements) {
			TResult? result = (TResult)this;
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				if ((result = result!.Prepend(elements.Span[i])) is null) { return default; }
			}
			return result;
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			TResult? result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					if ((result = result!.Prepend(element)) is null) { return default; }
				}
			}
			return result;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(element) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, Memory<TElement> elements) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IPrepend<TElement, TResult> => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator for the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Prepend<TElement, TResult, TEnumerator>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TResult : IPrepend<TElement, TResult> where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Prepend(elements) : (TResult)collection;
	}
}
