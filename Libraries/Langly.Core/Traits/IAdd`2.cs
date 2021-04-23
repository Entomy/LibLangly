﻿using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
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
		TResult Add(ReadOnlyMemory<TElement> elements) {
			TResult? result = (TResult)this;
			foreach (TElement element in elements.Span) {
				if ((result = result!.Add(element)) is null) { return default; }
			}
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
			TResult? result = (TResult)this;
			if (elements is not null) {
				foreach (TElement element in elements) {
					if ((result = result!.Add(element)) is null) { return default; }
				}
			}
			return result;
		}
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		#region Add(Collection, TElement)
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
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>Returns an <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("elements")]
		public static TElement[] Add<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) => collection.Postpend(element);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>Returns an <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Memory<TElement> Add<TElement>(this Memory<TElement> collection, [AllowNull] TElement element) => collection.Postpend(element);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>Returns an <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement element) => collection.Postpend(element);
		#endregion

		#region Add(Collection, TElement[])
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Array"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection"), NotNullIfNotNull("elements")]
		public static TElement[] Add<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Memory<TElement> Add<TElement>(this Memory<TElement> collection, [AllowNull] params TElement[] elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] params TElement[] elements) => collection.Postpend(elements);
		#endregion

		#region Add(Collection, Memory<TElement>)
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Memory<TElement> Add<TElement>([AllowNull] this TElement[] collection, Memory<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Memory<TElement> Add<TElement>(this Memory<TElement> collection, Memory<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, Memory<TElement> elements) => collection.Postpend(elements);
		#endregion

		#region Add(Collection, ReadOnlyMemory<TElement>)
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement>([AllowNull] this TElement[] collection, ReadOnlyMemory<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement>(this Memory<TElement> collection, ReadOnlyMemory<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, ReadOnlyMemory<TElement> elements) => collection.Postpend(elements);
		#endregion

		#region Add(Collection, Sequence)
		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TElement, TResult, TEnumerator>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> where TResult : IAdd<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;
		#endregion

		#region Add(Collection, String)
		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull]
		public static TResult Add<TResult>([AllowNull] this IAdd<Char, TResult> collection, [AllowNull] String elements) where TResult : IAdd<Char, TResult> => collection is not null && elements is not null ? collection.Add(elements.AsMemory()) : (TResult)collection;
		#endregion
	}
}