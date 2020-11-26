using System;
using System.Text;

namespace Langly {
	/// <summary>
	/// Indicates the type can have elements added to it by textual index.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	[CLSCompliant(false)]
	public interface IAddableText<in TElement> {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Char index, TElement element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Rune index, TElement element) {
			unsafe {
				Span<Char> buffer = stackalloc Char[2];
				if (index.EncodeToUtf16(buffer) == 1) {
					Add(buffer[0], element);
				} else {
					Add(buffer, element);
				}
			}
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(String index, TElement element) => Add(index.AsSpan(), element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Memory<Char> index, TElement element) => Add(index.Span, element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(ReadOnlyMemory<Char> index, TElement element) => Add(index.Span, element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Span<Char> index, TElement element) => Add((ReadOnlySpan<Char>)index, element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(ReadOnlySpan<Char> index, TElement element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="index">The text index of the <paramref name="element"/>.</param>
		/// <param name="length">The length of the <paramref name="index"/>.</param>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		unsafe void Add(Char* index, Int32 length, TElement element) => Add(new ReadOnlySpan<Char>(index, length), element);
	}
}
