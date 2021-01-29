using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements pushed onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPush<TElement, out TResult> where TResult : IPush<TElement, TResult> {
		/// <summary>
		/// Pushes an element onto the top of this object.
		/// </summary>
		/// <param name="element">The element to push.</param>
		/// <returns>The result of pushing the <paramref name="element"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push([AllowNull] TElement element);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push([AllowNull] params TElement[] elements) => elements is not null ? Push(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push(Memory<TElement> elements) => Push((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push(ReadOnlyMemory<TElement> elements) => Push(elements.Span);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push(Span<TElement> elements) => Push((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push(ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				_ = Push(element);
			}
			return (TResult)this;
		}

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		TResult Push<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					_ = Push(element);
				}
			}
			return (TResult)this;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Pushes an element onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to push.</param>
		/// <returns>The result of pushing the <paramref name="element"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(element) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(elements) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, Memory<TElement> elements) where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(elements) : (TResult) collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(elements) : (TResult) collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, Span<TElement> elements) where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(elements) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(elements) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull]
		public static TResult Push<TElement, TResult, TEnumerator>([AllowNull] this IPush<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> where TResult : IPush<TElement, TResult> => collection is not null ? collection.Push(elements) : (TResult)collection;
	}
}
