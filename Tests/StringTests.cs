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
			Assert.That.Captures("", "".Consume("Hello"));
			Assert.That.Captures("H", "H".Consume("Hello"));
			Assert.That.Captures("He", "He".Consume("Hello"));
			Assert.That.Captures("Hel", "Hel".Consume("Hello"));
			Assert.That.Captures("Hell", "Hell".Consume("Hello"));
			Assert.That.Captures("Hello", "Hello".Consume("Hello"));

			Assert.That.Captures(" ", " ".Consume("    Hello"));
			Assert.That.Succeeds(" ".Consume("    Hello"));
		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			Assert.That.Captures("Hello", "HELLO".Consume("Hello", StringComparison.OrdinalIgnoreCase));
		}

		[TestMethod]
		public void ConsumeSource() {
			Source Source = new Source("Hello");
			Assert.That.Captures("H", "H".Consume(ref Source));
			Assert.That.Captures("e", "e".Consume(ref Source));
			Assert.That.Captures("l", "l".Consume(ref Source));
			Assert.That.Captures("l", "l".Consume(ref Source));
			Assert.That.Captures("o", "o".Consume(ref Source));
		}

		[TestMethod]
		public void ConsumeFail() {
			Assert.That.Fails("w".Consume("Hello"));
			Assert.That.Fails(" ".Consume("Hello"));
		}

		[TestMethod]
		public void Neglect() {
			Assert.That.Captures("", "Hello".Neglect("Hello"));
			Assert.That.Captures("World", "Hello".Neglect("World"));
		}
	}
}
