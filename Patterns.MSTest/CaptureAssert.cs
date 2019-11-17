using System;
using Stringier.Patterns;

namespace Microsoft.VisualStudio.TestTools.UnitTesting {
	/// <summary>
	/// A collection of helper classes to test various conditions associated with <see cref="Capture"/> within unit tests. If the condition being tested is not met, an exception is thrown.
	/// </summary>
	public static class CaptureAssert {
		/// <summary>
		/// Tests whether the specified <paramref name="actual"/> capture is what was <paramref name="expected"/>.
		/// </summary>
		/// <param name="expected">The <see cref="String"/> of expected text.</param>
		/// <param name="actual">The <see cref="Capture"/> object.</param>
		public static void Captures(String expected, Capture actual) {
			if (expected is null || actual is null) {
				throw new ArgumentNullException(expected is null ? nameof(expected) : nameof(actual));
			}
			if (!actual.Equals(expected)) {
				throw new AssertFailedException($"CaptureAssert.Captures failed. Expected: <{expected}>. Actual: <{actual}>.");
			}
		}

		/// <summary>
		/// Tests whether the specified <paramref name="actual"/> capture is what was <paramref name="expected"/>.
		/// </summary>
		/// <remarks>
		/// This variation exists primarily to offer cleaner syntax to languages (like F#) where Capture is being kept at as a ref cell, or similar.
		/// </remarks>
		/// <param name="expected">The <see cref="String"/> of expected text.</param>
		/// <param name="actual">The <see cref="Capture"/> object.</param>
		public static void Captures(String expected, ref Capture actual) {
			if (expected is null || actual is null) {
				throw new ArgumentNullException(expected is null ? nameof(expected) : nameof(actual));
			}
			if (!actual.Equals(expected)) {
				throw new AssertFailedException($"CaptureAssert.Captures failed. Expected: <{expected}>. Actual: <{actual}>.");
			}
		}
	}
}
