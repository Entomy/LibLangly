using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Reads a <typeparamref name="TElement"/> from the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, [MaybeNull] out TElement element) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				element = default;
				return (TResult)stream;
			}
			return stream.Read(out element);
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, [MaybeNull] TElement[] elements) where TResult : IRead<TElement, TResult> => stream is not null ? stream.Read(elements) : (TResult)stream;

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, nint amount, [MaybeNull] out TElement[] elements) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				elements = default;
				return (TResult)stream;
			}
			return stream.Read(amount, out elements);
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, Memory<TElement> elements) where TResult : IRead<TElement, TResult> => stream is not null ? stream.Read(elements) : (TResult)stream;

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, nint amount, out ReadOnlyMemory<TElement> elements) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				elements = default;
				return (TResult)stream;
			}
			return stream.Read(amount, out elements);
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, Span<TElement> elements) where TResult : IRead<TElement, TResult> => stream is not null ? stream.Read(elements) : (TResult)stream;

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, nint amount, out ReadOnlySpan<TElement> elements) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				elements = default;
				return (TResult)stream;
			}
			return stream.Read(amount, out elements);
		}
	}
}
