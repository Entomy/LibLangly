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

			/// <inheritdoc/>
			internal override void Insert(nint index, Char element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override void Insert(nint index, [AllowNull] String element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override void Insert(nint index, ReadOnlyMemory<Char> element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override unsafe void Insert(nint index, [AllowNull] Char* element, Int32 length, out Node head, out Node tail) => throw new NotImplementedException();
		}
	}
}
