using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stringier.Patterns;
using Stringier.Patterns.Parser;

namespace Patterns.Parser.Tests {
	[TestClass]
	public class LiteralTests {
		[TestMethod]
		public void Consume() {
			Source source = new Source("\"hello\"");
			Assert.AreEqual("hello", Literal.Consume(ref source).ToString());
		}
	}
}
