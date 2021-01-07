using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly.DataStructures.Lists {
	public partial class Chain<TElement> {
		/// <summary>
		/// Represents a <see cref="Node"/> holding multiple contiguous elements.
		/// </summary>
		private sealed class MemoryNode : Node {
			/// <summary>
			/// The contiguous memory contained in the node.
			/// </summary>
			private readonly ReadOnlyMemory<TElement> Memory;

			/// <summary>
			/// Initializes a new <see cref="MemoryNode"/>.
			/// </summary>
			/// <param name="memory">The contiguous memory contained in the node.</param>
			/// <param name="previous">The previous node in the chain.</param>
			/// <param name="next">The next node in the chain.</param>
			public MemoryNode(ReadOnlyMemory<TElement> memory, [AllowNull] Node previous, [AllowNull] Node next) : base(previous, next) => Memory = memory;

			/// <inheritdoc/>
			public override nint Count => Memory.Length;
		}
	}
}
