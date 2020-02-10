//! This exists to backport Rune to older runtimes, since we're going to take advantage of it throughout the entire project, so it must exist. By conditionally including it, and multitargeting both runtimes without and with the Rune type, it can be provided without colliding.
//! This (public) API must match the official one exactly. As such, copyright belongs to the .NET Foundation. The internals can be implemented using existing API's in Core.

#if NETSTANDARD2_0
using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text {
	// An enumerator for retrieving System.Text.Rune instances from a ROS<char>.
	// Methods are pattern-matched by compiler to allow using foreach pattern.
	public ref struct SpanRuneEnumerator {
		private ReadOnlySpan<Char> _remaining;
		private Rune _current;

		internal SpanRuneEnumerator(ReadOnlySpan<Char> buffer) {
			_remaining = buffer;
			_current = default;
		}

		public Rune Current => _current;

		public SpanRuneEnumerator GetEnumerator() => this;

		public bool MoveNext() {
			if (_remaining.IsEmpty) {
				// reached the end of the buffer
				_current = default;
				return false;
			}

			Int32 scalarValue = Rune.ReadFirstRuneFromUtf16Buffer(_remaining);
			if (scalarValue < 0) {
				// replace invalid sequences with U+FFFD
				scalarValue = Rune.ReplacementChar.Value;
			}

			// In UTF-16 specifically, invalid sequences always have length 1, which is the same
			// length as the replacement character U+FFFD. This means that we can always bump the
			// next index by the current scalar's UTF-16 sequence length. This optimization is not
			// generally applicable; for example, enumerating scalars from UTF-8 cannot utilize
			// this same trick.

			_current = new Rune((UInt32)scalarValue);
			_remaining = _remaining.Slice(_current.Utf16SequenceLength);
			return true;
		}
	}
}
#endif