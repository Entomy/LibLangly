#if !NETSTANDARD1_3
using System.Diagnostics.CodeAnalysis;
#endif

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements prepended onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPrependSpan<TElement> : IPrependMemory<TElement> {
#if !NETSTANDARD1_3
		/// <inheritdoc/>
		void IPrependMemory<TElement>.Prepend([AllowNull] params TElement[] elements) => Prepend(elements.AsSpan());

		/// <inheritdoc/>
		void IPrependMemory<TElement>.Prepend(Memory<TElement> elements) => Prepend(elements.Span);

		/// <inheritdoc/>
		void IPrependMemory<TElement>.Prepend(ReadOnlyMemory<TElement> elements) => Prepend(elements.Span);
#endif

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend(Span<TElement> elements)
#if !NETSTANDARD1_3
			=> Prepend((ReadOnlySpan<TElement>)elements)
#endif
			;

		/// <summary>
		/// Prepends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to prepend.</param>
		void Prepend(ReadOnlySpan<TElement> elements);
	}
}
