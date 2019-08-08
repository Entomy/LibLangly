using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RangerTests {
		[TestMethod]
		public void Constructor() {
			Pattern _ = (From: "Hello", To: ";");
		}

		[TestMethod]
		public void Consume() {
			Pattern Ranger = (From: "Hello", To: ";");
			ResultAssert.Captures("Hello;", Ranger.Consume("Hello;"));
			ResultAssert.Captures("Hello World;", Ranger.Consume("Hello World;"));
		}
	}
}
