using System;
using System.Text.Patterns;

namespace Microsoft.VisualStudio.TestTools.UnitTesting {
	/// <summary>
	/// A collection of helper classes to test various conditions associated with <see cref="Result"/> within unit tests. If the condition being tested is not met, an exception is thrown.
	/// </summary>
	public static class ResultAssert {

		/// <summary>
		/// Tests whether the parser <see cref="Result"/> failed.
		/// </summary>
		/// <param name="Actual">The parser <see cref="Result"/>.</param>
		public static void Fails(Result Actual) {
			if (Actual) { throw new AssertFailedException(); }
		}

		/// <summary>
		/// Tests whether the specied <see cref="Actual"/> result is what was <paramref name="Expected"/>.
		/// </summary>
		/// <param name="Expected">The <see cref="String"/> of expected text.</param>
		/// <param name="Actual">The parser <see cref="Result"/>.</param>
		public static void Captures(String Expected, Result Actual) {
			if (Expected is null) { throw new ArgumentNullException(nameof(Expected)); }
			Actual.ThrowException();
			if (Expected != Actual) {
				throw new AssertFailedException($"ResultAssert.Captures failed. Expected: <{Expected}>. Actual: <{(String)Actual}>.");
			}
		}

		/// <summary>
		/// Tests whether the parser <see cref="Result"/> succeeded.
		/// </summary>
		/// <param name="Actual">The parser <see cref="Result"/>.</param>
		public static void Succeeds(Result Actual) {
			Actual.ThrowException();
		}
	}
}
