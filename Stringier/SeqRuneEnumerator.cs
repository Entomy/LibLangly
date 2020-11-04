using System;
using System.Text;
using Philosoft;

namespace Stringier {
	public struct SeqRuneEnumerator : IEnumerator<Rune> {
		private readonly System.Collections.Generic.IEnumerator<Char> Chars;
		private Rune Rune;

		internal SeqRuneEnumerator(System.Collections.Generic.IEnumerable<Char> seq) {
			Chars = seq.GetEnumerator();
			Rune = Rune.ReplacementChar;
		}

		/// <inheritdoc/>
		public Rune Current => Rune;

		/// <inheritdoc/>
		void IDisposable.Dispose() => Chars.Dispose();

		/// <inheritdoc/>
		public SeqRuneEnumerator GetEnumerator() => this;

		/// <inheritdoc/>
		public Boolean MoveNext() {
			if (!Chars.MoveNext()) {
				return false;
			}
			Char high = Chars.Current;
			if (Char.IsHighSurrogate(high)) {
				if (!Chars.MoveNext()) {
					return false;
				}
				Char low = Chars.Current;
				if (Char.IsLowSurrogate(low)) {
					Rune = new Rune(high, low);
				} else {
					Rune = Rune.ReplacementChar;
				}
			} else {
				Rune = new Rune(high);
			}
			return true;
		}

		/// <inheritdoc/>
		public void Reset() => Chars.Reset();
	}
}
