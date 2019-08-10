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
			Pattern Space = " ";
			Pattern World = "World";
			Assert.That.Captures("Hello", Hello.Consume("Hello World!"));
			Source Source = new Source("Hello World");
			Assert.That.Captures("Hello", Hello.Consume(ref Source));
			Assert.That.Captures(" ", Space.Consume(ref Source));
			Assert.That.Captures("World", World.Consume(ref Source));
		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			Pattern HelloWorld = ("HELLO WORLD", StringComparison.OrdinalIgnoreCase);
			Assert.That.Captures("HELLO WORLD", HelloWorld.Consume("HELLO WORLD!"));
			Assert.That.Captures("Hello World", HelloWorld.Consume("Hello World!"));
			Assert.That.Captures("hello world", HelloWorld.Consume("hello world!"));
		}

		[TestMethod]
		public void ConsumeFail() {
			Pattern Hello = "Hello";
			Assert.That.Fails(Hello.Consume("Hell"));
			Assert.That.Fails(Hello.Consume("Bacon"));
		}
	}
}
