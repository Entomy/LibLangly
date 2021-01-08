using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements added to it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IAdd<TElement, out TResult> {
		/// <summary>
		/// Adds an element to this object.
		/// </summary>
		/// <param name="element">The element to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add([AllowNull] TElement element);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add([AllowNull] TElement[] elements) {
			if (elements is null) {
				return (TResult)this;
			}
			return Add(elements.AsMemory());
		}

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add(Memory<TElement> elements) => Add((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add(ReadOnlyMemory<TElement> elements) => Add(elements.Span);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add(Span<TElement> elements) => Add((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add(ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				_ = Add(element);
			}
			return (TResult)this;
		}

		/// <summary>
		/// Adds the elements to this object.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		TResult Add<TEnumerator>([AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> {
			if (elements is null) {
				return (TResult)this;
			}
			foreach (TElement element in elements) {
				_ = Add(element);
			}
			return (TResult)this;
		}
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] TElement element) => collection is not null ? collection.Add(element) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] TElement[] elements) => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, Memory<TElement> elements) => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, Span<TElement> elements) => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TResult>([AllowNull] this IAdd<TElement, TResult> collection, ReadOnlySpan<TElement> elements) => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Add<TElement, TEnumerator, TResult>([AllowNull] this IAdd<TElement, TResult> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection is not null ? collection.Add(elements) : (TResult)collection;
	}
}
