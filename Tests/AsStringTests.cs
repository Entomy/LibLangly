using System;
using System.Text;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class AsStringTests : Trial {
		[Theory]
		[InlineData(new[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F }, "hello")]
		[InlineData(new[] { 0x43F, 0x440, 0x438, 0x432, 0x435, 0x442 }, "привет")]
		[InlineData(new[] { 0x1D11E }, "𝄞")]
		public void AsString_Runes(Int32[] scalarValues, String expected) {
			Rune[] runes = new Rune[scalarValues.Length];
			for (Int32 i = 0; i < runes.Length; i++) {
				runes[i] = new Rune(scalarValues[i]);
			}
			Claim.That(runes.AsString()).Equals(expected);
		}
	}
}
