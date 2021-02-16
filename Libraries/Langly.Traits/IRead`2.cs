using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Indicates the type can be read from.
	/// </summary>
	/// <typeparam name="TElement">The type of the element to read.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IRead<TElement, out TResult> where TResult : IRead<TElement, TResult> {
		/// <summary>
		/// Can this be read from?
		/// </summary>
		/// <remarks>
		/// This is a state indicator. Of course an <see cref="IRead{TElement, TError}"/> can be read from, but that doesn't mean it can always be read from. Rather, this being <see langword="true"/> indicates the type can currently be read from.
		/// </remarks>
		Boolean Readable { get; }

		/// <summary>
		/// Reads a <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		[return: MaybeNull]
		TResult Read([MaybeNull] out TElement element);

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		[return: MaybeNull]
		TResult Read(nint amount, [MaybeNull] out TElement[] elements) {
			TResult result = (TResult)this;
			elements = new TElement[amount];
			for (nint i = 0; i < elements.Length; i++) {
				result = result is not null ? result.Read(out elements[i]) : result;
			}
			return result;
		}

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		[return: MaybeNull]
		TResult Read(nint amount, out ReadOnlyMemory<TElement> elements) {
			TResult result = (TResult)this;
			Memory<TElement> buffer = new TElement[amount];
			for (Int32 i = 0; i < buffer.Length; i++) {
				result = result is not null ? result.Read(out buffer.Span[i]) : result;
			}
			elements = buffer;
			return result;
		}
	}

	public static partial class TraitExtensions {
		/// <summary>
		/// Reads a <typeparamref name="TElement"/> from the <paramref name="stream"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="element">The <typeparamref name="TElement"/> value that was read.</param>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, [MaybeNull] out TElement element) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				element = default;
				return (TResult)stream;
			}
			return stream.Read(out element);
		}

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, nint amount, [MaybeNull] out TElement[] elements) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				elements = default;
				return (TResult)stream;
			}
			return stream.Read(amount, out elements);
		}

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <typeparam name="TElement">The type of the element to read.</typeparam>
		/// <typeparam name="TResult">The resulting type; often itself..</typeparam>
		/// <param name="stream">This stream.</param>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		[return: MaybeNull]
		public static TResult Read<TElement, TResult>([AllowNull] this IRead<TElement, TResult> stream, nint amount, out ReadOnlyMemory<TElement> elements) where TResult : IRead<TElement, TResult> {
			if (stream is null) {
				elements = default;
				return (TResult)stream;
			}
			return stream.Read(amount, out elements);
		}
	}
}
