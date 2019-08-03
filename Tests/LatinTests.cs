using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class LatinTests {
		[DataTestMethod]
		[DataRow("a")]
		public void BasicLowercaseTests(String Char) {
			Assert.IsTrue(Latin.BasicLowercase.Consume(Char));
		}

		[DataTestMethod]
		[DataRow("A")]
		public void BasicUppercaseTests(String Char) {
			Assert.IsTrue(Latin.BasicUppercase.Consume(Char));
		}

		[DataTestMethod]
		[DataRow("a")]
		public void BasicLetterTests(String Char) {
			Assert.IsTrue(Latin.BasicLetter.Consume(Char));
		}

		[DataTestMethod]
		[DataRow("ā")]
		[DataRow("ř")]
		public void ExtendedALowercaseTests(String Char) {
			Assert.IsTrue(Latin.ExtendedALowercase.Consume(Char));
		}

		[DataTestMethod]
		[DataRow("a")]
		[DataRow("A")]
		[DataRow("ą")]
		public void LetterTests(String Char) {
			Assert.IsTrue(Latin.Letter.Consume(Char));
		}
	}
}
