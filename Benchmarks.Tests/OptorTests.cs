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
