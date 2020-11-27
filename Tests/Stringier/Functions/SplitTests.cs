using System;
using Xunit;

namespace Langly {
	public class SplitTests {
		[Theory]
		[InlineData("comma,separated,values", ',', new[] { "comma", "separated", "values" })]
		public void Split_Char(String source, Char separator, String[] expected) {
			Int32 i = 0;
			foreach(ReadOnlySpan<Char> chunk in Text.Split(source, separator)) {
				Assert.Equal(expected[i++], chunk.ToString());
			}
		}

		[Theory]
		[InlineData("comma, separated, values, 1,300", ", ", new[] { "comma", "separated", "values", "1,300" })]
		public void Split_String(String source, String separator, String[] expected) {
			Int32 i = 0;
			foreach(ReadOnlySpan<Char> chunk in Text.Split(source, separator)) {
				Assert.Equal(expected[i++], chunk.ToString());
			}
		}
	}
}
