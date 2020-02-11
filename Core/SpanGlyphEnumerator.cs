using System;
using System.Collections;
using System.Collections.Generic;

namespace Stringier {
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
			Current = Glyph.GetGlyphAt(buffer, nextIndex, out Int32 charsConsumed);
			nextIndex += charsConsumed;
			return charsConsumed > 0;
		}
	}
}
