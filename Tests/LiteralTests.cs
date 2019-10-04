using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class LiteralTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = "Hello";
		}

		[TestMethod]
		public void Consume() {
			Pattern Hello = "Hello";
			Pattern Space = ' ';
			Pattern World = "World";
			Result Result;

			Result = Hello.Consume("Hello World!");
			ResultAssert.Captures("Hello", Result);

			Source Source = new Source("Hello World");

			Result = Hello.Consume(ref Source);
			ResultAssert.Captures("Hello", Result);

			Result = Space.Consume(ref Source);
			ResultAssert.Captures(" ", Result);

			Result = World.Consume(ref Source);
			ResultAssert.Captures("World", Result);

			Result = Hello.Consume("Hell");
			ResultAssert.Fails(Result);

			Result = Hello.Consume("Bacon");
			ResultAssert.Fails(Result);

			Pattern HelloWorld = Hello & Space & World; //This isn't a normal concatenator, but rather, should be optimized into a single StringLiteral

			Result = HelloWorld.Consume("HELLO WORLD!");
			ResultAssert.Captures("HELLO WORLD", Result);

			Result = HelloWorld.Consume("Hello World!");
			ResultAssert.Captures("Hello World", Result);

			Result = HelloWorld.Consume("hello world!");
			ResultAssert.Captures("hello world", Result);
		}

		[TestMethod]
		public void Equal() {
			Pattern Hello = "Hello";
			Pattern Space = ' ';
			Pattern World = "World";

			Assert.IsTrue(Hello.Equals("Hello"));
			Assert.IsFalse(Hello.Equals("Hello "));
			Assert.IsFalse(Hello.Equals("Hell"));
			Assert.IsFalse(Hello.Equals("World"));

			Assert.IsTrue(Space.Equals(" "));
			Assert.IsFalse(Space.Equals("  "));
			Assert.IsFalse(Space.Equals("a"));

			Pattern HelloWorld = Hello & Space & World; //This isn't a normal concatenator, but rather, should be optimized into a single StringLiteral

			Assert.IsTrue(HelloWorld.Equals("Hello World"));
			Assert.IsFalse(HelloWorld.Equals("Hello"));
			Assert.IsFalse(HelloWorld.Equals("Hello Bacon"));
		}
	}
}
