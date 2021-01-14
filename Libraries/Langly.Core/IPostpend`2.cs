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
		/// <returns>The result of postpending the element.</returns>
		[return: NotNull]
		TResult Postpend([AllowNull] TElement element);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: NotNull]
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
		/// <returns>The result of postpending the elements.</returns>
		[return: NotNull]
		TResult Postpend(Memory<TElement> elements) => Postpend((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: NotNull]
		TResult Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements.Span);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: NotNull]
		TResult Postpend(Span<TElement> elements) => Postpend((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: NotNull]
		TResult Postpend(ReadOnlySpan<TElement> elements) {
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				_ = Postpend(elements[i]);
			}
			return (TResult)this;
		}
	}
	
	public static partial class CoreExtensions {
		/// <summary>
		/// Postpends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to postpend.</param>
		/// <returns>The result of postpending the element.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] TElement element) => collection is not null ? collection.Postpend(element) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, [AllowNull] params TElement[] elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, Memory<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, Span<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>The result of postpending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Postpend<TElement, TResult>([AllowNull] this IPostpend<TElement, TResult> collection, ReadOnlySpan<TElement> elements) => collection is not null ? collection.Postpend(elements) : (TResult)collection;
	}
}
