using System;
using System.Text;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class TrimTests : Trial {
		[Theory]
		[InlineData("  hello  ", ' ', "hello")]
		[InlineData("𝄞𝄞hello𝄞𝄞", 0x1D11E, "hello")]
		public void Trim(String source, Int32 trimSV, String expected) => Claim.That(source.Trim(new Rune(trimSV))).Equals(expected);

		[Theory]
		[InlineData("hello  ", ' ', "hello")]
		[InlineData("hello𝄞𝄞", 0x1D11E, "hello")]
		public void TrimEnd(String source, Int32 trimSV, String expected) => Claim.That(source.TrimEnd(new Rune(trimSV))).Equals(expected);

		[Theory]
		[InlineData("  hello", ' ', "hello")]
		[InlineData("𝄞𝄞hello", 0x1D11E, "hello")]
		public void TrimStart(String source, Int32 trimSV, String expected) => Claim.That(source.TrimStart(new Rune(trimSV))).Equals(expected);
	}
}
