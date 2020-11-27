using System;
using Xunit;
using static Langly.Linguistics.Language;
using static Langly.Linguistics.Script;

namespace Langly {
	public class GlyphTests {
		[Theory]
		[InlineData("\u00E0", "\u00E0", 0)]
		[InlineData("\u00E0", "\u0061\u0300", 0)]
		[InlineData("\u0061\u0300", "\u00E0", 0)]
		[InlineData("\u0061\u0300", "\u0061\u0300", 0)]
		[InlineData("\u00C0", "\u00E0", -1)]
		[InlineData("\u00C0", "\u0061\u0300", -1)]
		[InlineData("\u0041\u0300", "\u00E0", -1)]
		[InlineData("\u0041\u0300", "\u0061\u0300", -1)]
		[InlineData("\u00E0", "\u00C0", +1)]
		[InlineData("\u00E0", "\u0041\u0300", +1)]
		[InlineData("\u0061\u0300", "\u00C0", +1)]
		[InlineData("\u0061\u0300", "\u0041\u0300", +1)]
		public void Compare(String first, String second, Int32 expected) {
			Glyph a = (Glyph)first;
			Glyph b = (Glyph)second;

			Assert.Equal(expected, Math.Sign(a.CompareTo(b)));
			Assert.Equal(expected < 0, a < b);
			Assert.Equal(expected <= 0, a <= b);
			Assert.Equal(expected > 0, a > b);
			Assert.Equal(expected >= 0, a >= b);
		}

		[Theory]
		[InlineData("\u00C0")]
		[InlineData("\u0041\u0300")] // À
		[InlineData("\u00C1")]
		[InlineData("\u0041\u0301")] // Á
		[InlineData("\u00C2")]
		[InlineData("\u0041\u0302")] // Â
		[InlineData("\u00C3")]
		[InlineData("\u0041\u0303")] // Ã
		[InlineData("\u00C4")]
		[InlineData("\u0041\u0308")] // Ä
		[InlineData("\u00C5")]
		[InlineData("\u0041\u030A")] // Å
		[InlineData("\uD834\uDD1E")] // 𝄞
		public void Cast(String sequence) => _ = (Glyph)sequence;

		[Theory]
		[InlineData("\u0061", 1)]
		[InlineData("\u00E1", 1)]
		[InlineData("\u0061\u0301", 1)]
		public void EncodeToUtf16(String sequence, Int32 length) {
			Glyph glyph = (Glyph)sequence;
			Span<Char> buffer = new Char[glyph.Utf16SequenceLength];
			Assert.Equal(length, glyph.EncodeToUtf16(buffer));
			Assert.True(String.Equals(sequence, buffer.ToString(), StringComparison.InvariantCulture));
		}

		[Theory]
		[InlineData("\u0061", 1, new Byte[] { 0x61 })]
		[InlineData("\u00E1", 2, new Byte[] { 0xc3, 0xa1 })]
		[InlineData("\u0061\u0301", 2, new Byte[] { 0xc3, 0xa1 })]
		public void EncodeToUtf8(String sequence, Int32 length, Byte[] expected) {
			Glyph glyph = (Glyph)sequence;
			Span<Byte> buffer = new Byte[glyph.Utf8SequenceLength];
			Assert.Equal(length, glyph.EncodeToUtf8(buffer));
			Assert.Equal(expected, buffer.ToArray());
		}

		[Theory]
		[InlineData("", new Char[] { })]
		[InlineData("hello", new Char[] { 'h', 'e', 'l', 'l', 'o' })]
		[InlineData("\u0061", new[] { 'a' })]
		[InlineData("\u0061\u00EB", new[] { 'a', 'ë' })]
		[InlineData("\u0061\u0065\u0308", new[] { 'a', 'ë' })]
		[InlineData("\u0061\u00E7\u00EB", new[] { 'a', 'ç', 'ë' })]
		[InlineData("\u0061\u00E7\u0065\u0308", new[] { 'a', 'ç', 'ë' })]
		[InlineData("\u0061\u0063\u0327\u00EB", new[] { 'a', 'ç', 'ë' })]
		[InlineData("\u0061\u0063\u0327\u0065\u0308", new[] { 'a', 'ç', 'ë' })]
		public void Enumerator_String(String source, Char[] expected) {
			Int32 i = 0;
			foreach (Glyph glyph in source.EnumerateGlyphs()) {
				Assert.Equal((Glyph)expected[i++], glyph);
			}
		}

		[Theory]
		[InlineData("\u00C0", "\u0041\u0300")] // À
		[InlineData("\u00C1", "\u0041\u0301")] // Á
		[InlineData("\u00C2", "\u0041\u0302")] // Â
		[InlineData("\u00C3", "\u0041\u0303")] // Ã
		[InlineData("\u00C4", "\u0041\u0308")] // Ä
		[InlineData("\u00C5", "\u0041\u030A")] // Å
		[InlineData("\u00C7", "\u0043\u0327")] // Ç
		[InlineData("\u00C8", "\u0045\u0300")] // È
		[InlineData("\u00C9", "\u0045\u0301")] // É
		[InlineData("\u00CA", "\u0045\u0302")] // Ê
		[InlineData("\u00CB", "\u0045\u0308")] // Ë
		[InlineData("\u00CC", "\u0049\u0300")] // Ì
		[InlineData("\u00CD", "\u0049\u0301")] // Í
		[InlineData("\u00CE", "\u0049\u0302")] // Î
		[InlineData("\u00CF", "\u0049\u0308")] // Ï
		[InlineData("\u00D1", "\u004E\u0303")] // Ñ
		[InlineData("\u00D2", "\u004F\u0300")] // Ò
		[InlineData("\u00D3", "\u004F\u0301")] // Ó
		[InlineData("\u00D4", "\u004F\u0302")] // Ô
		[InlineData("\u00D5", "\u004F\u0303")] // Õ
		[InlineData("\u00D6", "\u004F\u0308")] // Ö
		[InlineData("\u00D9", "\u0055\u0300")] // Ù
		[InlineData("\u00DA", "\u0055\u0301")] // Ú
		[InlineData("\u00DB", "\u0055\u0302")] // Û
		[InlineData("\u00DC", "\u0055\u0308")] // Ü
		[InlineData("\u00DD", "\u0059\u0301")] // Ý
		[InlineData("\u00E0", "\u0061\u0300")] // à
		[InlineData("\u00E1", "\u0061\u0301")] // á
		[InlineData("\u00E2", "\u0061\u0302")] // â
		[InlineData("\u00E3", "\u0061\u0303")] // ã
		[InlineData("\u00E4", "\u0061\u0308")] // ä
		[InlineData("\u00E5", "\u0061\u030A")] // å
		[InlineData("\u00E8", "\u0065\u0300")] // è
		[InlineData("\u00E9", "\u0065\u0301")] // é
		[InlineData("\u00EA", "\u0065\u0302")] // ê
		[InlineData("\u00EB", "\u0065\u0308")] // ë
		[InlineData("\u00EC", "\u0069\u0300")] // ì
		[InlineData("\u00ED", "\u0069\u0301")] // í
		[InlineData("\u00EE", "\u0069\u0302")] // î
		[InlineData("\u00EF", "\u0069\u0308")] // ï
		[InlineData("\u00F1", "\u006E\u0303")] // ñ
		[InlineData("\u00F2", "\u006F\u0300")] // ò
		[InlineData("\u00F3", "\u006F\u0301")] // ó
		[InlineData("\u00F4", "\u006F\u0302")] // ô
		[InlineData("\u00F5", "\u006F\u0303")] // õ
		[InlineData("\u00F6", "\u006F\u0308")] // ö
		[InlineData("\u00F9", "\u0075\u0300")] // ù
		[InlineData("\u00FA", "\u0075\u0301")] // ú
		[InlineData("\u00FB", "\u0075\u0302")] // û
		[InlineData("\u00FC", "\u0075\u0308")] // ü
		[InlineData("\u00FD", "\u0079\u0301")] // ý
		[InlineData("\u00FF", "\u0079\u0308")] // ÿ
		public void Equals_Glyph(String first, String second) {
			Assert.Equal((Glyph)first, (Glyph)second);
			Assert.Equal((Glyph)second, (Glyph)first);
		}

		[Theory]
		[InlineData("\u0061\u0061", 0, "a", 1)]
		[InlineData("\u0061\u0061", 1, "a", 2)]
		[InlineData("\u0061\u0062", 0, "a", 1)]
		[InlineData("\u0061\u0062", 1, "b", 2)]
		[InlineData("\u00E1\u0062", 0, "á", 1)]
		[InlineData("\u00E1\u0062", 1, "b", 2)]
		[InlineData("\u0061\u0301\u0062", 0, "á", 2)]
		[InlineData("\u0061\u0301\u0062", 2, "b", 3)]
		[InlineData("\u0061\u00E7", 0, "a", 1)]
		[InlineData("\u0061\u00E7", 1, "ç", 2)]
		[InlineData("\u0061\u0063\u0327", 0, "a", 1)]
		[InlineData("\u0061\u0063\u0327", 1, "ç", 3)]
		[InlineData("\uD834\uDD1E", 0, "𝄞", 2)]
		[InlineData("\uD834\uDD1E\u0061", 2, "a", 3)]
		[InlineData("\u0061\uD834\uDD1E", 0, "a", 1)]
		[InlineData("\u0061\uD834\uDD1E", 1, "𝄞", 3)]
		public void GetGlyphAt(String input, Int32 index, String seq, Int32 nxt) {
			Glyph actual = input.GetGlyphAt(index, out Int32 next);
			Glyph expected = (Glyph)seq;
			Assert.Equal(expected, actual);
			Assert.Equal(nxt, next);
		}

		[Theory]
		[InlineData("", "")]
		[InlineData("\u0061", "\u0061")]
		[InlineData("\u0061\u0061", "\u0061\u0061")]
		[InlineData("\u0061\u0301\u0061", "\u0061\u0061\u0301")]
		[InlineData("\u0065\u0301\u0066\u0061\u0063", "\u0063\u0061\u0066\u0065\u0301")]
		public void Reverse(String source, String expected) => Assert.True(String.Equals(expected, Glyph.Reverse(source), StringComparison.InvariantCulture));

		[Theory]
		[InlineData("\u00E0", "\u00E0")] // à >=> à
		[InlineData("\u00C0", "\u00E0")] // À >=> à
		[InlineData("\u00C0", "\u0061\u0300")] // À >=> à
		[InlineData("\u0041\u0300", "\u00E0")] // À >=> à
		[InlineData("\u0041\u0300", "\u0061\u0300")] // À >=> à
		[InlineData("\u0049", "\u0131")] // I >=> ı
		public void ToLower_azAZ(String sequence, String expected) => Assert.Equal((Glyph)expected, ((Glyph)sequence).ToLower(Azerbaijani[Latin]));

		[Theory]
		[InlineData("\u00E0", "\u00E0")] // à >=> à
		[InlineData("\u00C0", "\u00E0")] // À >=> à
		[InlineData("\u00C0", "\u0061\u0300")] // À >=> à
		[InlineData("\u0041\u0300", "\u00E0")] // À >=> à
		[InlineData("\u0041\u0300", "\u0061\u0300")] // À >=> à
		[InlineData("\u0049", "\u0069")] // I >=> i
		public void ToLower_Invariant(String sequence, String expected) => Assert.Equal((Glyph)expected, ((Glyph)sequence).ToLower());

		[Theory]
		[InlineData("\u00E0", "\u00E0")] // à >=> à
		[InlineData("\u00C0", "\u00E0")] // À >=> à
		[InlineData("\u00C0", "\u0061\u0300")] // À >=> à
		[InlineData("\u0041\u0300", "\u00E0")] // À >=> à
		[InlineData("\u0041\u0300", "\u0061\u0300")] // À >=> à
		[InlineData("\u0049", "\u0131")] // I >=> ı
		public void ToLower_trTR(String sequence, String expected) => Assert.Equal((Glyph)expected, ((Glyph)sequence).ToLower(Turkish[Latin]));

		[Theory]
		[InlineData("\u00C0", "\u00C0")] // À >=> À
		[InlineData("\u00E0", "\u00C0")] // à >=> À
		[InlineData("\u0061\u0300", "\u00C0")] // à >=> À
		[InlineData("\u00E0", "\u0041\u0300")] // à >=> À
		[InlineData("\u0061\u0300", "\u0041\u0300")] // à >=> À
		[InlineData("\u0069", "\u0130")] // i >=> İ
		public void ToUpper_azAZ(String sequence, String expected) => Assert.Equal((Glyph)expected, ((Glyph)sequence).ToUpper(Azerbaijani[Latin]));

		[Theory]
		[InlineData("\u00C0", "\u00C0")] // À >=> À
		[InlineData("\u00E0", "\u00C0")] // à >=> À
		[InlineData("\u0061\u0300", "\u00C0")] // à >=> À
		[InlineData("\u00E0", "\u0041\u0300")] // à >=> À
		[InlineData("\u0061\u0300", "\u0041\u0300")] // à >=> À
		[InlineData("\u0069", "\u0049")] // i >=> I
		public void ToUpper_Invariant(String sequence, String expected) {
			Glyph exp = (Glyph)expected;
			Glyph seq = (Glyph)sequence;
			Glyph act = seq.ToUpper();
			Assert.Equal(exp, act);
		}

		[Theory]
		[InlineData("\u00C0", "\u00C0")] // À >=> À
		[InlineData("\u00E0", "\u00C0")] // à >=> À
		[InlineData("\u0061\u0300", "\u00C0")] // à >=> À
		[InlineData("\u00E0", "\u0041\u0300")] // à >=> À
		[InlineData("\u0061\u0300", "\u0041\u0300")] // à >=> À
		[InlineData("\u0069", "\u0130")] // i >=> İ
		public void ToUpper_trTR(String sequence, String expected) => Assert.Equal((Glyph)expected, ((Glyph)sequence).ToUpper(Turkish[Latin]));

	}
}
