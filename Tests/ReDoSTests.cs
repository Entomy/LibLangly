using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class ReDoSTests {
		//! Tests that well known ReDoS patterns don't crash Patterns

		[TestMethod]
		public void ReDoS1() { // (a+)+
			Pattern Pattern = +(+(Pattern)'a');
			Assert.AreEqual("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Pattern.Consume("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
		}

		[TestMethod]
		public void ReDoS2() { // ([a-zA-Z]+)*
			Pattern Pattern = -+(+Pattern.Letter);
			Assert.AreEqual("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Pattern.Consume("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
		}

		[TestMethod]
		public void ReDoS3() { // (a|aa)+
			Pattern Pattern = +((Pattern)'a' | "aa");
			Assert.AreEqual("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Pattern.Consume("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
		}

		[TestMethod]
		public void ReDoS4() { // (a|a?)+
			Assert.ThrowsException<PatternConstructionException>(() => +((Pattern)'a' | -(Pattern)'a'));
		}

		[TestMethod]
		public void ReDoS5() { // (.*a){x} | for x > 10
			Pattern Pattern = (-+Pattern.Any & 'a') * 11;
			Assert.AreEqual("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Pattern.Consume("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
		}
	}
}
