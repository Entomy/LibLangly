using System;

namespace Stringier {
	public partial class Rope {
		/// <summary>
		/// Represents a node of a <see cref="Rope"/>, whos backing is a <see cref="System.Char"/>.
		/// </summary>
		private sealed class CharNode : Node {
			/// <summary>
			/// The element contained in this node.
			/// </summary>
			private readonly Char Char;

			public CharNode(Char @char, Node? next, Node? previous) : base(next, previous) => Char = @char;

			/// <inheritdoc/>
			public override Char this[Int32 index] {
				get {
					if (index == 0) {
						return Char;
					}
					throw new IndexOutOfRangeException();
				}
			}

			/// <inheritdoc/>
			public override Int32 Count => 1;

			/// <inheritdoc/>
			public override Boolean Contains(Char element) => Equals(Char, element);

			/// <inheritdoc/>
			public override Boolean Contains(Predicate<Char>? predicate) => predicate?.Invoke(Char) ?? false;

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, Char element) {
				Node head;
				Node tail;
				switch (index) {
				case 0:
					tail = this;
					head = new CharNode(element, previous: null, next: tail);
					tail.Previous = head;
					break;
				case 1:
					head = this;
					tail = new CharNode(element, previous: head, next: null);
					head.Next = tail;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, String element) {
				Node head;
				Node tail;
				switch (index) {
				case 0:
					tail = this;
					head = new StringNode(element, previous: null, next: tail);
					tail.Previous = head;
					break;
				case 1:
					head = this;
					tail = new StringNode(element, previous: head, next: null);
					head.Next = tail;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Insert(Int32 index, Char[] element) {
				Node head;
				Node tail;
				switch (index) {
				case 0:
					tail = this;
					head = new ArrayNode(element, previous: null, next: tail);
					tail.Previous = head;
					break;
				case 1:
					head = this;
					tail = new ArrayNode(element, previous: head, next: null);
					head.Next = tail;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
				return (head, tail);
			}

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Remove(Char element) => throw new NotImplementedException();

			/// <inheritdoc/>
			public override (Node Head, Node Tail) Replace(Char search, Char replace) {
				if (Equals(Char, search)) {
					Node rep = new CharNode(replace, previous: null, next: null);
					return (rep, rep);
				} else {
					return (this, this);
				}
			}

			/// <inheritdoc/>
			public override String ToString() => Char.ToString();
		}
	}
}
