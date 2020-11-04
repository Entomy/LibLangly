using System;
using System.Text;

namespace Stringier.Linguistics {
	internal class SplitPart : SimplePart {
		private readonly UInt32 Second;

		public SplitPart(UInt32 first, UInt32 second, UInt32 margin) : base(first, first + margin) => Second = second;

		/// <inheritdoc/>
		public override Int64 Count => Margin * 2;

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => base.Contains(element) || element - Second <= Margin;

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => base.Contains(element) || element.Value - Second <= Margin;

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => base.Contains(element) || element.Code - First <= Margin;
	}
}
