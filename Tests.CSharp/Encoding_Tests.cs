using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;
using Xunit;

namespace Langly {
	public class Encoding_Tests {
		private readonly Generator Generator = new Generator();

		[Theory]
		[InlineData(0x0, 0x0)]
		[InlineData(0x41, 0x41)]
		[InlineData(0x7F, 0x7F)]
		[InlineData(0x80, 0xFFFD)]
		[InlineData(0xFF, 0xFFFD)]
		public void UTF8_Decode_1(Byte first, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first).Value);

		[Theory]
		[InlineData(0xC3, 0x86, 0xC6)]
		[InlineData(0xCE, 0xB2, 0x03B2)]
		public void UTF8_Decode_2(Byte first, Byte second, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first, second).Value);

		[Theory]
		[InlineData(0xE0, 0xAE, 0x87, 0x0B87)]
		[InlineData(0xE1, 0x82, 0xA7, 0x10A7)]
		[InlineData(0xEA, 0x9C, 0xA8, 0xA728)]
		public void UTF8_Decode_3(Byte first, Byte second, Byte third, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first, second, third).Value);

		[Theory]
		[InlineData(0xF0, 0x90, 0x8C, 0xB1, 0x010331)]
		[InlineData(0xF0, 0x9F, 0x82, 0xA1, 0x01F0A1)]
		public void UTF8_Decode_4(Byte first, Byte second, Byte third, Byte fourth, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first, second, third, fourth).Value);

		[Theory]
		[InlineData(new Byte[0], new Int32[0])]
		[InlineData(new Byte[] { 0x0 }, new Int32[] { 0x0 })]
		[InlineData(new Byte[] { 0x41, 0x7F }, new Int32[] { 0x41, 0x7F })]
		[InlineData(new Byte[] { 0x41, 0xC3, 0x86 }, new Int32[] { 0x41, 0xC6 })]
		[InlineData(new Byte[] { 0xC3, 0x86, 0x41 }, new Int32[] { 0xC6, 0x41 })]
		[InlineData(new Byte[] { 0xE0, 0xAE, 0x87 }, new Int32[] { 0x0B87 })]
		[InlineData(new Byte[] { 0xE0, 0xAE, 0xE0 }, new Int32[] { 0xFFFD })]
		public void UTF8_Decode_Buffer(Byte[] buffer, Int32[] expected) {
			Rune[] text = new Rune[expected.Length];
			for (Int32 i = 0; i < text.Length; i++) {
				text[i] = new Rune(expected[i]);
			}
			Assert.Equal(text, UTF8.Decode(buffer).ToArray());
		}

		[Fact]
		public void UTF8_Decode_Gibberish() => UTF8.Decode(Generator.Byte(5_000).ToArray());

		[Theory]
		[InlineData(0x000041, new Byte[] { 0x41 })]
		[InlineData(0x0000C6, new Byte[] { 0xC3, 0x86 })]
		[InlineData(0x000B87, new Byte[] { 0xE0, 0xAE, 0x87 })]
		[InlineData(0x00A728, new Byte[] { 0xEA, 0x9C, 0xA8 })]
		[InlineData(0x010331, new Byte[] { 0xF0, 0x90, 0x8C, 0xB1 })]
		[InlineData(0x01F0A1, new Byte[] { 0xF0, 0x9F, 0x82, 0xA1 })]
		public void UTF8_Encode(UInt32 scalarValue, Byte[] expected) {
			Assert.Equal(expected, UTF8.Encode(new Rune(scalarValue)).ToArray());
		}

		[Fact]
		public void UTF8_Encode_Gibberish() => UTF8.Encode(Generator.Rune(5_000).ToArray());

		[Theory]
		[InlineData(0x00, true)]
		[InlineData(0x01, true)]
		[InlineData(0x7E, true)]
		[InlineData(0x7F, true)]
		[InlineData(0x80, false)]
		[InlineData(0x81, false)]
		[InlineData(0xC0, false)]
		[InlineData(0xC1, false)]
		[InlineData(0xC2, true)]
		[InlineData(0xF4, true)]
		[InlineData(0xF5, false)]
		[InlineData(0xF6, false)]
		[InlineData(0xFF, false)]
		public void UTF8_IsFirstUnit(Byte @byte, Boolean expected) => Assert.Equal(expected, UTF8.IsFirstUnit(@byte));

		[Theory]
		[InlineData(0x7F, 0x80, 0xBF)]
		[InlineData(0xDF, 0x80, 0xBF)]
		[InlineData(0xE0, 0xA0, 0xBF)]
		[InlineData(0xE1, 0x80, 0xBF)]
		[InlineData(0xEE, 0x80, 0xBF)]
		[InlineData(0xED, 0x80, 0x9F)]
		[InlineData(0xEF, 0x80, 0xBF)]
		[InlineData(0xF0, 0x90, 0xBF)]
		[InlineData(0xF1, 0x80, 0xBF)]
		[InlineData(0xF3, 0x80, 0xBF)]
		[InlineData(0xF4, 0x80, 0x8F)]
		[InlineData(0xF5, 0x80, 0xBF)]
		[InlineData(0xFF, 0x80, 0xBF)]
		public void UTF8_NextUnitRange(Byte @byte, Byte lowerExp, Byte upperExp) {
			UTF8.NextUnitRange(@byte, out Byte lower, out Byte upper);
			Assert.Equal(lowerExp, lower);
			Assert.Equal(upperExp, upper);
		}

		[Theory]
		[InlineData(0x00, 1)]
		[InlineData(0x7F, 1)]
		[InlineData(0x80, 0)]
		[InlineData(0xC1, 0)]
		[InlineData(0xC2, 2)]
		[InlineData(0xDF, 2)]
		[InlineData(0xE0, 3)]
		[InlineData(0xE1, 3)]
		[InlineData(0xEE, 3)]
		[InlineData(0xEF, 3)]
		[InlineData(0xF0, 4)]
		[InlineData(0xF1, 4)]
		[InlineData(0xF3, 4)]
		[InlineData(0xF4, 4)]
		[InlineData(0xF5, 0)]
		[InlineData(0xF6, 0)]
		[InlineData(0xFF, 0)]
		public void UTF8_SequenceLength(Byte @byte, Int32 expected) => Assert.Equal(expected, UTF8.SequenceLength(@byte));

		[Theory]
		[InlineData(0x0000, 0x000000)]
		[InlineData(0x0041, 0x000041)]
		[InlineData(0x007F, 0x00007F)]
		[InlineData(0x0080, 0x000080)]
		[InlineData(0x00FF, 0x0000FF)]
		public void UTF16_Decode_1(UInt16 first, Int32 expected) => Assert.Equal(expected, UTF16.Decode(first).Value);

		[Theory]
		[InlineData(0xD834, 0xDD1E, 0x01D11E)]
		[InlineData(0xD834, 0xDD3D, 0x01D13D)]
		public void UTF16_Decode_2(UInt16 first, UInt16 second, Int32 expected) => Assert.Equal(expected, UTF16.Decode(first, second).Value);

		[Fact]
		public void UTF16_Decode_Gibberish() => UTF16.Decode(Generator.Char(5_000).ToArray());

		[Theory]
		[InlineData(0x01D11E, new Char[] { '\uD834', '\uDD1E' })]
		[InlineData(0x01D13D, new Char[] { '\uD834', '\uDD3D' })]
		public void UTF16_Encode(UInt32 scalarValue, Char[] expected) {
			Assert.Equal(expected, UTF16.Encode(new Rune(scalarValue)).ToArray());
		}

		[Fact]
		public void UTF16_Encode_Gibberish() => UTF16.Encode(Generator.Rune(5_000).ToArray());

		[Theory]
		[InlineData(0x0000, true)]
		[InlineData(0xD7FF, true)]
		[InlineData(0xD800, true)]
		[InlineData(0xD801, true)]
		[InlineData(0xDBFE, true)]
		[InlineData(0xDBFF, true)]
		[InlineData(0xDC00, false)]
		[InlineData(0xDC01, false)]
		[InlineData(0xDFFE, false)]
		[InlineData(0xDFFF, false)]
		[InlineData(0xE000, true)]
		[InlineData(0xE001, true)]
		[InlineData(0xFFFF, true)]
		public void UTF16_IsFirstUnit(UInt16 unit, Boolean expected) => Assert.Equal(expected, UTF16.IsFirstUnit(unit));

		[Theory]
		[InlineData(0x0000, 0x0000, 0xFFFF)]
		[InlineData(0xD7FF, 0x0000, 0xFFFF)]
		[InlineData(0xD800, 0xDC00, 0xDFFF)]
		[InlineData(0xD801, 0xDC00, 0xDFFF)]
		[InlineData(0xDBFE, 0xDC00, 0xDFFF)]
		[InlineData(0xDBFF, 0xDC00, 0xDFFF)]
		[InlineData(0xDC00, 0x0000, 0xFFFF)]
		[InlineData(0xDC01, 0x0000, 0xFFFF)]
		[InlineData(0xDFFE, 0x0000, 0xFFFF)]
		[InlineData(0xDFFF, 0x0000, 0xFFFF)]
		[InlineData(0xE000, 0x0000, 0xFFFF)]
		[InlineData(0xE001, 0x0000, 0xFFFF)]
		[InlineData(0xFFFF, 0x0000, 0xFFFF)]
		public void UTF16_NextUnitRange(UInt16 unit, UInt16 lowerExp, UInt16 upperExp) {
			UTF16.NextUnitRange(unit, out UInt16 lower, out UInt16 upper);
			Assert.Equal(lowerExp, lower);
			Assert.Equal(upperExp, upper);
		}

		[Theory]
		[InlineData(0x0000, 1)]
		[InlineData(0xD7FF, 1)]
		[InlineData(0xD800, 2)]
		[InlineData(0xD801, 2)]
		[InlineData(0xDBFE, 2)]
		[InlineData(0xDBFF, 2)]
		[InlineData(0xDC00, 0)]
		[InlineData(0xDC01, 0)]
		[InlineData(0xDFFE, 0)]
		[InlineData(0xDFFF, 0)]
		[InlineData(0xE000, 1)]
		[InlineData(0xE001, 1)]
		[InlineData(0xFFFF, 1)]
		public void UTF16_SequenceLength(UInt16 unit, Int32 expected) => Assert.Equal(expected, UTF16.SequenceLength(unit));
	}
}
