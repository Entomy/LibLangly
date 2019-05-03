using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RepeaterTests {
		[TestMethod]
		public void Constructor() {
			Repeater _ = (Literal)"Hi! " * 2;
		}

		[TestMethod]
		public void Consume() {
			Repeater Repeater = (Literal)"Hi! " * 2;
			ResultAssert.Captures("Hi! Hi! ", Repeater.Consume("Hi! Hi! Hi!"));
		}
	}
}
