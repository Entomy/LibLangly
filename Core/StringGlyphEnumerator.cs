using System;
using System.Collections;
using System.Collections.Generic;

namespace Stringier {
	public struct StringGlyphEnumerator : IEnumerable<Glyph>, IEnumerator<Glyph> {
		private readonly String @string;
		private Int32 nextIndex;

		internal StringGlyphEnumerator(String value) {
			@string = value;
			Current = default;
			nextIndex = 0;
		}

		public Glyph Current { get; private set; }

		Object? IEnumerator.Current => Current;

		void IDisposable.Dispose() { }

		public StringGlyphEnumerator GetEnumerator() => this;

		IEnumerator IEnumerable.GetEnumerator() => this;

		IEnumerator<Glyph> IEnumerable<Glyph>.GetEnumerator() => this;

		public Boolean MoveNext() {
			if (nextIndex >= @string.Length) {
				Current = default;
				return false;
			}
			Current = Glyph.GetGlyphAt(@string, nextIndex, out Int32 charsConsumed);
			nextIndex += charsConsumed;
			return charsConsumed > 0;
		}

		void IEnumerator.Reset() {
			Current = default;
			nextIndex = 0;
		}
	}
}
