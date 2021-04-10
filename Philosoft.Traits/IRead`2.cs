using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
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
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Read([MaybeNull] out TElement element);

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The <see cref="Array"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Read([AllowNull] TElement[] elements) => elements is not null ? Read(elements.AsMemory()) : (TResult)this;

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The <see cref="Memory{T}"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Read(Memory<TElement> elements) => Read(elements.Span);

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Read(nint amount, out ReadOnlyMemory<TElement> elements) {
			TResult? result = (TResult)this;
			Memory<TElement> buffer = new TElement[amount];
			Int32 i = 0;
			for (; i < amount; i++) {
				result = result is not null ? result.Read(out buffer.Span[i]) : result;
			}
			elements = buffer.Slice(0, i);
			return result;
		}

		/// <summary>
		/// Reads until the <paramref name="elements"/> is filled.
		/// </summary>
		/// <param name="elements">The <see cref="Span{T}"/> of <typeparamref name="TElement"/> to fill.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Read(Span<TElement> elements) {
			TResult? result = (TResult)this;
			for (Int32 i = 0; i < elements.Length; i++) {
				if ((result = result!.Read(out elements[i])) is null) { return default; }
			}
			return result;
		}

		/// <summary>
		/// Reads <paramref name="amount"/> of <typeparamref name="TElement"/>.
		/// </summary>
		/// <param name="amount">The amount of elements to read.</param>
		/// <param name="elements">The <typeparamref name="TElement"/> values that were read.</param>
		/// <returns>A <typeparamref name="TResult"/> instance if successful; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Read(nint amount, out ReadOnlySpan<TElement> elements) {
			TResult? result = Read(amount, out ReadOnlyMemory<TElement> elmts);
			elements = elmts.Span;
			return result;
		}
	}
}
