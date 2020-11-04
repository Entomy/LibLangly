using System;
using System.Text;

namespace Philosoft {
	/// <summary>
	/// Indicates the type can have textual elements added to it.
	/// </summary>
	[CLSCompliant(false)]
	public interface IAddableText {
		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Char element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Rune element) {
			unsafe {
				Span<Char> buffer = stackalloc Char[2];
				if (element.EncodeToUtf16(buffer) == 1) {
					Add(buffer[0]);
				} else {
					Add(buffer);
				}
			}
		}

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(String element) => Add(element.AsSpan());

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Memory<Char> element) => Add(element.Span);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(ReadOnlyMemory<Char> element) => Add(element.Span);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(Span<Char> element) => Add((ReadOnlySpan<Char>)element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		void Add(ReadOnlySpan<Char> element);

		/// <summary>
		/// Adds an element into the collection.
		/// </summary>
		/// <param name="element">The element to add to the collection.</param>
		/// <param name="length">The length of the <paramref name="element"/>.</param>
		/// <remarks>
		/// The behavior of this operation is collection dependant, and no particular location in the collection should be assumed.
		/// </remarks>
		unsafe void Add(Char* element, Int32 length) => Add(new ReadOnlySpan<Char>(element, length));
	}
}
