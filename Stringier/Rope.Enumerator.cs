using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope : IEnumerable<Char, Rope.Enumerator> {
		/// <inheritdoc/>
		public Enumerator GetEnumerator() => new Enumerator(this);

		public struct Enumerator : IEnumerator<Char> {
			[DisallowNull] private readonly Rope Rope;

			[AllowNull] private Node Node;

			private nint i;

			public Enumerator(Rope rope) {
				Rope = rope;
				Node = null;
				i = -1;
			}

			/// <inheritdoc/>
			public Char Current => Node[i];

			/// <inheritdoc/>
			public Boolean MoveNext() {
				if (Node is null) {
					Node = Rope.Head;
				}
				if (++i < Node.Length) {
					return true;
				} else {
					Node = Node.Next;
					i = 0;
					return Node is not null;
				}
			}

			/// <inheritdoc/>
			public void Reset() {
				Node = Rope.Head;
				i = -1;
			}
		}
	}
}
