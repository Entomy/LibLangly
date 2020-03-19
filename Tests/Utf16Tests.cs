using System;
using Stringier.Encodings;
using Xunit;
using Defender;

namespace Tests {
	public class Utf16Tests : Trial {
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
		public void IsFirstUnit(UInt16 unit, Boolean expected) => Claim.That(Utf16.IsFirstUnit(unit)).Equals(expected);

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
		public void NextUnitRange(UInt16 unit, UInt16 lowerExp, UInt16 upperExp) {
			Utf16.NextUnitRange(unit, out UInt16 lower, out UInt16 upper);
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
		public void SequenceLength(UInt16 unit, Int32 expected) => Claim.That(Utf16.SequenceLength(unit)).Equals(expected);
	}
}
