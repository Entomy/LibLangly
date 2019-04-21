using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CharTests {
		[TestMethod]
		public void Join() {
			Assert.AreEqual("hello", new Char[]{ 'h', 'e', 'l', 'l', 'o' }.Join());
			Assert.AreEqual("h e l l o", new Char[] { 'h', 'e', 'l', 'l', 'o' }.Join(' '));
		}
	}
}
