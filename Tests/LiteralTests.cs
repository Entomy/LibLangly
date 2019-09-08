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
			Assert.That.Captures("Hello", Result);
			Assert.That.Succeeds(Result);

			Source Source = new Source("Hello World");

			Result = Hello.Consume(ref Source);
			Assert.That.Captures("Hello", Result);
			Assert.That.Succeeds(Result);

			Result = Space.Consume(ref Source);
			Assert.That.Captures(" ", Result);
			Assert.That.Succeeds(Result);

			Result = World.Consume(ref Source);
			Assert.That.Captures("World", Result);
			Assert.That.Succeeds(Result);

			Result = Hello.Consume("Hell");
			Assert.That.Fails(Result);

			Result = Hello.Consume("Bacon");
			Assert.That.Fails(Result);

			Pattern HelloWorld = Hello & Space & World; //This isn't a normal concatenator, but rather, should be optimized into a single StringLiteral

			Result = HelloWorld.Consume("HELLO WORLD!");
			Assert.That.Captures("HELLO WORLD", Result);
			Assert.That.Succeeds(Result);

			Result = HelloWorld.Consume("Hello World!");
			Assert.That.Captures("Hello World", Result);
			Assert.That.Succeeds(Result);

			Result = HelloWorld.Consume("hello world!");
			Assert.That.Captures("hello world", Result);
			Assert.That.Succeeds(Result);
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
