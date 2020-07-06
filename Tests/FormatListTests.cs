using System;
using Stringier;
using Xunit;

namespace Tests {
	public class FormatListTests {
		[Theory]
		[InlineData("", new String[] { }, "")]
		[InlineData("", new[] { "first", "second", "third" }, "first\nsecond\nthird\n")]
		[InlineData("-", new[] { "first", "second", "third" }, "-first\n-second\n-third\n")]
		public void Unordered_Simple(String prefix, String[] args, String expected) {
			FormatList list = new UnorderedFormatList(prefix);
			foreach (String arg in args) {
				list.Format(arg);
			}
			Assert.Equal(expected, list.ToString().Replace("\r\n", "\n")); // Doing this replacement allows this test to work across operating systems.
		}

		[Theory]
		[InlineData("", "", new String[] { }, new String[] { }, "Indent\n")]
		[InlineData("", "\t", new String[] { }, new String[] { }, "\tIndent\n")]
		[InlineData("", "\t", new[] { "first", "second", "third" }, new[] { "fourth", "fifth", "sixth" }, "first\nsecond\nthird\n\tIndent\n\tfourth\n\tfifth\n\tsixth\n")]
		public void Unordered_Indented(String prefix, String indentation, String[] firstArgs, String[] secondArgs, String expected) {
			FormatList list = new UnorderedFormatList(prefix, indentation);
			foreach (String arg in firstArgs) {
				list.Format(arg);
			}
			list.Format("Indent", Indent.More);
			foreach(String arg in secondArgs) {
				list.Format(arg);
			}
			Assert.Equal(expected, list.ToString().Replace("\r\n", "\n")); // Doing this replacement allows this test to work across operating systems.
		}
	}
}
