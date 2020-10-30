using Generators;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Stringier.Encodings {
	public class UTF8Tests {
		[Theory]
		[InlineData(0x0, 0x0)]
		[InlineData(0x41, 0x41)]
		[InlineData(0x7F, 0x7F)]
		[InlineData(0x80, 0xFFFD)]
		[InlineData(0xFF, 0xFFFD)]
		public void Decode_1(Byte first, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first).Value);

		[Theory]
		[InlineData(0xC3, 0x86, 0xC6)]
		[InlineData(0xCE, 0xB2, 0x03B2)]
		public void Decode_2(Byte first, Byte second, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first, second).Value);

		[Theory]
		[InlineData(0xE0, 0xAE, 0x87, 0x0B87)]
		[InlineData(0xE1, 0x82, 0xA7, 0x10A7)]
		[InlineData(0xEA, 0x9C, 0xA8, 0xA728)]
		public void Decode_3(Byte first, Byte second, Byte third, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first, second, third).Value);

		[Theory]
		[InlineData(0xF0, 0x90, 0x8C, 0xB1, 0x010331)]
		[InlineData(0xF0, 0x9F, 0x82, 0xA1, 0x01F0A1)]
		public void Decode_4(Byte first, Byte second, Byte third, Byte fourth, Int32 expected) => Assert.Equal(expected, UTF8.Decode(first, second, third, fourth).Value);

		[Theory]
		[InlineData(new Byte[0], new Int32[0])]
		[InlineData(new Byte[] { 0x0 }, new Int32[] { 0x0 })]
		[InlineData(new Byte[] { 0x41, 0x7F }, new Int32[] { 0x41, 0x7F })]
		[InlineData(new Byte[] { 0x41, 0xC3, 0x86 }, new Int32[] { 0x41, 0xC6 })]
		[InlineData(new Byte[] { 0xC3, 0x86, 0x41 }, new Int32[] { 0xC6, 0x41 })]
		[InlineData(new Byte[] { 0xE0, 0xAE, 0x87 }, new Int32[] { 0x0B87 })]
		[InlineData(new Byte[] { 0xE0, 0xAE, 0xE0 }, new Int32[] { 0xFFFD })]
		public void Decode_Buffer(Byte[] buffer, Int32[] expected) {
			Rune[] text = new Rune[expected.Length];
			for (Int32 i = 0; i < text.Length; i++) {
				text[i] = new Rune(expected[i]);
			}
			Assert.Equal(text, UTF8.Decode(buffer).ToArray());
		}

		[Theory]
		[InlineData(128)]
		[InlineData(256)]
		[InlineData(512)]
		[InlineData(1024)]
		[InlineData(2048)]
		[InlineData(4096)]
		[SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "We're just trying to make sure this doesn't throw an exception, which would result in a failed test anyways.")]
		public void Decode_Gibberish(Int32 size) => UTF8.Decode(Gibberish.GenerateUTF8(size));

		[Theory]
		[InlineData(0x000041, new Byte[] { 0x41 })]
		[InlineData(0x0000C6, new Byte[] { 0xC3, 0x86 })]
		[InlineData(0x000B87, new Byte[] { 0xE0, 0xAE, 0x87 })]
		[InlineData(0x00A728, new Byte[] { 0xEA, 0x9C, 0xA8 })]
		[InlineData(0x010331, new Byte[] { 0xF0, 0x90, 0x8C, 0xB1 })]
		[InlineData(0x01F0A1, new Byte[] { 0xF0, 0x9F, 0x82, 0xA1 })]
		public void Encode(UInt32 scalarValue, Byte[] expected) {
			Assert.Equal(expected, UTF8.Encode(new Rune(scalarValue)).ToArray());
		}

		[Theory]
		[InlineData(128)]
		[InlineData(256)]
		[InlineData(512)]
		[InlineData(1024)]
		[InlineData(2048)]
		[InlineData(4096)]
		[SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "We're just trying to make sure this doesn't throw an exception, which would result in a failed test anyways.")]
		public void Encode_Gibberish(Int32 size) => UTF8.Encode(Gibberish.GenerateUTF32(size));

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
		public void IsFirstByte(Byte @byte, Boolean expected) => Assert.Equal(expected, UTF8.IsFirstByte(@byte));

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
			UTF8.NextByteRange(@byte, out Byte lower, out Byte upper);
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
		public void SequenceLength(Byte @byte, Int32 expected) => Assert.Equal(expected, UTF8.SequenceLength(@byte));
	}
}
