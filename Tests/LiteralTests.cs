using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class LiteralTests {
		[TestMethod]
		public void Constructor() {
			Literal _;
			_ = "Hello";
		}

		[TestMethod]
		public void Consume() {
			Literal Hello = "Hello";
			Literal Space = " ";
			Literal World = "World";
			ResultAssert.Captures("Hello", Hello.Consume("Hello World!"));
			Source Source = new Source("Hello World");
			ResultAssert.Captures("Hello", Hello.Consume(ref Source));
			ResultAssert.Captures(" ", Space.Consume(ref Source));
			ResultAssert.Captures("World", World.Consume(ref Source));
		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			Literal HelloWorld = ("HELLO WORLD", StringComparison.OrdinalIgnoreCase);
			ResultAssert.Captures("HELLO WORLD", HelloWorld.Consume("HELLO WORLD!"));
			ResultAssert.Captures("Hello World", HelloWorld.Consume("Hello World!"));
			ResultAssert.Captures("hello world", HelloWorld.Consume("hello world!"));
		}
	}
}
