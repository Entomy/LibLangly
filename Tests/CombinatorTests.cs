using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CombinatorTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (Pattern)"Hello" & " " & "world";
		}

		[TestMethod]
		public void Consume() {
			Pattern HelloWorld = (Pattern)"Hello" & " " & "world";
			Pattern GoodbyeWorld = (Pattern)"Goodbye" & " " & "world";
			ResultAssert.Captures("Hello world", HelloWorld.Consume("Hello world"));
			ResultAssert.Captures("Goodbye world", GoodbyeWorld.Consume("Goodbye world"));
		}

		[TestMethod]
		public void ConsumeFail() {
			Pattern HelloWorld = (Pattern)"Hello" & " " & "world";
			ResultAssert.Fails(HelloWorld.Consume("Hello everyone"));
			ResultAssert.Fails(HelloWorld.Consume("Hello World")); // Remember, string comparisons are case sensitive by default, so "World" isn't a match
		}
	}
}
