using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CombinatorTests {
		[TestMethod]
		public void Constructor() {
			Combinator _ = (Literal)"Hello" & " " & "world";
		}

		[TestMethod]
		public void Consume() {
			Combinator HelloWorld = (Literal)"Hello" & " " & "world";
			Combinator GoodbyeWorld = (Literal)"Goodbye" & " " & "world";
			ResultAssert.Captures("Hello world", HelloWorld.Consume("Hello world"));
			ResultAssert.Captures("Goodbye world", GoodbyeWorld.Consume("Goodbye world"));
			ResultAssert.Captures("Hello ", HelloWorld.Consume("Hello World")); // Remember, string comparisons are case sensitive by default, so "World" isn't a match
		}
	}
}
