using System;
using System.Text.Metrics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class MetricsTests {
		[DataTestMethod]
		[DataRow("kitten", "sitting", 3)]
		public void LevenshteinDistance(String s, String d, Int32 i) {
			Assert.AreEqual(i, s.LevenshteinDistance(d));
		}
	}
}
