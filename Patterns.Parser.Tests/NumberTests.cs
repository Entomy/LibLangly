using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stringier.Patterns;
using Stringier.Patterns.Parser;

namespace Patterns.Parser.Tests {
	[TestClass]
	public class NumberTests {
		[TestMethod]
		public void Consume() {
			Source source = new Source("7");
			Assert.AreEqual("7", Number.Consume(ref source).ToString());
		}
	}
}
