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
			public override Char this[nint index] => index == 0 ? Text : throw new IndexOutOfRangeException();

			/// <inheritdoc/>
			public override nint Length => 1;

			/// <inheritdoc/>
			public override String ToString() => Text.ToString();
		}
	}
}
