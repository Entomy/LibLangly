using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;

namespace Benchmarks {
	[TestClass]
	public class OptorTests {
		[TestMethod]
		public void Pidgin() {
			Parser<Char, String> pidgin = Parser.Try(Parser.String("Hello"));
			Result<Char, String> result;

			result = pidgin.Parse("Hello");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hello", result.Value);

			result = pidgin.Parse("World");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			Sprache.Parser<IOption<String>> sprache = Parse.Optional(Parse.String("Hello").Text());
			IOption<String> result;

			result = sprache.Parse("Hello");
			Assert.IsTrue(result.IsDefined);
			Assert.AreEqual("Hello", result.Get());

			result = sprache.Parse("World");
			Assert.IsFalse(result.IsDefined);
			Assert.AreEqual("Failed", result.GetOrElse("Failed"));
		}
	}
}
