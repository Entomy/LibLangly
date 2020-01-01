using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;
using static Benchmarks.Patterns.ConcatenatorBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class ConcatenatorTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, String> result;

			result = pidgin.Parse("Hello World");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hello World", result.Value);

			result = pidgin.Parse("Hello");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<String> result;

			result = sprache.TryParse("Hello World");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hello World", result.Value);

			result = sprache.TryParse("Hello");
			Assert.IsFalse(result.WasSuccessful);
		}
	}
}
