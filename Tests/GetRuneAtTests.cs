using System;
using Xunit;

namespace Langly {
	public static class GetRuneAtTests {
		[Theory]
		[InlineData("a", 0, (int)'a')]
		[InlineData("ab", 1, (int)'b')]
		[InlineData("x\U0001F46Ey", 3, (int)'y')]
		[InlineData("x\U0001F46Ey", 1, 0x1F46E)] // U+1F46E POLICE OFFICER
		public static void GetRuneAt(String inputString, Int32 index, Int32 expected) => Assert.Equal(expected, inputString.GetRuneAt(index).Value);
	}
}
