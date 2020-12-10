using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be written to.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TError">The type of the error object.</typeparam>
	public interface IWritable<TElement, TError> {
		/// <summary>
		/// Can this be written to?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IWritable{TElement, TError}"/> can be written to, but that doesn't mean it can always be written to. Rather, this being <see langword="true"/> indicates the type can currently be written to.
		/// </remarks>
		public Boolean Writable { get; }

		/// <summary>
		/// Writes a <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement, out TError)"/> instead.
		/// </remarks>
		public void Write(TElement element);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement[], out TError)"/> instead.
		/// </remarks>
		public void Write([AllowNull] TElement[] elements) {
			if (elements is null) {
				return;
			}
			foreach (TElement element in elements) {
				Write(element);
			}
		}

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement[], out TError)"/> instead.
		/// </remarks>
		public void Write(Memory<TElement> elements) => Write(elements.Span);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement[], out TError)"/> instead.
		/// </remarks>
		public void Write(ReadOnlyMemory<TElement> elements) => Write(elements.Span);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement[], out TError)"/> instead.
		/// </remarks>
		public void Write(Span<TElement> elements) => Write((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite(TElement[], out TError)"/> instead.
		/// </remarks>
		public void Write(ReadOnlySpan<TElement> elements) {
			foreach (TElement element in elements) {
				Write(element);
			}
		}

		/// <summary>
		/// Attempts to write a <paramref name="element"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public Boolean TryWrite(TElement element, [MaybeNullWhen(true), NotNullWhen(false)] out TError error);

		/// <summary>
		/// Attempts to write the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public Boolean TryWrite([AllowNull] TElement[] elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			error = default;
			if (elements is null) {
				return true;
			}
			foreach (TElement element in elements) {
				if (!TryWrite(element, out error)) {
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public Boolean TryWrite(Memory<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) => TryWrite(elements.Span, out error);

		/// <summary>
		/// Attempts to write the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public Boolean TryWrite(ReadOnlyMemory<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) => TryWrite(elements.Span, out error);

		/// <summary>
		/// Attempts to write the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public Boolean TryWrite(Span<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) => TryWrite((ReadOnlySpan<TElement>)elements, out error);

		/// <summary>
		/// Attempts to write the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public Boolean TryWrite(ReadOnlySpan<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			error = default;
			foreach (TElement element in elements) {
				if (!TryWrite(element, out error)) {
					return false;
				}
			}
			return true;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="element"/> to the <paramref name="collection"/>.
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
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[])"/> or <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[], out TError)"/> instead.
		/// </remarks>
		public static void Write<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, [AllowNull] TElement[] elements) {
			if (collection is null) {
				return;
			}
			collection.Write(elements);
		}

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[])"/> or <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[], out TError)"/> instead.
		/// </remarks>
		public static void Write<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, Memory<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Write(elements);
		}

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[])"/> or <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[], out TError)"/> instead.
		/// </remarks>
		public static void Write<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, ReadOnlyMemory<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Write(elements);
		}

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[])"/> or <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[], out TError)"/> instead.
		/// </remarks>
		public static void Write<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, Span<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Write(elements);
		}

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <remarks>
		/// This assumes the write will never fail, which is an assumption that generally doesn't hold up. It is strongly recommended to use <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[])"/> or <see cref="TryWrite{TElement, TError}(IWritable{TElement, TError}, TElement[], out TError)"/> instead.
		/// </remarks>
		public static void Write<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, ReadOnlySpan<TElement> elements) {
			if (collection is null) {
				return;
			}
			collection.Write(elements);
		}

		/// <summary>
		/// Attempts to write the <paramref name="element"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="element">The <typeparamref name="TElement"/> to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, TElement element) => TryWrite(collection, element, out _);

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, [AllowNull] TElement[] elements) {
			if (collection is null) {
				return true;
			}
			return collection.TryWrite(elements);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, Memory<TElement> elements) {
			if (collection is null) {
				return true;
			}
			return collection.TryWrite(elements);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, ReadOnlyMemory<TElement> elements) {
			if (collection is null) {
				return true;
			}
			return collection.TryWrite(elements);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, Span<TElement> elements) {
			if (collection is null) {
				return true;
			}
			return collection.TryWrite(elements);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, ReadOnlySpan<TElement> elements) {
			if (collection is null) {
				return true;
			}
			return collection.TryWrite(elements);
		}

		/// <summary>
		/// Attempts to write the <paramref name="element"/> to the <paramref name="collection"/>.
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

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, [AllowNull] TElement[] elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				error = default;
				return true;
			}
			return collection.TryWrite(elements, out error);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, Memory<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				error = default;
				return true;
			}
			return collection.TryWrite(elements, out error);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, ReadOnlyMemory<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				error = default;
				return true;
			}
			return collection.TryWrite(elements, out error);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, Span<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				error = default;
				return true;
			}
			return collection.TryWrite(elements, out error);
		}

		/// <summary>
		/// Attempts to write the <paramref name="elements"/> to the <paramref name="collection"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TError">The type of the error object.</typeparam>
		/// <param name="collection">The collection to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <param name="error">The <typeparamref name="TError"/> that occurred, if any.</param>
		/// <returns><see langword="true"/> if the write was successful; otherwise, <see langword="false"/>.</returns>
		public static Boolean TryWrite<TElement, TError>([AllowNull] this IWritable<TElement, TError> collection, ReadOnlySpan<TElement> elements, [MaybeNullWhen(true), NotNullWhen(false)] out TError error) {
			if (collection is null) {
				error = default;
				return true;
			}
			return collection.TryWrite(elements, out error);
		}
	}
}
