using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the expression evaluated to <see langword="false"/>.
		/// </summary>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Boolean> False(this Assert<Boolean> assert) {
			if (assert.Actual) {
				throw new AssertException($"The expression was expected to be false, but was true.");
			}
			return assert;
		}

		/// <summary>
		/// Asserts that the expression evaluated to <see langword="false"/>.
		/// </summary>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Boolean> False(this Assert<Boolean> assert, [DisallowNull] String additionalMessage) {
			if (assert.Actual) {
				throw new AssertException($"The expression was expected to be false, but was true.\n{additionalMessage}");
			}
			return assert;
		}
	}
}
