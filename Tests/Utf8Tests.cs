using System;
using Stringier.Encodings;
using Xunit;
using Defender;

namespace Tests {
	public class Utf8Tests : Trial {
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
		public void IsFirstByte(Byte @byte, Boolean expected) => Claim.That(Utf8.IsFirstByte(@byte)).Equals(expected);

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
		public void SequenceLength(Byte @byte, Int32 expected) => Claim.That(Utf8.SequenceLength(@byte)).Equals(expected);
	}
}
