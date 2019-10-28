using System;
using System.Text.Patterns;
using System.Text.Patterns.Unsafe.InPlace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class JumperTests {
		[TestMethod]
		public void Target() {
			Pattern Pattern = Pattern.Number.Target(out Target Target);
			Assert.IsTrue(Target == Pattern);
		}

		[TestMethod]
		public void Recursion() {
			Pattern Pattern = Pattern.Number | Pattern.EndOfSource;

			//At this point it should only consume a single number or pass if at the end of the source.
			ResultAssert.Captures("", Pattern.Consume(""));
			ResultAssert.Captures("1", Pattern.Consume("1"));
			ResultAssert.Captures("1", Pattern.Consume("12"));

			//Now grab a target to that pattern
			_ = Pattern.Target(out Target Target);

			// And concatenate the jumper to that target
			_ = Pattern.Concatenate(Target);

			//At this point it should now recurse, consuming numbers until reaching the end of the source.
			ResultAssert.Captures("", Pattern.Consume(""));
			ResultAssert.Captures("1", Pattern.Consume("1"));
			ResultAssert.Captures("12", Pattern.Consume("12"));
			ResultAssert.Captures("123", Pattern.Consume("123"));
		}
	}
}
