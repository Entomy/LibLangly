using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;
using static Benchmarks.Patterns.AlternatorBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class AlternatorTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, String> result;

			result = pidgin.Parse("Hello");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hello", result.Value);

			result = pidgin.Parse("Goodbye");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Goodbye", result.Value);

			result = pidgin.Parse("Bacon");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<String> result;

			result = sprache.TryParse("Hello");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hello", result.Value);

			result = sprache.TryParse("Goodbye");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Goodbye", result.Value);

			result = sprache.TryParse("Bacon");
			Assert.IsFalse(result.WasSuccessful);
		}
	}
}
