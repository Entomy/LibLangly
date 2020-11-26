using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be written to.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TError">The type of the error object.</typeparam>
	public interface IWritable<in TElement, TError> {
		/// <summary>
		/// Can this be written to?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IWritable{TElement, TError}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
		/// </remarks>
		public Boolean Writable { get; }

		/// <summary>
		/// Writes a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement)"/> or <see cref="TryWrite(TElement, out TError)"/> instead.
		/// </remarks>
		public void Write(TElement element);

		/// <summary>
		/// Attempts to write a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryWrite(TElement, out TError)"/>
		public Boolean TryWrite(TElement element) => TryWrite(element, out _);

		/// <summary>
		/// Attempts to write a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryWrite(TElement)"/>
		public Boolean TryWrite(TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error);
	}

	public static partial class Extensions {
		/// <summary>
		/// Writes a <typeparamref name="TElement"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="element">The element to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement)"/> or <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement, out TError)"/> instead.
		/// </remarks>
		public static void Write<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, TElement element) {
			if (collection is null) {
				return;
			}
			collection.Write(element);
		}

		/// <summary>
		/// Attempts to write a <typeparamref name="TElement"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="element">The <typeparamref name="TElement"/> to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, TElement element) => TryWrite(collection, element, out _);

		/// <summary>
		/// Attempts to write a <typeparamref name="TElement"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="element">The <typeparamref name="TElement"/> to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				error = default;
				return true;
			}
			return collection.TryWrite(element, out error);
		}

		public static partial class Friendly {
			public static Tuple<Boolean, TError> TryWrite<TElement, TError>([AllowNull] IWritable<TElement, TError> collection, TElement element) {
				Boolean result = collection.TryWrite(element, out TError error);
				return new Tuple<Boolean, TError>(result, error);
			}
		}
	}
}
