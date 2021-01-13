//NOTE: The contents of this file are not technically part of the backport, but are so useful they are provided anyways. License should still be considered MIT, .NET Foundation. I'm not going to make a claim on any of this because it's all trivial code.

using System.Collections;
using System.Collections.Generic;

namespace System.Text {
	/// <summary>
	/// 
	/// </summary>
	public struct SeqRuneEnumerator : IEnumerable<Rune>, IEnumerator<Rune> {
		private readonly IEnumerator<Char> Chars;
		private Rune Rune;

		internal SeqRuneEnumerator(IEnumerable<Char> seq) {
			Chars = seq.GetEnumerator();
			Rune = Rune.ReplacementChar;
		}

		/// <inheritdoc/>
		public Rune Current => Rune;

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
		Object? IEnumerator.Current => Current;

		/// <inheritdoc/>
		void IDisposable.Dispose() {
			// no-op
		}

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => this;

		/// <inheritdoc/>
		IEnumerator<Rune> IEnumerable<Rune>.GetEnumerator() => this;

		/// <inheritdoc/>
		void IEnumerator.Reset() => Chars.Reset();
	}
}
