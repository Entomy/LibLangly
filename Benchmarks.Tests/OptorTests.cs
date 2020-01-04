using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;
using static Benchmarks.Patterns.OptorBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class OptorTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, String> result;

			result = pidgin.Parse("Hello");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hello", result.Value);

			result = pidgin.Parse("World");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<IOption<String>> result;

			result = sprache.TryParse("Hello");
			Assert.IsTrue(result.WasSuccessful);
			Assert.IsTrue(result.Value.IsDefined);
			Assert.AreEqual("Hello", result.Value.Get());

			result = sprache.TryParse("World");
			Assert.IsTrue(result.WasSuccessful);
			Assert.IsFalse(result.Value.IsDefined);
		}
	}
}
