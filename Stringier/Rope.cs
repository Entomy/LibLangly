using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	/// <summary>
	/// Represents text as a sequence of UTF-16 code units.
	/// </summary>
	/// <remarks>
	/// Unlike a <see cref="String"/>, this is a highly flexible and dynamic data structure, and operations upon it are done through structural transformations instead of more traditional algorithms. <see cref="Rope"/> tends to be far more efficient in non-trivial situations as a result.
	/// </remarks>
	public sealed partial class Rope : IAddableText, IEquatable<Rope>, IIndexable<Char>, ILengthy {
		/// <summary>
		/// The first <see cref="Node"/> of the <see cref="Rope"/>.
		/// </summary>
		[AllowNull]
		private Node Head;

		/// <summary>
		/// The last <see cref="Node"/> of the <see cref="Rope"/>.
		/// </summary>
		[AllowNull]
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

		public static Boolean operator !=([AllowNull] Rope left, [AllowNull] Rope right) {
			if (left is null && right is null) {
				return false;
			} else if (left is null || right is null) {
				return true;
			} else {
				return !left.Equals(right);
			}
		}

		public static Boolean operator ==([AllowNull] Rope left, [AllowNull] Rope right) {
			if (left is null && right is null) {
				return true;
			} else if (left is null || right is null) {
				return false;
			} else {
				return left.Equals(right);
			}
		}

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
		void IAddableText.Add([AllowNull] params Char[] elements) {
			if (elements is not null) {
				this.Add(elements.AsMemory());
			}
		}

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
		void IAddableText.Add(Memory<Char> element) {
			Tail = new MemoryNode(element, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length += element.Length;
		}

		/// <inheritdoc/>
		void IAddableText.Add(ReadOnlyMemory<Char> element) {
			Tail = new MemoryNode(element, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length += element.Length;
		}

		/// <inheritdoc/>
		void IAddableText.Add(Span<Char> element) {
			Char[] buffer = new Char[element.Length];
			element.CopyTo(buffer);
			Tail = new MemoryNode(buffer, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length += element.Length;
		}

		/// <inheritdoc/>
		void IAddableText.Add(ReadOnlySpan<Char> element) {
			Char[] buffer = new Char[element.Length];
			element.CopyTo(buffer);
			Tail = new MemoryNode(buffer, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length += element.Length;
		}

		/// <inheritdoc/>
		unsafe void IAddableText.Add([AllowNull] Char* element, Int32 length) {
			if (element is null) {
				return;
			}
			Tail = new PointerNode(element, length, next: null, previous: Tail);
			if (Head is null) {
				Head = Tail;
			} else {
				Tail.Previous.Next = Tail;
			}
			Length += length;
		}

		/// <inheritdoc/>
		public override Boolean Equals([AllowNull] Object obj) {
			switch (obj) {
			case Rope rope:
				return Equals(rope);
			default:
				return false;
			}
		}

		/// <inheritdoc/>
		public Boolean Equals([AllowNull] Rope other) {
			if (ReferenceEquals(this, other)) {
				return true;
			}
			if (other is null || Length != other.Length) {
				return false;
			}
			using Enumerator T = GetEnumerator();
			using Enumerator O = other.GetEnumerator();
			while (T.MoveNext() && O.MoveNext()) {
				if (T.Current != O.Current) {
					return false;
				}
			}
			return true;
		}

		/// <inheritdoc/>
		public override String ToString() {
			Char[] chars = new Char[Length];
			nint c = 0;
			Node N = Head;
			nint n = 0;
			while (c < Length) {
				while (n < N.Length) {
					chars[c++] = N[n++];
				}
				N = N.Next;
				n = 0;
			}
			return new String(chars);
		}
	}
}
