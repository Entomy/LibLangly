using System;
using Stringier;
using Xunit;

namespace Tests {
	public class LinesTests {
		[Theory]
		[InlineData("Some example text.\nWith some line breaks.\nWhich will be split up", new[] { "Some example text.", "With some line breaks.", "Which will be split up"})]
		public void Lines(String source, String[] expected) => Assert.Equal(expected, source.Lines());
	}
}
