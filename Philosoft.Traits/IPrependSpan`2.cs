using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPrependSpan<TElement, out TResult> : IPrepend<TElement, TResult> where TResult : IPrependSpan<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IPrepend<TElement, TResult>.Prepend(Memory<TElement> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IPrepend<TElement, TResult>.Prepend(ReadOnlyMemory<TElement> elements) => Prepend(elements.Span);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend(Span<TElement> elements) => Prepend((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Prepends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		/// <returns>If the prepend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and prepended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Prepend(ReadOnlySpan<TElement> elements) {
			TResult? result = (TResult)this;
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				if ((result = result!.Prepend(elements[i])) is null) { return default; }
			}
			return result;
		}
	}
}
