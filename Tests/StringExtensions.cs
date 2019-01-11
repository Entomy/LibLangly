using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class StringExtensions {
		[TestMethod]
		public void Chop() {
			Assert.AreEqual("abc", "abcdefg".Chop(3)[0]);
			Assert.AreEqual("def", "abcdefg".Chop(3)[1]);
			Assert.AreEqual("g", "abcdefg".Chop(3)[2]);
			Assert.AreEqual("abcd", "abcdefg".Chop(4)[0]);
			Assert.AreEqual("efg", "abcdefg".Chop(4)[1]);
		}
	}
}
