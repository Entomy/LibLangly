using System;
using Stringier;
using Xunit;

namespace Tests {
	public class SplitTests {
		[Theory]
		[InlineData("comma,separated,values", ',', new[] { "comma", "separated", "values" })]
		public void Split_Char(String source, Char separator, String[] expected) {
			Assert.Equal(expected, source.Split(separator));
			Assert.Equal(expected, source.AsSpan().Split(separator));
		}

		[Theory]
		[InlineData("comma, separated, values, 1,300", ", ", new[] { "comma", "separated", "values", "1,300" })]
		public void Split_String(String source, String separator, String[] expected) {
			Assert.Equal(expected, source.Split(separator));
			Assert.Equal(expected, source.AsSpan().Split(separator));
		}
	}
}
