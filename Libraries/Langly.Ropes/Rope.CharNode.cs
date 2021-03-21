using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope {
		/// <summary>
		/// Represents a <see cref="Node"/> holding a single <see cref="Char"/>.
		/// </summary>
		private sealed class CharNode : Node {
			/// <summary>
			/// The <see cref="System.Char"/> contained in the node.
			/// </summary>
			private readonly Char Char;

			/// <summary>
			/// Initializes a new <see cref="CharNode"/>.
			/// </summary>
			/// <param name="char">The <see cref="System.Char"/> contained in the node.</param>
			/// <param name="previous">The previous node in the rope.</param>
			/// <param name="next">The next node in the rope.</param>
			public CharNode(Char @char, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Char = @char;

			/// <inheritdoc/>
			public override Char this[nint index] {
				get {
					if (index != 0) {
						throw new IndexOutOfRangeException();
					}
					return Char;
				}
			}

			/// <inheritdoc/>
			public override nint Count => 1;

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) {
				switch (other) {
				case CharNode node:
					return Char.Equals(node.Char);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Char.ToString();
		}
	}
}
