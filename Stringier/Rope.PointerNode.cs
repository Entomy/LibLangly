using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope {
		private unsafe class PointerNode : Node {
			private readonly Int32 length;
			private readonly Char* Text;
			public PointerNode([DisallowNull] Char* text, Int32 length, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) {
				Text = text;
				this.length = length;
			}

			/// <inheritdoc/>
			public override nint Length { get; }

			/// <inheritdoc/>
			public override Char this[nint index] => Text[index];

			/// <inheritdoc/>
			internal override void Insert(nint index, Char element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override void Insert(nint index, [DisallowNull] String element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override void Insert(nint index, ReadOnlyMemory<Char> element, out Node head, out Node tail) => throw new NotImplementedException();

			/// <inheritdoc/>
			internal override unsafe void Insert(nint index, [DisallowNull] Char* element, Int32 length, out Node head, out Node tail) => throw new NotImplementedException();
		}
	}
}
