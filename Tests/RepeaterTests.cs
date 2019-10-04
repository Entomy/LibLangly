using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RepeaterTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (Pattern)"Hi! " * 2;
		}

		[TestMethod]
		public void Consume() {
			Pattern Repeater = (Pattern)"Hi! " * 2;
			Result Result;

			Result = Repeater.Consume("Hi! Hi! Hi!");
			ResultAssert.Captures("Hi! Hi! ", Result);

			Result = Repeater.Consume("Bye!");
			ResultAssert.Fails(Result);
		}

		[TestMethod]
		public void Equal() {
			Pattern Repeater = (Pattern)"Hi!" * 2;

			Assert.IsTrue(Repeater.Equals("Hi!Hi!"));
			Assert.IsFalse(Repeater.Equals("Hi!"));
			Assert.IsFalse(Repeater.Equals("Hi!Ho."));
			Assert.IsFalse(Repeater.Equals("Hi!Hi!Hi!"));
		}
	}
}
