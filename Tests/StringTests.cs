using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class StringTests {
		[TestMethod]
		public void Chop() {
			Assert.AreEqual("abc", "abcdefg".Chop(3)[0]);
			Assert.AreEqual("def", "abcdefg".Chop(3)[1]);
			Assert.AreEqual("g", "abcdefg".Chop(3)[2]);
			Assert.AreEqual("abcd", "abcdefg".Chop(4)[0]);
			Assert.AreEqual("efg", "abcdefg".Chop(4)[1]);
		}

		[TestMethod]
		public void Clean() {
			Assert.AreEqual("Hello World", "Hello  World".Clean());
			Assert.AreEqual("Hello World", "Hello       World".Clean());
			Assert.AreEqual("Hello World", "  Hello    World ".Clean());
			Assert.AreEqual("Hello World", "Hellooo Wooorld".Clean('o'));
		}

		[TestMethod]
		public void IsMatch() {
			Assert.IsTrue("Hello World".IsMatch("^Hello", RegexOptions.IgnoreCase));
		}

		[TestMethod]
		public void Occurences() {
			Assert.AreEqual(2, "Hello World".Occurences('o'));
			Assert.AreEqual(3, "Hello World".Occurences('l'));
			Assert.AreEqual(4, "Hello World".Occurences('e', 'l'));
		}

		[TestMethod]
		public void Pad() {
			Assert.AreEqual("  Hello  ", "Hello".Pad(9));
			Assert.AreEqual("  Hello   ", "Hello".Pad(10));
		}

		[TestMethod]
		public void Strip() {
			Assert.AreEqual("Hello World", "Hello World\n\n".Strip('\n'));
		}

		[TestMethod]
		public void ToCamelCase() {
			Assert.AreEqual("helloWorld", "hello world".ToCamelCase());
		}

		[TestMethod]
		public void ToPascalCase() {
			Assert.AreEqual("HelloWorld", "hello world".ToPascalCase());
		}

		[TestMethod]
		public void Words() {
			Assert.AreEqual("Hello", "Hello World".Words()[0]);
			Assert.AreEqual("World", "Hello World".Words()[1]);
			Assert.AreEqual("Hello", " Hello   World".Words()[0]);
			Assert.AreEqual("World", " Hello   World".Words()[1]);
		}

		[TestMethod]
		public void Consume() {
			ResultAssert.Remains("Hello", "".Consume("Hello"));
			ResultAssert.Remains("ello", "H".Consume("Hello"));
			ResultAssert.Remains("llo", "He".Consume("Hello"));
			ResultAssert.Remains("lo", "Hel".Consume("Hello"));
			ResultAssert.Remains("o", "Hell".Consume("Hello"));
			ResultAssert.Remains("", "Hello".Consume("Hello"));
		}

		[TestMethod]
		public void ConsumeOutput() {
			String Output;
			"Hi!".Consume("Hi!Bye!", out Output);
			Assert.AreEqual("Hi!", Output);
		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			ResultAssert.Remains("", "HELLO".Consume("Hello", StringComparison.OrdinalIgnoreCase));
		}
	}
}
