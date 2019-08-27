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
			Result Result;

			Result = "".Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("", Result);

			Result = "H".Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("H", Result);

			Result = "He".Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("He", Result);

			Result = "Hel".Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hel", Result);

			Result = "Hell".Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hell", Result);

			Result = "Hello".Consume("Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello", Result);

			Result = " ".Consume("    Hello");
			Assert.That.Succeeds(Result);
			Assert.That.Captures(" ", Result);

			Assert.That.Fails("w".Consume("Hello"));
			Assert.That.Fails(" ".Consume("Hello"));
		}

		[TestMethod]
		public void ConsumeCaseInsensitive() {
			Result Result = "HELLO".Consume("Hello", StringComparison.OrdinalIgnoreCase);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hello", Result);
		}

		[TestMethod]
		public void ConsumeSource() {
			Source Source = new Source("Hello");
			Result Result;

			Result = "H".Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("H", Result);

			Result = "e".Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("e", Result);

			Result = "l".Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("l", Result);

			Result = "l".Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("l", Result);

			Result = "o".Consume(ref Source);
			Assert.That.Succeeds(Result);
			Assert.That.Captures("o", Result);
		}

		[TestMethod]
		public void ConsumeResult() {
			Source Source = new Source("Hello World! How are you today?");
			Result Result = "Hello World!".Consume(ref Source, StringComparison.OrdinalIgnoreCase);
			Assert.That.Captures("Hello", "Hello".Consume(Result));
		}

		[TestMethod]
		public void Neglect() {
			Result Result;

			Result = "Hello".Neglect("Hello");
			Assert.That.Fails(Result);
			Assert.That.Captures("", Result);

			Result = "Hello".Neglect("World");
			Assert.That.Succeeds(Result);
			Assert.That.Captures("World", Result);
		}
	}
}
