using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Text.Patterns {
	public static class AssertExtensions {

		public static void Fails(this Assert Assert, Result Actual) {
			if (Actual) { throw new AssertFailedException("Assert.That.Fails failed"); }
		}

		public static void Captures(this Assert Assert, String Expected, Result Actual) {
			if (Actual != Expected) {
				throw new AssertFailedException($"Assert.That.Captures failed. Expected: <{Expected}>. Actual: <{(String)Actual}>.");
			}
		}

		public static void Captures(this Assert Assert, String Expected, Capture Actual) {
			if (!Actual.Equals(Expected)) {
				throw new AssertFailedException($"Assert.That.Captures failed. Expected: <{Expected}>. Actual: <{Actual}>.");
			}
		}

		public static void Succeeds(this Assert Assert, Result Actual) {
			if (!Actual) { throw new AssertFailedException($"Assert.That.Succeeds failed."); }
		}
	}
}
