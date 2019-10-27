using System;
using System.Text.Patterns;
using System.Text.Patterns.Unsafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class JumperTests {
		[TestMethod]
		public void Target() {
			Pattern Pattern = Pattern.Number.Target(out Target Target);
			Assert.IsTrue(Target == Pattern);
		}
	}
}
