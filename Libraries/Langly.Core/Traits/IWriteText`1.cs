using System;
using System.Diagnostics.CodeAnalysis;
using Langly.Traits;

namespace Langly.Traits {
	/// <summary>
	/// Indicates the type can be written to, with additional textual operations.
	/// </summary>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IWriteText<out TResult> : IAddText<TResult>, IWrite<Char, TResult> where TResult : IWriteText<TResult> {
		/// <summary>
		/// Writes the <paramref name="elements"/>.
		/// </summary>
		/// <param name="elements">The <see cref="String"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public TResult Write([AllowNull] String elements) => Add(elements);

		/// <summary>
		/// Writes a line terminator.
		/// </summary>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public TResult WriteLine() => Write(Environment.NewLine);
	}
}

namespace Langly {
	public static partial class TraitExtensions {
		/// <summary>
		/// Writes the <paramref name="elements"/> to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The type of the error object.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="String"/> to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Write<TResult>([AllowNull] this IWriteText<TResult> stream, [AllowNull] String elements) where TResult : IWriteText<TResult> => stream is not null ? stream.Write(elements) : (TResult)stream;

		/// <summary>
		/// Writes a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteText<TResult> stream) where TResult : IWriteText<TResult> => stream is not null ? stream.WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="element"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="element">The <see cref="Char"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteText<TResult> stream, Char element) where TResult : IWriteText<TResult> => stream is not null ? stream.Write(element).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="String"/> value to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteText<TResult> stream, [AllowNull] String elements) where TResult : IWriteText<TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteText<TResult> stream, [AllowNull] params Char[] elements) where TResult : IWriteText<TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Memory{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteText<TResult> stream, Memory<Char> elements) where TResult : IWriteText<TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlyMemory{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteText<TResult> stream, ReadOnlyMemory<Char> elements) where TResult : IWriteText<TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="Span{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteSpan<Char, TResult> stream, Span<Char> elements) where TResult : IWriteSpan<Char, TResult>, IWriteText<TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

		/// <summary>
		/// Writes the <paramref name="elements"/> and a line terminator to the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="elements">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> values to write.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult WriteLine<TResult>([AllowNull] this IWriteSpan<Char, TResult> stream, ReadOnlySpan<Char> elements) where TResult : IWriteSpan<Char, TResult>, IWriteText<TResult> => stream is not null ? stream.Write(elements).WriteLine() : (TResult)stream;

	}
}
