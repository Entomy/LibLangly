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
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello", Result);

			Source Source = new Source("Hello World");

			Result = Hello.Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello", Result);

			Result = Space.Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures(" ", Result);

			Result = World.Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("World", Result);

			Result = Hello.Consume("Hell");
			Assert.That.Fails(Result);

			Result = Hello.Consume("Bacon");
			Assert.That.Fails(Result);

		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			Pattern HelloWorld = ("HELLO WORLD", StringComparison.OrdinalIgnoreCase);
			Result Result;

			Result = HelloWorld.Consume("HELLO WORLD!");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("HELLO WORLD", Result);

			Result = HelloWorld.Consume("Hello World!");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello World", Result);

			Result = HelloWorld.Consume("hello world!");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("hello world", Result);
		}
	}
}
