using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements added to it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IAdd<TElement, out TResult> where TResult : IAdd<TElement, TResult> {
		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add([AllowNull] TElement element);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add([AllowNull] params TElement[] elements) => elements is not null ? Add(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add(Memory<TElement> elements) => Add((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add(ReadOnlyMemory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add(Span<TElement> elements) => Add((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add(ReadOnlySpan<TElement> elements) {
			TResult result = (TResult)this;
			foreach (TElement element in elements) {
				result = result.Add(element);
				if (result is null) {
					goto Result;
				}
			}
		Result:
			return result;
		}

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		TResult Add<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			TResult result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					result = result.Add(element);
					if (result is null) {
						goto Result;
					}
				}
			}
		Result:
			return result;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] TElement element) where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(element) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] params TElement[] elements) where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, Memory<TElement> elements) where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, Span<TElement> elements) where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TEnumerator, TResult>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;
	}
}
