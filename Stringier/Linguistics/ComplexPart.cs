using System;
using System.Text;

namespace Langly.Linguistics {
	internal sealed class ComplexPart : Orthography.Part {
		private readonly Func<UInt32, Boolean> Func;

		public ComplexPart(Int64 count, Func<UInt32, Boolean> func) {
			Count = count;
			Func = func;
		}

		/// <inheritdoc/>
		public override Int64 Count { get; }

		/// <inheritdoc/>
		protected override Boolean Contains(Char element) => Func(element);

		/// <inheritdoc/>
		protected override Boolean Contains(Rune element) => Func(unchecked((UInt32)element.Value));

		/// <inheritdoc/>
		protected override Boolean Contains(Glyph element) => Func(element.Code);
	}
}
