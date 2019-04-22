using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class AlternatorTests {
		[TestMethod]
		public void Constructor() {
			Alternator _ = (Literal)"Hello" | "Goodbye";
		}

		[TestMethod]
		public void Consume() {
			Alternator Alternator = (Literal)"Hello" | "Goodbye";
			ResultAssert.Remains("", Alternator.Consume("Hello"));
			ResultAssert.Remains("", Alternator.Consume("Goodbye"));
			ResultAssert.Remains("!", Alternator.Consume("!"));
		}
	}
}
