using System.Text.Patterns;
using System.Text.Patterns.Unsafe.InPlace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class UnsafeTests {
		[TestMethod]
		public void PhoneNumber() {
			Pattern Pattern = Pattern.Number * 3;

			Pattern.Concatenate('-').Concatenate(Pattern.Number * 3).Concatenate('-').Concatenate(Pattern.Number * 4);

			Result Result = Pattern.Consume("555-555-5555");
			ResultAssert.Captures("555-555-5555", Result);
		}
	}
}
