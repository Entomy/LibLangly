using System;
using System.Text;
using Stringier.Encodings;
using Xunit;

namespace Tests {
	public class Utf8Tests {
		[Theory]
		[InlineData(0x00, 0x000000)]
		[InlineData(0x41, 0x000041)]
		[InlineData(0x7F, 0x00007F)]
		[InlineData(0x80, 0x00FFFD)]
		[InlineData(0xFF, 0x00FFFD)]
		public void Decode_1(Byte first, Int32 expected) => Assert.Equal(expected, Utf8.Decode(first).Value);

		[Theory]
		[InlineData(0xC3, 0x86, 0x0000C6)]
		[InlineData(0xCE, 0xB2, 0x0003B2)]
		public void Decode_2(Byte first, Byte second, Int32 expected) => Assert.Equal(expected, Utf8.Decode(first, second).Value);

		[Theory]
		[InlineData(0xE0, 0xAE, 0x87, 0x000B87)]
		[InlineData(0xE1, 0x82, 0xA7, 0x0010A7)]
		[InlineData(0xEA, 0x9C, 0xA8, 0x00A728)]
		public void Decode_3(Byte first, Byte second, Byte third, Int32 expected) => Assert.Equal(expected, Utf8.Decode(first, second, third).Value);

		[Theory]
		[InlineData(0xF0, 0x90, 0x8C, 0xB1, 0x010331)]
		[InlineData(0xF0, 0x9F, 0x82, 0xA1, 0x01F0A1)]
		public void Decode_4(Byte first, Byte second, Byte third, Byte fourth, Int32 expected) => Assert.Equal(expected, Utf8.Decode(first, second, third, fourth).Value);

		[Theory]
		[InlineData(new Byte[] { }, new Int32[] { })]
		[InlineData(new Byte[] { 0x00 }, new Int32[] { 0x000000 })]
		[InlineData(new Byte[] { 0x41, 0x7F }, new Int32[] { 0x000041, 0x00007F })]
		[InlineData(new Byte[] { 0x41, 0xC3, 0x86 }, new Int32[] { 0x000041, 0x0000C6 })]
		[InlineData(new Byte[] { 0xC3, 0x86, 0x41 }, new Int32[] { 0x0000C6, 0x000041 })]
		[InlineData(new Byte[] { 0xE0, 0xAE, 0x87 }, new Int32[] { 0x000B87 })]
		[InlineData(new Byte[] { 0xE0, 0xAE, 0xE0 }, new Int32[] { 0x00FFFD })]
		public void Decode_Buffer(Byte[] bytes, Int32[] expected) {
			Rune[] text = new Rune[expected.Length];
			for (Int32 i = 0; i < text.Length; i++) {
				text[i] = new Rune(expected[i]);
			}
			Assert.Equal(text, Utf8.Decode(bytes));
		}

		[Theory]
		[InlineData(0x000041, new Byte[] { 0x41 })]
		[InlineData(0x0000C6, new Byte[] { 0xC3, 0x86 })]
		[InlineData(0x000B87, new Byte[] { 0xE0, 0xAE, 0x87 })]
		[InlineData(0x00A728, new Byte[] { 0xEA, 0x9C, 0xA8 })]
		[InlineData(0x010331, new Byte[] { 0xF0, 0x90, 0x8C, 0xB1 })]
		[InlineData(0x01F0A1, new Byte[] { 0xF0, 0x9F, 0x82, 0xA1 })]
		public void Encode(UInt32 scalarValue, Byte[] expected) => Assert.Equal(expected, Utf8.Encode(new Rune(scalarValue)));

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
		public void IsFirstByte(Byte @byte, Boolean expected) => Assert.Equal(expected, Utf8.IsFirstByte(@byte));

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
		public void NextByteRange(Byte @byte, Byte lowerExp, Byte upperExp) {
			Utf8.NextByteRange(@byte, out Byte lower, out Byte upper);
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
		public void SequenceLength(Byte @byte, Int32 expected) => Assert.Equal(expected, Utf8.SequenceLength(@byte));
	}
}
