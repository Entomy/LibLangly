using System;
using System.Text.Patterns;

namespace Microsoft.VisualStudio.TestTools.UnitTesting {
	/// <summary>
	/// A collection of helper classes to test various conditions associated with <see cref="Capture"/> within unit tests. If the condition being tested is not met, an exception is thrown.
	/// </summary>
	public static class CaptureAssert {
		/// <summary>
		/// Tests whether the specified <paramref name="Actual"/> capture is what was <paramref name="Expected"/>.
		/// </summary>
		/// <param name="Expected">The <see cref="String"/> of expected text.</param>
		/// <param name="Actual">The <see cref="Capture"/> object.</param>
		public static void Captures(String Expected, Capture Actual) {
			if (!Actual.Equals(Expected)) {
				throw new AssertFailedException($"CaptureAssert.Captures failed. Expected: <{Expected}>. Actual: <{Actual}>.");
			}
		}
	}
}
