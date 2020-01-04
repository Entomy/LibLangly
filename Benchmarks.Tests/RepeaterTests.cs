using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Stringier;
using Sprache;
using static Benchmarks.Patterns.RepeaterBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class RepeaterTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, IEnumerable<String>> result;

			result = pidgin.Parse("Hi!Hi!Hi!Hi!Hi!");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hi!Hi!Hi!Hi!Hi!", result.Value.Join());

			result = pidgin.Parse("Hi!");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<IEnumerable<String>> result;

			result = sprache.TryParse("Hi!Hi!Hi!Hi!Hi!");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hi!Hi!Hi!Hi!Hi!", result.Value.Join());

			result = sprache.TryParse("Hi!");
			Assert.IsFalse(result.WasSuccessful);
		}
	}
}
