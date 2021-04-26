using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="element"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="element">The <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, [AllowNull] TElement element) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(element) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="String"/> to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TResult>([AllowNull] this IWrite<Char, TResult> stream, [AllowNull] String elements) where TResult : IWrite<Char, TResult> => stream is not null && elements is not null ? stream.Write(elements.AsMemory()) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, [AllowNull] params TElement[] elements) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, Memory<TElement> elements) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWrite<TElement, TResult> stream, ReadOnlyMemory<TElement> elements) where TResult : IWrite<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWriteSpan<TElement, TResult> stream, Span<TElement> elements) where TResult : IWriteSpan<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TElement, TResult>([AllowNull] this IWriteSpan<TElement, TResult> stream, ReadOnlySpan<TElement> elements) where TResult : IWriteSpan<TElement, TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to write.</typeparam>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">A pointer to the <see cref="Char"/> values to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult Write<TElement, TResult>([AllowNull] this IWriteUnsafe<TElement, TResult> stream, [AllowNull] TElement* elements, Int32 length) where TElement : unmanaged where TResult : IWriteUnsafe<TElement, TResult> => stream is not null ? stream.Write(elements, length) : (TResult)stream;
	}
}
