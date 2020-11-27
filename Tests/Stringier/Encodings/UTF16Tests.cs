using Generators;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Langly {
	public class UTF16Tests {
		[Theory]
		[InlineData(0x0000, 0x000000)]
		[InlineData(0x0041, 0x000041)]
		[InlineData(0x007F, 0x00007F)]
		[InlineData(0x0080, 0x000080)]
		[InlineData(0x00FF, 0x0000FF)]
		public void Decode_1(UInt16 first, Int32 expected) => Assert.Equal(expected, UTF16.Decode(first).Value);

		[Theory]
		[InlineData(0xD834, 0xDD1E, 0x01D11E)]
		[InlineData(0xD834, 0xDD3D, 0x01D13D)]
		public void Decode_2(UInt16 first, UInt16 second, Int32 expected) => Assert.Equal(expected, UTF16.Decode(first, second).Value);

		[Theory]
		[InlineData(128)]
		[InlineData(256)]
		[InlineData(512)]
		[InlineData(1024)]
		[InlineData(2048)]
		[InlineData(4096)]
		[SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "We're just trying to make sure this doesn't throw an exception, which would result in a failed test anyways.")]
		public void Decode_Gibberish(Int32 size) => UTF16.Decode(Gibberish.GenerateUTF16(size));

		[Theory]
		[InlineData(0x01D11E, new Char[] { '\uD834', '\uDD1E' })]
		[InlineData(0x01D13D, new Char[] { '\uD834', '\uDD3D' })]
		public void Encode(UInt32 scalarValue, Char[] expected) {
			Assert.Equal(expected, UTF16.Encode(new Rune(scalarValue)).ToArray());
		}

		[Theory]
		[InlineData(128)]
		[InlineData(256)]
		[InlineData(512)]
		[InlineData(1024)]
		[InlineData(2048)]
		[InlineData(4096)]
		[SuppressMessage("Blocker Code Smell", "S2699:Tests should include assertions", Justification = "We're just trying to make sure this doesn't throw an exception, which would result in a failed test anyways.")]
		public void Encode_Gibberish(Int32 size) => UTF16.Encode(Gibberish.GenerateUTF32(size));

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
		public void IsFirstUnit(UInt16 unit, Boolean expected) => Assert.Equal(expected, UTF16.IsFirstUnit(unit));

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
		public void SequenceLength(UInt16 unit, Int32 expected) => Assert.Equal(expected, UTF16.SequenceLength(unit));
	}
}
