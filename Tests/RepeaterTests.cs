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
			Assert.That.Succeeds(Result);
			Assert.That.Captures("Hi! Hi! ", Result);
		}

		[TestMethod]
		public void ConsumeFail() {
			Pattern Repeater = (Pattern)"Hi! " * 2;

			Result Result = Repeater.Consume("Bye!");
			Assert.That.Fails(Result);
		}
	}
}
