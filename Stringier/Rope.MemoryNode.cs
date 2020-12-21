using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope {
		private class MemoryNode : Node {
			private readonly ReadOnlyMemory<Char> Text;

			public MemoryNode(ReadOnlyMemory<Char> text, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) => Text = text;

			/// <inheritdoc/>
			public override Char this[nint index] => Text.Span[(Int32)index];

			/// <inheritdoc/>
			public override nint Length => Text.Length;
		}
	}
}
