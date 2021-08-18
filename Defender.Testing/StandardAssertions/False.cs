using System;

namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the expression evaluated to <see langword="false"/>.
		/// </summary>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<Boolean> False(this Asserter<Boolean> assert) {
			if (assert.Actual) {
				throw new AssertException($"The expression was expected to be false, but was true.");
			}
			return assert;
		}
	}
}
