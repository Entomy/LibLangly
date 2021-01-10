using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPrepend<TElement, out TResult> {
		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <param name="element">The element to prepend.</param>
		/// <returns>The result of prepending the element.</returns>
		[return: NotNull]
		TResult Prepend([AllowNull] TElement element);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: NotNull]
		TResult Prepend([AllowNull] params TElement[] elements) {
			if (elements is null) {
				return (TResult)this;
			}
			return Prepend(elements.AsMemory());
		}

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: NotNull]
		TResult Prepend(Memory<TElement> elements) => Prepend((ReadOnlyMemory<TElement>)elements);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: NotNull]
		TResult Prepend(ReadOnlyMemory<TElement> elements) => Prepend(elements.Span);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: NotNull]
		TResult Prepend(Span<TElement> elements) => Prepend((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: NotNull]
		TResult Prepend(ReadOnlySpan<TElement> elements) {
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				_ = Prepend(elements[i]);
			}
			return (TResult)this;
		}
	}

	public static partial class CoreExtensions {
		/// <summary>
		/// Prepends the element onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="element">The element to prepend.</param>
		/// <returns>The result of prepending the element.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] TElement element) => collection is not null ? collection.Prepend(element) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, [AllowNull] params TElement[] elements) => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, Memory<TElement> elements) => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, ReadOnlyMemory<TElement> elements) => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, Span<TElement> elements) => collection is not null ? collection.Prepend(elements) : (TResult)collection;

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <typeparam name="TElement">The type of the elements.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="collection">This collection.</param>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>The result of prepending the elements.</returns>
		[return: MaybeNull, NotNullIfNotNull("collection")]
		public static TResult Prepend<TElement, TResult>([AllowNull] this IPrepend<TElement, TResult> collection, ReadOnlySpan<TElement> elements) => collection is not null ? collection.Prepend(elements) : (TResult)collection;
	}
}
