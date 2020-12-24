using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope {
		/// <summary>
		/// Represents a <see cref="Rope"/> node whos content is a <see cref="Char"/>.
		/// </summary>
		protected sealed class CharNode : Node {
			private Char Text;

			public CharNode(Char text, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) => Text = text;

			/// <inheritdoc/>
			public override nint Length => 1;

			/// <inheritdoc/>
			public override Char this[nint index] => index == 0 ? Text : throw new IndexOutOfRangeException();
			/// <inheritdoc/>
			public override String ToString() => Text.ToString();

			/// <inheritdoc/>
			internal override void Insert(nint index, Char element, out Node head, out Node tail) {
				switch (index) {
				case 0:
					head = new CharNode(element, this, Previous);
					tail = this;
					tail.Previous = head;
					break;
				case 1:
					head = this;
					tail = new CharNode(element, Next, this);
					head.Next = tail;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
			}

			/// <inheritdoc/>
			internal override void Insert(nint index, [DisallowNull] String element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override void Insert(nint index, ReadOnlyMemory<Char> element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override unsafe void Insert(nint index, [DisallowNull] Char* element, Int32 length, out Node head, out Node tail) => throw new NotImplementedException();
		}
	}
}
