using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Stringier.Linguistics {
	/// <summary>
	/// Provides a counter for glyphs of an orthography.
	/// </summary>
	/// <remarks>
	/// This is used to count phoneme/syllable glyphs, not numeric, punctual, or otherwise.
	/// </remarks>
	internal sealed class Counter<TGrapheme> : Orthography.Counter where TGrapheme : IEquatable<Char>, IEquatable<Rune>, IEquatable<Glyph>, IEquatable<TGrapheme> {
		internal readonly (TGrapheme Grapheme, nint Count)[] Counts;

		/// <inheritdoc/>
		public Counter(params TGrapheme[] graphemes) {
			Counts = new (TGrapheme, nint)[graphemes.Length];
			Int32 i = 0;
			foreach (TGrapheme grapheme in graphemes) {
				Counts[i++].Grapheme = grapheme;
			}
		}

		/// <inheritdoc/>
		public override nint this[Glyph index] {
			get {
				foreach ((TGrapheme Grapheme, nint Count) in Counts) {
					if (Grapheme.Equals(index)) {
						return Count;
					}
				}
				return 0;
			}
		}

		/// <inheritdoc/>
		[SuppressMessage("Critical Code Smell", "S3217:\"Explicit\" conversions of \"foreach\" loops should not be used", Justification = "Sonar doesn't understand what's going on... again.")]
		public override nint Count {
			get {
				nint count = 0;
				foreach ((TGrapheme Grapheme, nint Count) in Counts) {
					count += Count;
				}
				return count;
			}
		}

		/// <inheritdoc/>
		public override void Add(ReadOnlySpan<Char> element) {
			foreach (Glyph glyph in element.EnumerateGlyphs()) {
				Add(glyph);
			}
		}

		/// <inheritdoc/>
		public override unsafe void Add(Char* element, Int32 length) => Add(new ReadOnlySpan<Char>(element, length));

		/// <inheritdoc/>
		public override void Add(Char element) {
			for (Int32 i = 0; i < Counts.Length; i++) {
				if (Counts[i].Grapheme.Equals(element)) {
					Counts[i].Count++;
					return;
				}
			}
		}

		/// <inheritdoc/>
		public override void Add(Rune element) {
			for (Int32 i = 0; i < Counts.Length; i++) {
				if (Counts[i].Grapheme.Equals(element)) {
					Counts[i].Count++;
					return;
				}
			}
		}

		/// <inheritdoc/>
		public override void Add(Glyph element) {
			for (nint i = 0; i < Counts.Length; i++) {
				if (Counts[i].Grapheme.Equals(element)) {
					Counts[i].Count++;
					return;
				}
			}
		}

		/// <inheritdoc/>
		public override void Add(String element) => Add(element.AsSpan());

		/// <inheritdoc/>
		public override void Add(Char[] element) => Add(element.AsSpan());

		/// <inheritdoc/>
		public override void Add(ReadOnlyMemory<Char> element) => Add(element.Span);

		/// <inheritdoc/>
		public override void Add(IEnumerable<Char> element) {
			foreach (Glyph glyph in element.EnumerateGlyphs()) {
				Add(glyph);
			}
		}
	}
}
