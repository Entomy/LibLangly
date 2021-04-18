using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
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
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add([AllowNull] this String collection, Char element) => collection.Postpend(element);

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
		public static Memory<TElement> Add<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement element) => collection.Postpend(element);

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

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>Returns an <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement>(this Span<TElement> collection, [AllowNull] TElement element) => collection.Postpend(element);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">this collection.</param>
		/// <param name="element">The element to add.</param>
		/// <returns>Returns an <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement element) => collection.Postpend(element);
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add([AllowNull] this String collection, [AllowNull] params Char[] elements) => collection.Postpend(elements);

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
		public static Memory<TElement> Add<TElement>([AllowNull] this TElement[] collection, [AllowNull] params TElement[] elements) => collection.Postpend(elements);

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

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement>(this Span<TElement> collection, [AllowNull] params TElement[] elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] params TElement[] elements) => collection.Postpend(elements);
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add([AllowNull] this String collection, Memory<Char> elements) => collection.Postpend(elements);

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

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement>(this Span<TElement> collection, Memory<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, Memory<TElement> elements) => collection.Postpend(elements);
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
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add([AllowNull] this String collection, ReadOnlyMemory<Char> elements) => collection.Postpend(elements);

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

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this Span<TElement> collection, ReadOnlyMemory<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, ReadOnlyMemory<TElement> elements) => collection.Postpend(elements);
		#endregion

		#region Add(Collection, Span<TElement>)
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
		public static TResult Add<TElement, TResult>([AllowNull] this IAddSpan<TElement, TResult> collection, Span<TElement> elements) where TResult : IAddSpan<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<Char> Add([AllowNull] this String collection, Span<Char> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement>([AllowNull] this TElement[] collection, Span<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement>(this Memory<TElement> collection, Span<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, Span<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement>(this Span<TElement> collection, Span<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, Span<TElement> elements) => collection.Postpend(elements);
		#endregion

		#region Add(Collection, ReadOnlySpan<TElement>)
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
		public static TResult Add<TElement, TResult>([AllowNull] this IAddSpan<TElement, TResult> collection, ReadOnlySpan<TElement> elements) where TResult : IAddSpan<TElement, TResult> => collection is not null ? collection.Add(elements) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<Char> Add([AllowNull] this String collection, ReadOnlySpan<Char> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>([AllowNull] this TElement[] collection, ReadOnlySpan<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this Memory<TElement> collection, ReadOnlySpan<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, ReadOnlySpan<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this Span<TElement> collection, ReadOnlySpan<TElement> elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, ReadOnlySpan<TElement> elements) => collection.Postpend(elements);
		#endregion

		#region Add(Collection, TElement*, Int32)
		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>If the add occurred successfully, returns a <typeparamref name="TResult"/> containing the original and added elements; otherwise, <see langword="null"/>.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Add<TElement, TResult>([AllowNull] this IAddUnsafe<TElement, TResult> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IAddUnsafe<TElement, TResult> => collection is not null ? collection.Add(elements, length) : (TResult)collection;

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<Char> Add([AllowNull] this String collection, [AllowNull] Char* elements, Int32 length) => collection.Postpend(elements, length);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Add<TElement>([AllowNull] this TElement[] collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Postpend(elements, length);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Add<TElement>(this Memory<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Postpend(elements, length);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Add<TElement>(this ReadOnlyMemory<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Postpend(elements, length);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Add<TElement>(this Span<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Postpend(elements, length);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe ReadOnlySpan<TElement> Add<TElement>(this ReadOnlySpan<TElement> collection, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged => collection.Postpend(elements, length);
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

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add<TEnumerator>([AllowNull] this String collection, [AllowNull] ISequence<Char, TEnumerator> elements) where TEnumerator : IEnumerator<Char> => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Memory<TElement> Add<TElement, TEnumerator>([AllowNull] this TElement[] collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Memory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Memory<TElement> Add<TElement, TEnumerator>(this Memory<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<TElement> Add<TElement, TEnumerator>(this ReadOnlyMemory<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="Span{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static Span<TElement> Add<TElement, TEnumerator>(this Span<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection.Postpend(elements);

		/// <summary>
		/// Adds the elements to this collection.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="elements"/>.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<TElement> Add<TElement, TEnumerator>(this ReadOnlySpan<TElement> collection, [AllowNull] ISequence<TElement, TEnumerator> elements) where TEnumerator : IEnumerator<TElement> => collection.Postpend(elements);
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

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="collection">this collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="String"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static String Add([AllowNull] this String collection, [AllowNull] String elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="collection">this collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add([AllowNull] this Char[] collection, [AllowNull] String elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="collection">this collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add(this Memory<Char> collection, [AllowNull] String elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="collection">this collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlyMemory<Char> Add(this ReadOnlyMemory<Char> collection, [AllowNull] String elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="collection">this collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<Char> Add(this Span<Char> collection, [AllowNull] String elements) => collection.Postpend(elements);

		/// <summary>
		/// Adds an element to this collection.
		/// </summary>
		/// <param name="collection">this collection.</param>
		/// <param name="elements">The elements to add.</param>
		/// <returns>Returns a <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> containing the original and added elements.</returns>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		public static ReadOnlySpan<Char> Add(this ReadOnlySpan<Char> collection, [AllowNull] String elements) => collection.Postpend(elements);
		#endregion
	}
}
