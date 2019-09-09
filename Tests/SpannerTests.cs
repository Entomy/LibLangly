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
			Assert.That.Captures(" ", Result);

			Result = Whitespace.Consume("    Hi!");
			Assert.That.Captures("    ", Result);

			Result = Whitespace.Consume("Hi!  ");
			Assert.That.Fails(Result);
		}

		[TestMethod]
		public void Equal() {
			Pattern AB = +(Pattern)"AB";

			Assert.IsFalse(AB.Equals(""));
			Assert.IsFalse(AB.Equals("A"));
			Assert.IsTrue(AB.Equals("AB"));
			Assert.IsFalse(AB.Equals("ABA"));
			Assert.IsTrue(AB.Equals("ABAB"));
			Assert.IsFalse(AB.Equals("ABABA"));

			Assert.IsFalse(AB.Equals("AAB"));
			Assert.IsFalse(AB.Equals("ABB"));
		}
	}
}