using Philosoft;
using System;
using System.Runtime.InteropServices;

namespace Stringier {
	[StructLayout(LayoutKind.Auto)]
	public struct StringGlyphEnumerator : IEnumerator<Glyph> {
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
		public Boolean MoveNext() {
			if (nextIndex >= @string.Length) {
				Current = default;
				return false;
			}
			Current = new Glyph(Glyph.Equivalencies.Parse(@string, ref nextIndex));
			return true;
		}

		/// <inheritdoc/>
		public void Reset() {
			Current = default;
			nextIndex = 0;
		}
	}
}
