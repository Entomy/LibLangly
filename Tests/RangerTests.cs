using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RangerTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (From: "Hello", To: ";");
		}

		[TestMethod]
		public void Consume() {
			Pattern Ranger = (From: "Hello", To: ";");
			Result Result;

			Result = Ranger.Consume("Hello;");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello;", Result);

			Result = Ranger.Consume("Hello World;");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello World;", Result);
		}

		[TestMethod]
		public void EscapedConsume() {
			Pattern Ranger = (From: "\"", To: "\"", Escape: "\"\"");
			Result Result;

			Result = Ranger.Consume("\"\"");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("\"\"", Result);

			Result = Ranger.Consume("\"H\"");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("\"H\"", Result);

			Result = Ranger.Consume("\"Hello\"");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("\"Hello\"", Result);

			Result = Ranger.Consume("\"Hello\"\"Goodbye\"");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("\"Hello\"\"Goodbye\"", Result);

			// Should also check for C style escapes
			Ranger = (From: "\"", To: "\"", Escape: "\\\"");

			Result = Ranger.Consume("\"Hello\\\"Goodbye\"");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("\"Hello\\\"Goodbye\"", Result);
		}

	}
}
