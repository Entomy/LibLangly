using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class SourceTests {

		[TestMethod]
		public void Peek() {
			Source Source = new Source("Hello");
			Assert.AreEqual(5, Source.Length);
			Assert.AreEqual("H", Source.Peek(1).ToString());
			Assert.AreEqual(5, Source.Length);
			Assert.AreEqual("He", Source.Peek(2).ToString());
			Assert.AreEqual(5, Source.Length);
		}

		[TestMethod]
		public void Read() {
			Source Source = new Source("Hello");
			Assert.AreEqual(5, Source.Length);
			Assert.AreEqual("H", Source.Read(1).ToString());
			Assert.AreEqual(4, Source.Length);
			Assert.AreEqual("el", Source.Read(2).ToString());
			Assert.AreEqual(2, Source.Length);
		}

	}
}
