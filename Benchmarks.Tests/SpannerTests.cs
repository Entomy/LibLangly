using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using Sprache;
using Stringier;
using static Benchmarks.Patterns.SpannerBenchmarks;

namespace Benchmarks {
	[TestClass]
	public class SpannerTests {
		[TestMethod]
		public void Pidgin() {
			Result<Char, String> result;

			result = pidgin.Parse("Hi!");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hi!", result.Value);

			result = pidgin.Parse("Hi!Hi!");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hi!Hi!", result.Value);

			result = pidgin.Parse("Hi!Hi!Hi!");
			Assert.IsTrue(result.Success);
			Assert.AreEqual("Hi!Hi!Hi!", result.Value);

			result = pidgin.Parse("Okay?");
			Assert.IsFalse(result.Success);
		}

		[TestMethod]
		public void Sprache() {
			IResult<IEnumerable<String>> result;

			result = sprache.TryParse("Hi!");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hi!", result.Value.Join());

			result = sprache.TryParse("Hi!Hi!");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hi!Hi!", result.Value.Join());

			result = sprache.TryParse("Hi!Hi!Hi!");
			Assert.IsTrue(result.WasSuccessful);
			Assert.AreEqual("Hi!Hi!Hi!", result.Value.Join());

			result = sprache.TryParse("Okay?");
			Assert.IsFalse(result.WasSuccessful);
		}
	}
}
