using System;
using System.Diagnostics.CodeAnalysis;

namespace Philosoft {
	/// <summary>
	/// Indicates the type can be read from.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	/// <typeparam name="TError">The type of the error object.</typeparam>
	public interface IReadable<TElement, TError> {
		/// <summary>
		/// Can this be read from?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IReadable{TElement, TError}"/> can be read from, but that doesn't mean it can always be read from. Rather, this being <see langword="true"/> indicates the type can currently be read from.
		/// </remarks>
		public Boolean Readable { get; }

		/// <summary>
		/// Reads a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		/// <remarks>
		/// This assumes the read will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryRead(out TElement)"/> or <see cref="TryRead(out TElement, out TError)"/> instead.
		/// </remarks>
		public void Read([MaybeNull] out TElement element);

		/// <summary>
		/// Attempts to read a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out TElement, out TError)"/>
		public Boolean TryRead([MaybeNullWhen(false), NotNullWhen(true)] out TElement element) => TryRead(out element, out _);

		/// <summary>
		/// Attempts to read a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		/// <seealso cref="TryRead(out TElement)"/>
		public Boolean TryRead([MaybeNullWhen(false), NotNullWhen(true)] out TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error);
	}

	public static partial class Extensions {
		/// <summary>
		/// Reads a <typeparamref name="TElement"/> from the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to read from.</param>
		/// <param name="element">The element that was read.</param>
		/// <remarks>
		/// This assumes the read will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryRead{TElement, TError}(IReadable{TElement, TError}, out TElement)"/> or <see cref="TryRead{TElement, TError}(IReadable{TElement, TError}, out TElement, out TError)"/> instead.
		/// </remarks>
		public static void Read<TElement, TError>([AllowNull] this IReadable<TElement, TError> collection, [MaybeNull] out TElement element) {
			if (collection is null) {
				element = default;
				return;
			}
			collection.Read(out element);
		}

		/// <summary>
		/// Attempts to read a <typeparamref name="TElement"/> from the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to read from.</param>
		/// <param name="element">The element that was read.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryRead<TElement, TError>([AllowNull] this IReadable<TElement, TError> collection, [MaybeNullWhen(false), NotNullWhen(true)] out TElement element) => TryRead(collection, out element, out _);

		/// <summary>
		/// Attempts to read a <typeparamref name="TElement"/> from the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to read from.</param>
		/// <param name="element">The element that was read.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the read was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryRead<TElement, TError>([AllowNull] this IReadable<TElement, TError> collection, [MaybeNullWhen(false), NotNullWhen(true)] out TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				element = default;
				error = default;
				return true;
			}
			return collection.TryRead(out element, out error);
		}

		public static partial class Friendly {
			[return: MaybeNull]
			public static TElement Read<TElement, TError>([AllowNull] IReadable<TElement, TError> collection) {
				collection.Read(out TElement element);
				return element;
			}

			public static Tuple<Boolean, TError, TElement> TryRead<TElement, TError>([AllowNull] IReadable<TElement, TError> collection) {
				Boolean result = collection.TryRead(out TElement element, out TError error);
				return new Tuple<Boolean, TError, TElement>(result, error, element);
			}
		}
	}
}
