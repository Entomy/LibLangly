using Collectathon.Sets;
using Philosoft;
using Defender;
using Stringier.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stringier.Linguistics {
	/// <summary>
	/// Represents an orthography, the overall collection of rules and systems that make up writing.
	/// </summary>
	public abstract class Orthography : Category {
		/// <summary>
		/// Azerbaijani alphabet (Latin script).
		/// </summary>
		internal static readonly Orthography Azeribaijani_Latin = new CasedOrthography(Part.Numbers_Latin, new ComplexPart(32, (x) => Check.Within(x, 0x41, 0x56) || Check.Within(x, 0x58, 0x5A) || Check.Within(x, 0x61, 0x76) || Check.Within(x, 0x78, 0x7A) || x == 'Ç' || x == 'ç' || x == 'Ə' || x == 'ə' || x == 'Ğ' || x == 'ğ' || x == 'ı' || x == 'İ' || x == 'Ö' || x == 'ö' || x == 'Ş' || x == 'ş' || x == 'Ü' || x == 'ü'), new Map('a', 'A'), new Map('b', 'B'), new Map('c', 'C'), new Map('ç', 'Ç'), new Map('d', 'D'), new Map('e', 'E'), new Map('ə', 'Ə'), new Map('f', 'F'), new Map('g', 'G'), new Map('ğ', 'Ğ'), new Map('h', 'H'), new Map('x', 'X'), new Map('ı', 'I'), new Map('i', 'İ'), new Map('j', 'J'), new Map('k', 'K'), new Map('q', 'Q'), new Map('l', 'L'), new Map('m', 'M'), new Map('n', 'N'), new Map('o', 'O'), new Map('ö', 'Ö'), new Map('p', 'P'), new Map('r', 'R'), new Map('s', 'S'), new Map('ş', 'Ş'), new Map('t', 'T'), new Map('u', 'U'), new Map('ü', 'Ü'), new Map('v', 'V'), new Map('y', 'Y'), new Map('z', 'Z'));

		/// <summary>
		/// English alphabet (Deseret script).
		/// </summary>
		internal static readonly Orthography English_Deseret = new CasedOrthography(Part.Numbers_Latin, new SimplePart(0x010400, 0x01044F), new Map(0x010428, 0x010400), new Map(0x010429, 0x010401), new Map(0x01042A, 0x010402), new Map(0x01042B, 0x010403), new Map(0x01042C, 0x010404), new Map(0x01042D, 0x010405), new Map(0x01042E, 0x010406), new Map(0x01042F, 0x010407), new Map(0x010430, 0x010408), new Map(0x010431, 0x010409), new Map(0x010432, 0x01040A), new Map(0x010433, 0x01040B), new Map(0x010434, 0x01040C), new Map(0x010435, 0x01040D), new Map(0x010436, 0x01040E), new Map(0x010437, 0x01040F), new Map(0x010438, 0x010410), new Map(0x010439, 0x010411), new Map(0x01043A, 0x010412), new Map(0x01043B, 0x010413), new Map(0x01043C, 0x010414), new Map(0x01043D, 0x010415), new Map(0x01043E, 0x010416), new Map(0x01043F, 0x010417), new Map(0x010440, 0x010418), new Map(0x010441, 0x010419), new Map(0x010442, 0x01041A), new Map(0x010443, 0x01041B), new Map(0x010444, 0x01041C), new Map(0x010445, 0x01041D), new Map(0x010446, 0x01041E), new Map(0x010447, 0x01041F), new Map(0x010448, 0x010420), new Map(0x010449, 0x010421), new Map(0x01044A, 0x010422), new Map(0x01044B, 0x010423), new Map(0x01044C, 0x010424), new Map(0x01044D, 0x010425), new Map(0x01044E, 0x010426), new Map(0x01044F, 0x010427));

		/// <summary>
		/// English alphabet (Latin script).
		/// </summary>
		internal static readonly Orthography English_Latin = new CasedOrthography(Part.Numbers_Latin, Part.Basic_Latin, new Map('a', 'A'), new Map('b', 'B'), new Map('c', 'C'), new Map('d', 'D'), new Map('e', 'E'), new Map('f', 'F'), new Map('g', 'G'), new Map('h', 'H'), new Map('i', 'I'), new Map('j', 'J'), new Map('k', 'K'), new Map('l', 'L'), new Map('m', 'M'), new Map('n', 'N'), new Map('o', 'O'), new Map('p', 'P'), new Map('q', 'Q'), new Map('r', 'R'), new Map('s', 'S'), new Map('t', 'T'), new Map('u', 'U'), new Map('v', 'V'), new Map('w', 'W'), new Map('x', 'X'), new Map('y', 'Y'), new Map('z', 'Z'));

		/// <summary>
		/// English alphabet (Shavian script).
		/// </summary>
		internal static readonly Orthography English_Shavian = new UncasedOrthography(Part.Numbers_Latin, new SimplePart(0x010450, 0x01047F), 0x010450, 0x010451, 0x010452, 0x010453, 0x010454, 0x010455, 0x010456, 0x010457, 0x010458, 0x010459, 0x01045A, 0x01045B, 0x01045C, 0x01045D, 0x01045E, 0x01045F, 0x010460, 0x010461, 0x010462, 0x010463, 0x010464, 0x010465, 0x010466, 0x010467, 0x010468, 0x010469, 0x01046A, 0x01046B, 0x01046C, 0x01046D, 0x01046E, 0x01046F, 0x010470, 0x010471, 0x010472, 0x010473, 0x010474, 0x010475, 0x010476, 0x010477, 0x010478, 0x010479, 0x01047A, 0x01047B, 0x01047C, 0x01047D, 0x01047E, 0x01047F);

		/// <summary>
		/// Turkish alphabet (Latin script).
		/// </summary>
		internal static readonly Orthography Turkish_Latin = new CasedOrthography(Part.Numbers_Latin, new ComplexPart(29, (x) => Check.Within(x, 0x41, 0x50) || Check.Within(x, 0x52, 0x56) || Check.Within(x, 0x59, 0x5A) || Check.Within(x, 0x61, 0x70) || Check.Within(x, 0x72, 0x76) || Check.Within(x, 0x79, 0x7A) || x == 'Ç' || x == 'ç' || x == 'Ğ' || x == 'ğ' || x == 'Ö' || x == 'ö' || x == 'Ş' || x == 'ş' || x == 'Ü' || x == 'ü'), new Map('a', 'A'), new Map('b', 'B'), new Map('c', 'C'), new Map('ç', 'Ç'), new Map('d', 'D'), new Map('e', 'E'), new Map('f', 'F'), new Map('g', 'G'), new Map('ğ', 'Ğ'), new Map('h', 'X'), new Map('ı', 'I'), new Map('i', 'İ'), new Map('j', 'J'), new Map('k', 'K'), new Map('l', 'L'), new Map('m', 'M'), new Map('n', 'N'), new Map('o', 'O'), new Map('ö', 'Ö'), new Map('p', 'P'), new Map('r', 'R'), new Map('s', 'S'), new Map('ş', 'Ş'), new Map('t', 'T'), new Map('u', 'U'), new Map('ü', 'Ü'), new Map('v', 'V'), new Map('y', 'Y'), new Map('z', 'Z'));

		/// <summary>
		/// The set of characters in this orthography.
		/// </summary>
		protected readonly Part Characters;

		/// <summary>
		/// The set of numbers in this orthography.
		/// </summary>
		protected readonly Part Numbers;

		protected Orthography(Part numbers, Part characters) {
			Numbers = numbers;
			Characters = characters;
		}

		/// <summary>
		/// Gets a <see cref="Counter"/> for this <see cref="Orthography"/>.
		/// </summary>
		/// <returns>A <see cref="Counter"/>.</returns>
		internal protected abstract Counter GetCounter();

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its lowercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		internal protected abstract Char ToLower(Char @char);

		/// <summary>
		/// Converts the value of a UNICODE character to its lowercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		internal protected abstract Rune ToLower(Rune rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its lowercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The lowercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already lowercase, has no lowercase equivalent, or is not alphabetic.</returns>
		internal protected abstract Glyph ToLower(Glyph glyph);

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its titlecase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		internal protected abstract Char ToTitle(Char @char);

		/// <summary>
		/// Converts the value of a UNICODE character to its titlecase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		internal protected abstract Rune ToTitle(Rune rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its titlecase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The titlecase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already titlecase, has no titlecase equivalent, or is not alphabetic.</returns>
		internal protected abstract Glyph ToTitle(Glyph glyph);

		/// <summary>
		/// Converts the value of a UTF-16 code unit to its uppercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="char">The UTF-16 code unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="char"/>, or the unchanged value of <paramref name="char"/> if <paramref name="char"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		internal protected abstract Char ToUpper(Char @char);

		/// <summary>
		/// Converts the value of a UNICODE character to its uppercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="rune">The UNICODE character unit to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="rune"/>, or the unchanged value of <paramref name="rune"/> if <paramref name="rune"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		internal protected abstract Rune ToUpper(Rune rune);

		/// <summary>
		/// Converts the value of a UNICODE grapheme cluster to its uppercase equivalent, according to the rules of this <see cref="UncasedOrthography"/>.
		/// </summary>
		/// <param name="glyph">The UNICODE grapheme cluster to convert.</param>
		/// <returns>The uppercase equivalent of <paramref name="glyph"/>, or the unchanged value of <paramref name="glyph"/> if <paramref name="glyph"/> is already uppercase, has no uppercase equivalent, or is not alphabetic.</returns>
		internal protected abstract Glyph ToUpper(Glyph glyph);

		/// <inheritdoc/>
		protected sealed override Boolean Contains(Char element) => Characters.Contains(element) || Numbers.Contains(element);

		/// <inheritdoc/>
		protected sealed override Boolean Contains(Rune element) => element.Value >= 0 && (Characters.Contains(element) || Numbers.Contains(element));

		/// <inheritdoc/>
		protected sealed override Boolean Contains(Glyph element) => Characters.Contains(element) || Numbers.Contains(element);
		/// <summary>
		/// Provides a counter for glyphs of an orthography.
		/// </summary>
		/// <remarks>
		/// This is used to count phoneme/syllable glyphs, not numeric, punctual, or otherwise.
		/// </remarks>
		[CLSCompliant(false)]
		internal protected abstract class Counter : IAddableText, ICountable {
			/// <inheritdoc/>
			public abstract nint Count { get; }

			/// <summary>
			/// For the specified <paramref name="grapheme"/>, looks up its count.
			/// </summary>
			/// <param name="grapheme">The grapheme to look up.</param>
			/// <returns>The amount of times the <paramref name="grapheme"/> has been counted.</returns>
			/// <remarks>
			/// This returns <c>0</c> for any <paramref name="grapheme"/> not part of the <see cref="UncasedOrthography"/>.
			/// </remarks>
			public abstract nint this[Glyph grapheme] { get; }

			/// <inheritdoc/>
			public abstract void Add(ReadOnlySpan<Char> element);

			/// <inheritdoc/>
			public abstract unsafe void Add(Char* element, Int32 length);

			/// <inheritdoc/>
			public abstract void Add(Char element);

			/// <inheritdoc/>
			public abstract void Add(Rune element);

			/// <inheritdoc/>
			public abstract void Add(Glyph element);

			/// <inheritdoc/>
			public abstract void Add(String element);

			/// <inheritdoc/>
			public abstract void Add(Char[] element);

			/// <inheritdoc/>
			public abstract void Add(ReadOnlyMemory<Char> element);

			/// <inheritdoc/>
			public abstract void Add(IEnumerable<Char> element);
		}

		internal protected abstract class Part : Set<Glyph>, IContainable<Char>, IContainable<Rune>, IContainable<Glyph> {
			public static readonly Part Basic_Latin = new SplitPart(0x41, 0x61, 26);

			public static readonly Part Numbers_Latin = new SimplePart(0x30, 0x39);

			/// <summary>
			/// Gets the number of elements contained in the collection.
			/// </summary>
			public abstract Int64 Count { get; }

			/// <inheritdoc/>
			Boolean IContainable<Rune>.Contains(Rune element) => Contains(element);

			/// <inheritdoc/>
			Boolean IContainable<Char>.Contains(Char element) => Contains(element);

			/// <inheritdoc/>
			protected abstract Boolean Contains(Char element);

			/// <inheritdoc/>
			protected abstract Boolean Contains(Rune element);

			/// <inheritdoc/>
			protected abstract override Boolean Contains(Glyph element);
		}
	}

	/// <summary>
	/// Represents an orthography, the overall collection of rules and systems that make up writing.
	/// </summary>
	/// <typeparam name="TGrapheme"></typeparam>
	internal abstract class Orthography<TGrapheme> : Orthography where TGrapheme : IEquatable<Char>, IEquatable<Rune>, IEquatable<Glyph>, IEquatable<TGrapheme> {
		/// <summary>
		/// The <typeparamref name="TGrapheme"/> that make up this <see cref="Orthography"/>.
		/// </summary>
		/// <remarks>
		/// This only refers to the graphemes used directly in writing. The "alphabet" or similar. It's used for all sorts of purposes including sorting rules and various literary functions. <see cref="Counter{TElement}"/> directly imports this.
		/// </remarks>
		protected readonly TGrapheme[] Graphemes;

		/// <inheritdoc/>
		protected Orthography(Part numbers, Part characters, params TGrapheme[] graphemes) : base(numbers, characters) => Graphemes = graphemes;

		/// <inheritdoc/>
		protected internal sealed override Counter GetCounter() => new Counter<TGrapheme>(Graphemes);
	}
}
