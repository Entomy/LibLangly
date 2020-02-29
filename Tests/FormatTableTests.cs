using System;
using Stringier;
using Xunit;

namespace Tests {
	public class FormatTableTests {
		[Theory]
		[InlineData(new[] { "one", "two", "three", "four", "five" }, "one│two│three│four│five\n", new[] { "six", "seven", "eight", "nine", "ten" }, "one│two  │three│four│five\nsix│seven│eight│nine│ten \n")]
		public void FormatTable_AlignLeft(String[] firstFormatParams, String firstExpected, String[] secondFormatParams, String secondExpected) {
			FormatTable table = new FormatTable(5, Alignment.Left);
			table.Format(firstFormatParams);
			Assert.Equal(firstExpected, table.ToString());
			table.Format(secondFormatParams);
			Assert.Equal(secondExpected, table.ToString());
		}

		[Theory]
		[InlineData(new[] { "one", "two", "three", "four", "five" }, "one│two│three│four│five\n", new[] { "six", "seven", "eight", "nine", "ten" }, "one│  two│three│four│five\nsix│seven│eight│nine│ ten\n")]
		public void FormatTable_AlignRight(String[] firstFormatParams, String firstExpected, String[] secondFormatParams, String secondExpected) {
			FormatTable table = new FormatTable(5, Alignment.Right);
			table.Format(firstFormatParams);
			Assert.Equal(firstExpected, table.ToString());
			table.Format(secondFormatParams);
			Assert.Equal(secondExpected, table.ToString());
		}

		[Theory]
		[InlineData(new[] { "one", "two", "three", "four", "five" }, "one│two│three│four│five\n", new[] { "six", "seven", "eight", "nine", "ten" }, "one│ two │three│four│five\nsix│seven│eight│nine│ten \n")]
		public void FormatTable_AlignCenter(String[] firstFormatParams, String firstExpected, String[] secondFormatParams, String secondExpected) {
			FormatTable table = new FormatTable(5, Alignment.Center);
			table.Format(firstFormatParams);
			Assert.Equal(firstExpected, table.ToString());
			table.Format(secondFormatParams);
			Assert.Equal(secondExpected, table.ToString());
		}
	}
}
