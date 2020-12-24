using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Langly {
	/// <summary>
	/// Indicates the type can have textual elements inserted into it.
	/// </summary>
	[CLSCompliant(false)]
	public interface IInsertableText {
		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, Char element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, Rune element) {
			unsafe {
				Span<Char> buffer = stackalloc Char[2];
				if (element.EncodeToUtf16(buffer) == 1) {
					Insert(index, buffer[0]);
				} else {
					Insert(index, buffer);
				}
			}
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, [AllowNull] String element) {
			if (element is not null) {
				Insert(index, element.AsMemory());
			}
		}

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, Memory<Char> element) => Insert(index, element.Span);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, ReadOnlyMemory<Char> element) => Insert(index, element.Span);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, Span<Char> element) => Insert(index, (ReadOnlySpan<Char>)element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		void Insert(nint index, ReadOnlySpan<Char> element);

		/// <summary>
		/// Insert an element into the collection at the specified index.
		/// </summary>
		/// <param name="index">The index at which <paramref name="element"/> should be inserted.</param>
		/// <param name="element">The object to insert.</param>
		/// <param name="length">The length of the <paramref name="element"/>.</param>
		unsafe void Insert(nint index, [AllowNull] Char* element, Int32 length) {
			if (element is not null) {
				Insert(index, new ReadOnlySpan<Char>(element, length));
			}
		}
	}
}
