using System;
using System.Runtime.InteropServices;

namespace Langly {
	[StructLayout(LayoutKind.Auto)]
	public ref struct SpanGlyphEnumerator {
		private readonly ReadOnlySpan<Char> buffer;
		private Int32 nextIndex;

		internal SpanGlyphEnumerator(ReadOnlySpan<Char> value) {
			buffer = value;
			Current = default;
			nextIndex = 0;
		}

		public Glyph Current { get; private set; }

		public SpanGlyphEnumerator GetEnumerator() => this;

		public Boolean MoveNext() {
			if (nextIndex >= buffer.Length) {
				Current = default;
				return false;
			}
			Current = new Glyph(Glyph.Equivalencies.Parse(buffer, ref nextIndex));
			return true;
		}
	}
}
