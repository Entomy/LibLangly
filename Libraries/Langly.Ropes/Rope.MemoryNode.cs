using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Langly.Traits;

namespace Langly {
	public partial class Rope {
		/// <summary>
		/// Represents a <see cref="Node"/> holding multiple contiguous elements.
		/// </summary>
		private sealed class MemoryNode : Node, ISlice<MemoryNode> {
			/// <summary>
			/// The contiguous memory contained in the node.
			/// </summary>
			private readonly ReadOnlyMemory<Char> Memory;

			/// <summary>
			/// Initializes a new <see cref="MemoryNode"/>.
			/// </summary>
			/// <param name="memory">The contiguous memory contained in the node.</param>
			/// <param name="previous">The previous node in the rope.</param>
			/// <param name="next">The next node in the rope.</param>
			public MemoryNode(ReadOnlyMemory<Char> memory, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Memory = memory;

			/// <inheritdoc/>
			public override nint Count => Memory.Length;

			/// <inheritdoc/>
			public override Char this[nint index] {
				get {
					if (0 > index || index >= Count) {
						throw new IndexOutOfRangeException();
					}
					return Memory.Span[(Int32)index];
				}
			}

			/// <inheritdoc/>
			public override Boolean Equals([AllowNull] Node other) {
				switch (other) {
				case MemoryNode node:
					return Memory.Equals(node.Memory);
				default:
					return false;
				}
			}

			/// <inheritdoc/>
			[return: MaybeNull]
			public MemoryNode Slice(nint start, nint length) => new MemoryNode(Memory.Slice((Int32)start, (Int32)length), previous: null, next: null);

			/// <inheritdoc/>
			[return: NotNull]
			public override String ToString() => Memory.ToString();
		}
	}
}
