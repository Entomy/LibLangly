using Stringier.Encodings;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Stringier {
	public partial struct Glyph {
		internal sealed class Trie : IEnumerable<Trie> {
			private readonly UInt32 Code;

			private readonly IDictionary<Char, Trie> Continuations = new Dictionary<Char, Trie>();

			public Trie() => Code = 0;

			public Trie(UInt32 code) => Code = code;

			public void Add(String sequence, UInt32 code) => Add(sequence.AsSpan(), code);

			public void Add(ReadOnlySpan<Char> sequence, UInt32 code) {
				if (sequence.Length == 1) {
					if (!Continuations.ContainsKey(sequence[0])) {
						Continuations.Add(sequence[0], new Trie(code));
					}
				} else {
					Continuations[sequence[0]].Add(sequence.Slice(1), code);
				}
			}

			/// <inheritdoc/>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			/// <inheritdoc/>
			public IEnumerator<Trie> GetEnumerator() => Continuations.Values.GetEnumerator();

			public UInt32 Parse(ReadOnlyMemory<Char> sequence, ref Int32 pos) => Parse(sequence.Span, ref pos);

			public UInt32 Parse(ReadOnlySpan<Char> sequence, ref Int32 pos) {
				if (pos == sequence.Length) {
					return Code;
				}
				if (UTF16.IsHighSurrogate(sequence[pos])) {
					return HighSurrogate.Parse(sequence, ref pos);
				}
				if (!Continuations.TryGetValue(sequence[pos], out Trie next)) {
					return Code;
				} else {
					pos++;
					return next.ParseContinuations(sequence, ref pos);
				}
			}

			private UInt32 ParseContinuations(ReadOnlySpan<Char> sequence, ref Int32 pos) {
				if (pos == sequence.Length) {
					return Code;
				}
				if (!Continuations.TryGetValue(sequence[pos], out Trie next)) {
					return Code;
				} else {
					pos++;
					return next.Parse(sequence, ref pos);
				}
			}

			public Boolean TryGetValue(String sequence, ref Int32 pos, out UInt32 code) => TryGetValue(sequence.AsSpan(), ref pos, out code);

			public Boolean TryGetValue(ReadOnlySpan<Char> sequence, ref Int32 pos, out UInt32 code) {
				if (pos == sequence.Length) {
					code = Code;
					return true;
				}
				if (UTF16.IsHighSurrogate(sequence[pos])) {
					return HighSurrogate.TryGetValue(sequence, ref pos, out code);
				}
				if (!Continuations.TryGetValue(sequence[pos], out Trie next)) {
					code = 0;
					return false;
				} else {
					pos++;
					return next.TryGetValue(sequence, ref pos, out code);
				}
			}

			private static class HighSurrogate {
				public static UInt32 Parse(ReadOnlySpan<Char> sequence, ref Int32 pos) {
					if (UTF16.IsHighSurrogate(sequence[pos])) {
						pos++;
						return LowSurrogate.Parse(sequence, ref pos);
					} else {
						return 0xFFFD;
					}
				}

				public static Boolean TryGetValue(ReadOnlySpan<Char> sequence, ref Int32 pos, out UInt32 code) {
					if (UTF16.IsHighSurrogate(sequence[pos])) {
						pos++;
						return LowSurrogate.TryGetValue(sequence, ref pos, out code);
					} else {
						code = 0;
						return false;
					}
				}
			}

			private static class LowSurrogate {
				public static UInt32 Parse(ReadOnlySpan<Char> sequence, ref Int32 pos) {
					if (UTF16.IsLowSurrogate(sequence[pos])) {
						return Unsafe.Utf16Decode(sequence[pos - 1], sequence[pos++]);
					}
					return 0xFFFD;
				}

				public static Boolean TryGetValue(ReadOnlySpan<Char> sequence, ref Int32 pos, out UInt32 code) {
					code = Parse(sequence, ref pos);
					return code != 0xFFFD;
				}
			}
		}
	}
}
