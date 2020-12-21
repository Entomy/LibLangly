using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents text as a sequence of UTF-16 code units.
	/// </summary>
	/// <remarks>
	/// Unlike a <see cref="String"/>, this is a highly flexible and dynamic data structure, and operations upon it are done through structural transformations instead of more traditional algorithms. <see cref="Rope"/> tends to be far more efficient in non-trivial situations as a result.
	/// </remarks>
	public sealed partial class Rope : IAddableText, ILengthy, IIndexable<Char> {
		/// <summary>
		/// The first <see cref="Node"/> of the <see cref="Rope"/>.
		/// </summary>
		private Node Head;

		/// <summary>
		/// The last <see cref="Node"/> of the <see cref="Rope"/>.
		/// </summary>
		private Node Tail;

		/// <summary>
		/// Initializes a new <see cref="Rope"/>.
		/// </summary>
		public Rope() {
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// Initializes a new <see cref="Rope"/>.
		/// </summary>
		/// <param name="text">The initial text of the rope.</param>
		public Rope([AllowNull] String text) {
			if (text is not null) {
				Head = new StringNode(text, next: null, previous: null);
				Tail = Head;
				Length += text.Length;
			} else {
				Head = null;
				Tail = null;
			}
		}

		/// <inheritdoc/>
		public nint Length { get; set; }

		/// <inheritdoc/>
		Char IReadOnlyIndexable<nint, Char>.this[nint index] => this[index];

		/// <inheritdoc/>
		public Char this[nint index] {
			get {
				Node N = Head;
				nint pos = 0;
				while (pos <= index - N.Length) {
					pos += N.Length;
					N = N.Next;
				}
				while (pos < index) {
					pos++;
				}
				return N is not null ? N[index - pos] : throw new IndexOutOfRangeException();
			}
			set => throw new IndexOutOfRangeException();
		}

		public static implicit operator Rope([AllowNull] String text) => new Rope(text);

		/// <inheritdoc/>
		void IAddableText.Add(Char element) {
			Tail = new CharNode(element, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length++;
		}

		/// <inheritdoc/>
		void IAddableText.Add(System.Text.Rune element) => throw new NotImplementedException();

		/// <inheritdoc/>
		void IAddableText.Add([AllowNull] String element) {
			if (element is null) {
				return;
			}
			Tail = new StringNode(element, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length += element.Length;
		}

		/// <inheritdoc/>
		void IAddableText.Add(Memory<Char> element) => throw new NotImplementedException();

		/// <inheritdoc/>
		void IAddableText.Add(ReadOnlyMemory<Char> element) => throw new NotImplementedException();

		/// <inheritdoc/>
		void IAddableText.Add(Span<Char> element) => throw new NotImplementedException();

		/// <inheritdoc/>
		void IAddableText.Add(ReadOnlySpan<Char> element) => throw new NotImplementedException();

		/// <inheritdoc/>
		unsafe void IAddableText.Add(Char* element, Int32 length) => throw new NotImplementedException();
	}
}
