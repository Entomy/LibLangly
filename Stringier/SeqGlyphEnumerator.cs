using Philosoft;
using System;
using System.Runtime.InteropServices;

namespace Stringier {
	[StructLayout(LayoutKind.Auto)]
	public struct SeqGlyphEnumerator : IEnumerator<Glyph> {
		private readonly System.Collections.Generic.IEnumerator<Char> Chars;

		private Glyph current;

		internal SeqGlyphEnumerator(System.Collections.Generic.IEnumerable<Char> value) {
			Chars = value.GetEnumerator();
			current = default;
		}

		/// <inheritdoc/>
		public Glyph Current {
			get => current;
			private set => current = value;
		}

		/// <inheritdoc/>
		public void Dispose() => Chars?.Dispose();

		/// <inheritdoc/>
		public Boolean MoveNext() => Chars is not null && Glyph.Equivalencies.Parse(Chars, out current);

		/// <inheritdoc/>
		public void Reset() => Chars?.Reset();
	}
}
