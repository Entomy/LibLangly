using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	internal static class ResultAssert {

		public static void Fails(Result Actual) {
			if (Actual) { throw new AssertFailedException("ResultAssert.Fails failed"); }
		}

		public static void Captures(String Expected, Result Actual) {
			if (Actual != Expected) {
				throw new AssertFailedException($"ResultAssert.Captures failed. Expected: <{Expected}>. Actual: <{(String)Actual}>.");
			}
		}

		public static void Succeeds(Result Actual) {
			if (!Actual) { throw new AssertFailedException("ResultAssert.Succeeds failed."); }
		}
	}
}
