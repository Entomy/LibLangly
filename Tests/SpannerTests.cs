using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SpannerTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = +(Pattern)" ";
		}

		[TestMethod]
		public void Consume() {
			Pattern Whitespace = +(Pattern)" ";
			Result Result;

			Result = Whitespace.Consume(" Hi!");
			Assert.That.Succeeds(Result);
			Assert.That.Captures(" ", Result);

			Result = Whitespace.Consume("    Hi!");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("    ", Result);

			Result = Whitespace.Consume("Hi!  ");
			Assert.That.Fails(Result);
		}
	}
}