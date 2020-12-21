using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public partial class Rope {
		private unsafe class PointerNode : Node {
			private readonly Char* Text;

			private readonly Int32 length;

			public PointerNode([DisallowNull] Char* text, Int32 length, [AllowNull] Node next, [AllowNull] Node previous) : base(next, previous) {
				Text = text;
				this.length = length;
			}

			/// <inheritdoc/>
			public override Char this[nint index] => Text[index];

			/// <inheritdoc/>
			public override nint Length { get; }
		}
	}
}
