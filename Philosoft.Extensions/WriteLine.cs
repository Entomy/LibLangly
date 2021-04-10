using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class PhilosoftExtensions {
		/// <summary>
		/// Writes a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWrite<Char, TResult> stream) where TResult : IWrite<Char, TResult> => stream is not null ? stream.Write(Environment.NewLine) : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="element"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="element">The <see cref="Char"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWrite<Char, TResult> stream, Char element) where TResult : IWrite<Char, TResult> => stream is not null ? stream.Write(element).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="String"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWrite<Char, TResult> stream, [AllowNull] String elements) where TResult : IWrite<Char, TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWrite<Char, TResult> stream, [AllowNull] params Char[] elements) where TResult : IWrite<Char, TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWrite<Char, TResult> stream, Memory<Char> elements) where TResult : IWrite<Char, TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWrite<Char, TResult> stream, ReadOnlyMemory<Char> elements) where TResult : IWrite<Char, TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

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

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The text to write.</param>
		/// <param name="length">The length of the <paramref name="elements"/>.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[CLSCompliant(false)]
		[return: MaybeNull]
		public static unsafe TResult WriteLine<TResult>([AllowNull] this IWriteUnsafe<Char, TResult> stream, [AllowNull] Char* elements, Int32 length) where TResult : IWriteUnsafe<Char, TResult> => stream is not null ? stream.Write(elements, length).WriteLine() : (TResult)stream;
	}
}
