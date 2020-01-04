using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;
using static Benchmarks.Patterns.NegatorBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class NegatorTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, Pidgin.Unit> result;

			result = pidgin.Parse("World");
			Assert.IsTrue(result.Success);

			result = pidgin.Parse("Hello");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<Object> result;

			result = sprache.TryParse("World");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual(null, result.Value);

			result = sprache.TryParse("Hello");
			Assert.IsFalse(result.WasSuccessful);
		}
	}
}
