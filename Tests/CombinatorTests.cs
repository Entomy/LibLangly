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
			Result Result;

			Result = HelloWorld.Consume("Hello world");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello world", Result);

			Result = GoodbyeWorld.Consume("Goodbye world");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Goodbye world", Result);
		}

		[TestMethod]
		public void ConsumeFail() {
			Pattern HelloWorld = (Pattern)"Hello" & " " & "world";
			Assert.That.Fails(HelloWorld.Consume("Hello everyone"));
			Assert.That.Fails(HelloWorld.Consume("Hello World")); // Remember, string comparisons are case sensitive by default, so "World" isn't a match
		}
	}
}
