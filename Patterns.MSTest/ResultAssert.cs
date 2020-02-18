using System;
using Stringier.Patterns;

namespace Microsoft.VisualStudio.TestTools.UnitTesting {
	/// <summary>
	/// A collection of helper classes to test various conditions associated with <see cref="Result"/> within unit tests. If the condition being tested is not met, an exception is thrown.
	/// </summary>
	public static class ResultAssert {

		/// <summary>
		/// Tests whether the parser <see cref="Result"/> failed.
		/// </summary>
		/// <param name="actual">The parser <see cref="Result"/>.</param>
		public static void Fails(Result actual) {
			if (actual) {
				throw new AssertFailedException($"ResultAssert.Fails failed. Parser succeeded when expected to fail");
			}
		}

		/// <summary>
		/// Tests whether the specied <paramref name="actual"/> result is what was <paramref name="expected"/>.
		/// </summary>
		/// <param name="expected">The <see cref="String"/> of expected text.</param>
		/// <param name="actual">The parser <see cref="Result"/>.</param>
		public static void Captures(String expected, Result actual) {
			if (expected is null) {
				throw new ArgumentNullException(nameof(expected));
			}
			actual.ThrowException();
			if (expected != actual) {
				throw new AssertFailedException($"ResultAssert.Captures failed. Expected: <{expected}>. Actual: <{(String)actual}>.");
			}
		}

		/// <summary>
		/// Tests whether the parser <see cref="Result"/> succeeded.
		/// </summary>
		/// <param name="actual">The parser <see cref="Result"/>.</param>
		public static void Succeeds(Result actual) => actual.ThrowException();
	}
}
