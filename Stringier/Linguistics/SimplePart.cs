using Collectathon.Sets;
using System;
using System.Text;

namespace Stringier.Linguistics {
	internal class SimplePart : Orthography.Part {
		protected internal readonly UInt32 First;

		protected internal readonly UInt32 Margin;

		public SimplePart(UInt32 first, UInt32 last) {
			First = first;
			Margin = last - first;
		}

		/// <inheritdoc/>
		public override Int64 Count => Margin;

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => element - First <= Margin;

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => element.Value - First <= Margin;

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => element.Code - First <= Margin;
	}
}
