using System;
using System.Collections.Generic;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
		public void Join() {
			IEnumerable<Pattern> Objects = new Pattern[] { "1", "3" };
			Assert.AreEqual("1,3", Objects.Join(','));
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
		public void ParallelForEquals() {
			String A = "Hello";
			String B = "Hello";
			Boolean Result = true;
			Parallel.For(0, 5, (i) => Result &= A[i] == B[i]);
			Assert.IsTrue(Result);
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
		public unsafe void UnsafeForeachEquals() {
			String A = "Hello";
			String B = "Hello";
			Boolean R = true;
			if (A.Length != B.Length) {
				R = false;
				goto Assertion;
			}
			fixed (Char* a = A) {
				fixed (Char* b = B) {
					for (Int32 i = 0; i < A.Length; i++) {
						if (a[i] != b[i]) {
							R = false;
							break;
						}
					}
				}
			}
		Assertion:
			Assert.IsTrue(R);
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
			ResultAssert.Captures("", Result);

			Result = "H".Consume("Hello");
			ResultAssert.Captures("H", Result);

			Result = "He".Consume("Hello");
			ResultAssert.Captures("He", Result);

			Result = "Hel".Consume("Hello");
			ResultAssert.Captures("Hel", Result);

			Result = "Hell".Consume("Hello");
			ResultAssert.Captures("Hell", Result);

			Result = "Hello".Consume("Hello");
			ResultAssert.Captures("Hello", Result);

			Result = " ".Consume("    Hello");
			ResultAssert.Captures(" ", Result);

			ResultAssert.Fails("w".Consume("Hello"));
			ResultAssert.Fails(" ".Consume("Hello"));
		}

		[TestMethod]
		public void ConsumeSource() {
			Source Source = new Source("Hello");
			Result Result;

			Result = "H".Consume(ref Source);
			ResultAssert.Captures("H", Result);

			Result = "e".Consume(ref Source);
			ResultAssert.Captures("e", Result);

			Result = "l".Consume(ref Source);
			ResultAssert.Captures("l", Result);

			Result = "l".Consume(ref Source);
			ResultAssert.Captures("l", Result);

			Result = "o".Consume(ref Source);
			ResultAssert.Captures("o", Result);
		}
	}
}
