using System;
using System.Collections.Generic;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class CodePointTests : Trial {
		[Fact]
		public void Constructor_Int32_Valid() {
			for (Int32 i = 0; i <= 0x10FFFF; i++) {
				new CodePoint(i);
			}
		}

		[Theory]
		[InlineData(-0x01)]
		[InlineData(0x110000)]
		public void Constructor_Int32_Invalid(Int32 value) => Claim.That(() => new CodePoint(value)).Throws<ArgumentOutOfRangeException>();

		[Fact]
		public void Constructor_UInt32_Valid() {
			for (UInt32 i = 0; i <= 0x10FFFF; i++) {
				new CodePoint(i);
			}
		}

		[Theory]
		[InlineData(0x110000)]
		public void Constructor_UInt32_Invalid(UInt32 value) => Claim.That(() => new CodePoint(value)).Throws<ArgumentOutOfRangeException>();

		[Theory]
		[InlineData(0x00, 1)]
		[InlineData(0x41, 1)]
		[InlineData(0x7E, 1)]
		[InlineData(0x7F, 1)]
		[InlineData(0x80, 1)]
		[InlineData(0x0416, 1)]
		[InlineData(0x8080, 1)]
		[InlineData(0x010281, 2)]
		public void UTF16SequenceLength(UInt32 value, Int32 expected) => Claim.That(new CodePoint(value).Utf16SequenceLength).Equals(expected);

		[Theory]
		[InlineData(0x00, 1)]
		[InlineData(0x41, 1)]
		[InlineData(0x7E, 1)]
		[InlineData(0x7F, 1)]
		[InlineData(0x80, 2)]
		[InlineData(0x0416, 2)]
		[InlineData(0x8080, 3)]
		[InlineData(0x010281, 4)]
		public void UTF8SequenceLength(UInt32 value, Int32 expected) => Claim.That(new CodePoint(value).Utf8SequenceLength).Equals(expected);

		[Theory]
		[InlineData(0x00, "U+00")]
		[InlineData(0x41, "U+41")]
		[InlineData(0x7E, "U+7E")]
		[InlineData(0x7F, "U+7F")]
		[InlineData(0x80, "U+80")]
		[InlineData(0x0416, "U+0416")]
		[InlineData(0x8080, "U+8080")]
		[InlineData(0x010281, "U+010281")]
		public void CodePoint_ToString(UInt32 value, String expected) => Claim.That(new CodePoint(value).ToString()).Equals(expected);

		[Theory]
		[InlineData(0xD7FF, false)]
		[InlineData(0xD800, true)]
		[InlineData(0xD801, true)]
		[InlineData(0xDBFF, true)]
		[InlineData(0xDC00, false)]
		public void IsHighSurrogate(UInt32 value, Boolean expected) => Claim.That(new CodePoint(value).IsHighSurrogate).Equals(expected);

		[Theory]
		[InlineData(0xDBFF, false)]
		[InlineData(0xDC00, true)]
		[InlineData(0xDC01, true)]
		[InlineData(0xDFFF, true)]
		[InlineData(0xE000, false)]
		public void IsLowSurrogate(UInt32 value, Boolean expected) => Claim.That(new CodePoint(value).IsLowSurrogate).Equals(expected);

		[Theory]
		[InlineData(0x41, true)]
		[InlineData(0xDE, true)]
		[InlineData(0xF6, true)]
		[InlineData(0x39E, true)]
		[InlineData(0xFFFD, true)]
		[InlineData(0x2125, true)]
		[InlineData(0x2383, true)]
		[InlineData(0xD7FF, true)]
		[InlineData(0xD800, false)]
		[InlineData(0xD801, false)]
		[InlineData(0xDBFF, false)]
		[InlineData(0xDC00, false)]
		[InlineData(0xDC01, false)]
		[InlineData(0xDFFF, false)]
		[InlineData(0xE000, true)]
		[InlineData(0x1D11E, true)]
		public void IsScalarValue(UInt32 value, Boolean expected) => Claim.That(new CodePoint(value).IsScalarValue).Equals(expected);
	}
}
