using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can be written to, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to write.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IWriteSpan<TElement, out TResult> : IAddSpan<TElement, TResult>, IWrite<TElement, TResult> where TResult : IWriteSpan<TElement, TResult> {
		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write(Span<TElement> elements) => Add(elements);

		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <typeparamref name="TElement"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Write(ReadOnlySpan<TElement> elements) => Add(elements);
	}
}

namespace Langly {
	public static partial class TraitExtensions {
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
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>
		/// </summary>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteSpan<Char, TResult> stream, Span<Char> elements) where TResult : IWriteSpan<Char, TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>
		/// </summary>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteSpan<Char, TResult> stream, ReadOnlySpan<Char> elements) where TResult : IWriteSpan<Char, TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;
	}
}
