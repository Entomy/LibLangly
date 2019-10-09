using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RegexAdapterTests {
		private Pattern pattern;

		[TestMethod]
		public void Converter() {
			Assert.ThrowsException<PatternConstructionException>(() => pattern = new Regex(@"hello"));
			pattern = new Regex(@"^hello");
			Assert.ThrowsException<PatternConstructionException>(() => pattern = new Regex(@"hello$"));
			pattern = new Regex(@"^hello$");
		}

		[TestMethod]
		public void Consume() {
			Pattern Regex = new Regex(@"^hello");
			ResultAssert.Captures("hello", Regex.Consume("hello"));
			ResultAssert.Captures("hello", Regex.Consume("hello world"));
			ResultAssert.Fails(Regex.Consume("hel"));
		}
	}
}
