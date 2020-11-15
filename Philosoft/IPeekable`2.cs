using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the type can be peeked.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	/// <typeparam name="TError">The type of the error object.</typeparam>
	public interface IPeekable<TElement, TError> : IReadable<TElement, TError> {
		/// <summary>
		/// Returns the element at the beginning of the collection without removing it.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		/// <remarks>
		/// This assumes the peek will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryPeek(out TElement)"/> or <see cref="TryPeek(out TElement, out TError)"/> instead.
		/// </remarks>
		public void Peek([MaybeNull] out TElement element);

		/// <summary>
		/// Returns the element at the beginning of the collection without removing it.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out TElement, out TError)"/>
		public Boolean TryPeek([MaybeNullWhen(false), NotNullWhen(true)] out TElement element) => TryRead(out element, out _);

		/// <summary>
		/// Returns the element at the beginning of the collection without removing it.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was peeked.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryPeek(out TElement)"/>
		public Boolean TryPeek([MaybeNullWhen(false), NotNullWhen(true)] out TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error);
	}

	public static partial class Extensions {
		/// <summary>
		/// Returns the element at the beginning of the collection without removing it.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to peek.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to peek from.</param>
		/// <param name="element">The element that was peeked.</param>
		/// <remarks>
		/// This assumes the peek will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryPeek{TElement, TError}(IPeekable{TElement, TError}, out TElement)"/> or <see cref="TryPeek{TElement, TError}(IPeekable{TElement, TError}, out TElement, out TError)"/> instead.
		/// </remarks>
		public static void Peek<TElement, TError>([AllowNull] this IPeekable<TElement, TError> collection, [MaybeNull] out TElement element) {
			if (collection is null) {
				element = default;
				return;
			}
			collection.Peek(out element);
		}

		/// <summary>
		/// Attempts to peek a byte from the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to peek.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to peek from.</param>
		/// <param name="element">The element that was peeked.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryPeek<TElement, TError>([AllowNull] this IPeekable<TElement, TError> collection, [MaybeNullWhen(false), NotNullWhen(true)] out TElement element) => TryPeek(collection, out element, out _);

		/// <summary>
		/// Attempts to peek a byte from the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to peek.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to peek from.</param>
		/// <param name="element">The element that was peeked.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the peek was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryPeek<TElement, TError>([AllowNull] this IPeekable<TElement, TError> collection, [MaybeNullWhen(false), NotNullWhen(true)] out TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				element = default;
				error = default;
				return true;
			}
			return collection.TryPeek(out element, out error);
		}

	}
}
