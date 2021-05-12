#if !NETSTANDARD1_3
using System.Diagnostics.CodeAnalysis;
#endif

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements added to it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	public interface IAddSpan<TElement> : IAddMemory<TElement> {
#if !NETSTANDARD1_3
		/// <inheritdoc/>
		void IAddMemory<TElement>.Add([AllowNull] params TElement[] elements) => Add(elements.AsSpan());

		/// <inheritdoc/>
		void IAddMemory<TElement>.Add(Memory<TElement> elements) => Add(elements.Span);

		/// <inheritdoc/>
		void IAddMemory<TElement>.Add(ReadOnlyMemory<TElement> elements) => Add(elements.Span);
#endif

		/// <summary>
		/// Adds the elements to this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(Span<TElement> elements)
#if !NETSTANDARD1_3
			=> Add((ReadOnlySpan<TElement>)elements)
#endif
			;

		/// <summary>
		/// Adds the elements to this object, as a batch.
		/// </summary>
		/// <param name="elements">The elements to add.</param>
		/// <remarks>
		/// The behavior of this operation is type dependent, and no particular location in the collection should be assumed. It is further possible the type the element is added to is not a collection.
		/// </remarks>
		void Add(ReadOnlySpan<TElement> elements);
	}
}
