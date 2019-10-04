using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RangerTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (From: "Hello", To: ';');
		}

		[TestMethod]
		public void Consume() {
			Pattern Ranger = (From: "Hello", To: ';');
			Result Result;

			Result = Ranger.Consume("Hello;");
			ResultAssert.Captures("Hello;", Result);


			Result = Ranger.Consume("Hello World;");
			ResultAssert.Captures("Hello World;", Result);
		}

		[TestMethod]
		public void EscapedConsume() {
			Pattern Ranger = (From: "\"", To: "\"", Escape: "\"\"");
			Result Result;

			Result = Ranger.Consume("\"\"");
			ResultAssert.Captures("\"\"", Result);

			Result = Ranger.Consume("\"H\"");
			ResultAssert.Captures("\"H\"", Result);

			Result = Ranger.Consume("\"Hello\"");
			ResultAssert.Captures("\"Hello\"", Result);

			Result = Ranger.Consume("\"Hello\"\"Goodbye\"");
			ResultAssert.Captures("\"Hello\"\"Goodbye\"", Result);

			// Should also check for C style escapes
			Ranger = (From: "\"", To: "\"", Escape: "\\\"");

			Result = Ranger.Consume("\"Hello\\\"Goodbye\"");
			ResultAssert.Captures("\"Hello\\\"Goodbye\"", Result);
		}

		[TestMethod]
		public void NestedConsume() {
			Pattern Ranger = (From: "if", To: "end if", Nested: true);
			Result Result;

			Result = Ranger.Consume("if\nif\nend if\nbacon\nend if\nfoobar");
			ResultAssert.Captures("if\nif\nend if\nbacon\nend if", Result);

			Result = Ranger.Consume("if\nif\nend if\nbacon\nfoobar");
			ResultAssert.Fails(Result);
		}
	}
}
