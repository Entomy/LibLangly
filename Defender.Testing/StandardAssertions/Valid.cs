using System;
using System.Linq;
using FastEnumUtility;

namespace Defender {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that this enumeration instance is a valid <typeparamref name="T"/> value..
		/// </summary>
		/// <typeparam name="T">The type of the enumeration.</typeparam>
		/// <param name="assert">This <see cref="Asserter{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Asserter<T> Valid<T>(this Asserter<T> assert) where T : struct, Enum {
			if (!FastEnum.IsDefined(assert.Actual)) {
				throw new AssertException($"The instance was not valid.\nActual: {assert.Actual}\nExpected one of: {FastEnum.GetNames<T>().Aggregate((total, next) => total + ", " + next)}");
			}
			return assert;
		}
	}
}
