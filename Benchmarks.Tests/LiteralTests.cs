using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;
using static Benchmarks.Patterns.LiteralBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class LiteralTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, String> result;

			result = pidgin.Parse("Hello");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hello", result.Value);

			result = pidgin.Parse("World");
			Assert.IsFalse(result.Success);

			result = pidgin.Parse("H");
			Assert.IsFalse(result.Success);

			result = pidgin.Parse("Failure");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<String> result;

			result = sprache.TryParse("Hello");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hello", result.Value);

			result = sprache.TryParse("World");
			Assert.IsFalse(result.WasSuccessful);

			result = sprache.TryParse("H");
			Assert.IsFalse(result.WasSuccessful);

			result = sprache.TryParse("Failure");
			Assert.IsFalse(result.WasSuccessful);
		}
	}
}
