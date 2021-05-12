#if !NETSTANDARD1_3
using System.Diagnostics.CodeAnalysis;
#endif

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IPostpendSpan<TElement> : IPostpendMemory<TElement> {
#if !NETSTANDARD1_3
		/// <inheritdoc/>
		void IPostpendMemory<TElement>.Postpend([AllowNull] params TElement[] elements) => Postpend(elements.AsSpan());

		/// <inheritdoc/>
		void IPostpendMemory<TElement>.Postpend(Memory<TElement> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		void IPostpendMemory<TElement>.Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements.Span);
#endif

		/// <summary>
		/// Postpends the elements onto this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		void Postpend(Span<TElement> elements)
#if !NETSTANDARD1_3
			=> Postpend((ReadOnlySpan<TElement>)elements)
#endif
			;

		/// <summary>
		/// Postpends the elements onto this object, a batch.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		void Postpend(ReadOnlySpan<TElement> elements);
	}
}
