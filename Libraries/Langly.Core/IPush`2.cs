using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements pushed onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPush<TElement, out TResult> {
		/// <summary>
		/// Pushes an element onto the top of this object.
		/// </summary>
		/// <param name="element">The element to push.</param>
		/// <returns>The result of pushing the <paramref name="element"/> onto this object.</returns>
		[return: NotNull]
		TResult Push([AllowNull] TElement element);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: NotNull]
		TResult Push([AllowNull] params TElement[] elements) => elements is not null ? Push(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: NotNull]
		TResult Push(Memory<TElement> elements) => Push((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: NotNull]
		TResult Push(ReadOnlyMemory<TElement> elements) => Push(elements.Span);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: NotNull]
		TResult Push(Span<TElement> elements) => Push((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: NotNull]
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
		[return: NotNull]
		TResult Push<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is not null) {
				foreach (TElement element in elements) {
					_ = Push(element);
				}
			}
			return (TResult)this;
		}
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Pushes an element onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to push.</param>
		/// <returns>The result of pushing the <paramref name="element"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, [AllowNull] TElement element) => collection is not null ? collection.Push(element) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, [AllowNull] params TElement[] elements) => collection is not null ? collection.Push(elements) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, Memory<TElement> elements) => collection is not null ? collection.Push(elements) : (TResult) collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) => collection is not null ? collection.Push(elements) : (TResult) collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, Span<TElement> elements) => collection is not null ? collection.Push(elements) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult>([AllowNull] this IPush<TElement, TResult> collection, ReadOnlySpan<TElement> elements) => collection is not null ? collection.Push(elements) : (TResult)collection;

		/// <summary>
		/// Pushes the elements onto the top of this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to push.</param>
		/// <returns>The result of pushing the <paramref name="elements"/> onto this object.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Push<TElement, TResult, TEnumerator>([AllowNull] this IPush<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Push(elements) : (TResult)collection;
	}
}
