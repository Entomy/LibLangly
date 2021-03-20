using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Langly {
	[StructLayout(LayoutKind.Auto)]
	public struct StringGlyphEnumerator : System.Collections.Generic.IEnumerator<Glyph> {
		private readonly ReadOnlyMemory<Char> @string;
		private Int32 nextIndex;

		internal StringGlyphEnumerator(String value) : this(value.AsMemory()) { }

		internal StringGlyphEnumerator(Char[] value) : this(value.AsMemory()) { }

		internal StringGlyphEnumerator(ReadOnlyMemory<Char> value) {
			@string = value;
			Current = default;
			nextIndex = 0;
		}

		/// <inheritdoc/>
		public Glyph Current { get; private set; }

		/// <inheritdoc/>
		System.Object IEnumerator.Current => Current;

		public StringGlyphEnumerator GetEnumerator() => this;

		/// <inheritdoc/>
		public void Dispose() { /* No-op */ }

		/// <inheritdoc/>
		public Boolean MoveNext() {
			if (nextIndex >= @string.Length) {
				Current = default;
				return false;
			}
			Current = new Glyph(Glyph.Parser.Parse(@string, ref nextIndex));
			return true;
		}

		/// <inheritdoc/>
		public void Reset() {
			Current = default;
			nextIndex = 0;
		}
	}
}
