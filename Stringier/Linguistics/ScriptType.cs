namespace Stringier.Linguistics {
	/// <summary>
	/// The type of the script, the system of the writing.
	/// </summary>
	public enum ScriptType {
		/// <summary>
		/// Abjad
		/// </summary>
		/// <remarks>
		/// Abjads are scripts where each glyph is represenative of a consonant. Vowels are either inferred, as in pure abjads, or through diacritics, similar to but still different from the <see cref="Abugida"/>.
		/// </remarks>
		Abjad,

		/// <summary>
		/// Abugida
		/// </summary>
		/// <remarks>
		/// Abugidas are scripts where each glyph is represenative of a consonant vowel pair similar to a <see cref="Syllabary"/>, but where each syllable has a default, base, grapheme, with diacritics used to differentiate vowels.
		/// </remarks>
		Abugida,

		/// <summary>
		/// Alphabet
		/// </summary>
		/// <remarks>
		/// Alphabets are scripts where each glyph is representative of individual phonemes, with different glyphs for consonants and vowels.
		/// </remarks>
		Alphabet,

		/// <summary>
		/// Syllabary
		/// </summary>
		/// <remarks>
		/// Syllabaries are scripts where each glyph is representative of consonant vowel pairs: syllables.
		/// </remarks>
		Syllabary,
	}
}