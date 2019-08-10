using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	internal static class AssertExtensions {

		public static void Fails(this Assert Assert, Result Actual) {
			if (Actual) { throw new AssertFailedException("ResultAssert.Fails failed"); }
		}

		public static void Captures(this Assert Assert, String Expected, Result Actual) {
			if (Actual != Expected) {
				throw new AssertFailedException($"ResultAssert.Captures failed. Expected: <{Expected}>. Actual: <{(String)Actual}>.");
			}
		}

		public static void Succeeds(this Assert Assert, Result Actual) {
			if (!Actual) { throw new AssertFailedException("ResultAssert.Succeeds failed."); }
		}
	}
}
