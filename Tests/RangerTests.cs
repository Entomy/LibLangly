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
			Assert.That.Captures("Hello;", Ranger.Consume("Hello;"));
			Assert.That.Captures("Hello World;", Ranger.Consume("Hello World;"));
		}

		[TestMethod]
		public void EscapedConsume() {
			Pattern Ranger = (From: "\"", To: "\"", Escape: "\"\"");
			Assert.That.Captures("\"\"", Ranger.Consume("\"\""));
			Assert.That.Captures("\"H\"", Ranger.Consume("\"H\""));
			Assert.That.Captures("\"Hello\"", Ranger.Consume("\"Hello\""));
			Assert.That.Captures("\"Hello\"\"Goodbye\"", Ranger.Consume("\"Hello\"\"Goodbye\""));
			// Should also check for C style escapes
			Ranger = (From: "\"", To: "\"", Escape: "\\\"");
			Assert.That.Captures("\"Hello\\\"Goodbye\"", Ranger.Consume("\"Hello\\\"Goodbye\""));
		}

	}
}
