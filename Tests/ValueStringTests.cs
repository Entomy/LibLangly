using System;
using Stringier;
using Defender;
using Xunit;

namespace Tests {
	public class ValueStringTests : Trial {
		[Theory]
		[InlineData(new Char[] { })]
		[InlineData(new Char[] { 'h', 'e', 'l', 'l', 'o' })]
		public void Constructor(Char[] chars) => new ValueString(chars);

		[Theory]
		[InlineData(new Char[] { }, new Char[] { }, 0)]
		[InlineData(new Char[] { 'h', 'e', 'l', 'l', 'o' }, new Char[] { 'h', 'e', 'l', 'l', 'o' }, 0)]
		[InlineData(new Char[] { 'a' }, new Char[] { 'a' }, 0)]
		[InlineData(new Char[] { 'a' }, new Char[] { 'b' }, -1)]
		[InlineData(new Char[] { 'b' }, new Char[] { 'a' }, 1)]
		public void CompareTo_ValueString(Char[] chars, Char[] other, Int32 expected) =>
			Claim.That(new ValueString(chars).CompareTo(new ValueString(other)))
				.Equals(new String(chars).CompareTo(new String(other)));

		[Theory]
		[InlineData(new Char[] { }, "", 0)]
		[InlineData(new Char[] { 'h', 'e', 'l', 'l', 'o' }, "hello", 0)]
		[InlineData(new Char[] { 'a' }, "a", 0)]
		[InlineData(new Char[] { 'a' }, "b", -1)]
		[InlineData(new Char[] { 'b' }, "a", 1)]
		public void CompareTo_String(Char[] chars, String other, Int32 expected) =>
			Claim.That(new ValueString(chars).CompareTo(other))
				.Equals(new String(chars).CompareTo(other));

		[Theory]
		[InlineData(new Char[] { }, new Char[] { })]
		[InlineData(new Char[] { 'h', 'e', 'l', 'l', 'o' }, new Char[] { 'h', 'e', 'l', 'l', 'o' })]
		public void Equals_ValueString(Char[] chars, Char[] expected) => Claim.That(new ValueString(chars)).Equals(new ValueString(expected));

		[Theory]
		[InlineData(new Char[] { }, "")]
		[InlineData(new Char[] { 'h', 'e', 'l', 'l', 'o' }, "hello")]
		public void Equals_String(Char[] chars, String expected) => Claim.That(new ValueString(chars)).Equals(expected);
	}
}
