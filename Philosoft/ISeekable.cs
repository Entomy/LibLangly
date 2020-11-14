using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the type can be seeked.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to seek.</typeparam>
	/// <typeparam name="TError">The type of the error object.</typeparam>
	public interface ISeekable<TElement, TError> {
		/// <summary>
		/// Can this be seeked?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="ISeekable{TElement, TError}"/> can be seeked, but that doesn't mean it can always be seeked. Rather, this being <see langword="true"/> indicates the type can currently be seeked.
		/// </remarks>
		Boolean Seekable { get; }

		/// <summary>
		/// The position within the datastream, counted by <typeparamref name="TElement"/> offset.
		/// </summary>
		nint Position { get; set; }

		/// <summary>
		/// Seeks to the <paramref name="offset"/>.
		/// </summary>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		/// <remarks>
		/// This assumes the seek will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TrySeek(nint)"/> or <see cref="TrySeek(nint, out TError)"/> instead.
		/// </remarks>
		void Seek(nint offset);

		/// <summary>
		/// Attempts to seek to the <paramref name="offset"/>.
		/// </summary>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		/// <returns><see langword="true"/> if the seek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TrySeek(nint, out TError)"/>
		Boolean TrySeek(nint offset) => TrySeek(offset, out _);

		/// <summary>
		/// Attempts to seek to the <paramref name="offset"/>.
		/// </summary>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the seek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TrySeek(nint)"/>
		Boolean TrySeek(nint offset, [MaybeNullWhen(true), NotNullWhen(false)] out TError error);
	}

	public static partial class Extensions {
		/// <summary>
		/// Seeks to the <paramref name="offset"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to seek.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to seek.</param>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		public static void Seek<TElement, TError>([MaybeNull] this ISeekable<TElement, TError> collection, nint offset) => collection?.Seek(offset);

		/// <summary>
		/// Attempts to seek to the <paramref name="offset"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to seek.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to seek.</param>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		/// <returns><see langword="true"/> if the seek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TrySeek{TElement, TError}(ISeekable{TElement, TError}, nint, out TError)"/>
		public static Boolean TrySeek<TElement, TError>([MaybeNull] this ISeekable<TElement, TError> collection, nint offset) => collection?.TrySeek(offset) ?? false;

		/// <summary>
		/// Attempts to seek to the <paramref name="offset"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to seek.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to seek.</param>
		/// <param name="offset">The offset of <typeparamref name="TElement"/> from the current position to seek to.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the seek was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TrySeek{TElement, TError}(ISeekable{TElement, TError}, nint)"/>
		public static Boolean TrySeek<TElement, TError>([MaybeNull] this ISeekable<TElement, TError> collection, nint offset, [MaybeNullWhen(true)] out TError error) {
			if (collection is not null) {
				return collection.TrySeek(offset, out error);
			} else {
				error = default;
				return false;
			}
		}
	}
}
