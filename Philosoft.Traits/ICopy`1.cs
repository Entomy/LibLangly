using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type is a sequence of <typeparamref name="TElement"/>.
	/// </summary>
	/// <typeparam name="TElement">The type of elements in the collection.</typeparam>
	public interface ICopy<TElement> {
		/// <summary>
		/// Copies all the elements of the current sequence into an array.
		/// </summary>
		/// <param name="array">The array to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		/// <exception cref="ArgumentNullException">The destination is <see langword="null"/>.</exception>
		void CopyTo([DisallowNull] TElement[] array) => CopyTo(array.AsSpan());

		/// <summary>
		/// Copies all the elements of the current sequence into a memory region.
		/// </summary>
		/// <param name="memory">The memory to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		void CopyTo(Memory<TElement> memory) => CopyTo(memory.Span);

		/// <summary>
		/// Copyes all the elements of the current sequence into the span.
		/// </summary>
		/// <param name="span">The span to copy items into.</param>
		/// <exception cref="ArgumentException">The destination is shorter than this sequence.</exception>
		void CopyTo(Span<TElement> span);
	}
}
