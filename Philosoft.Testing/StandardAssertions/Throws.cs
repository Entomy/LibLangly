namespace System.Traits.Testing {
	public static partial class StandardAssertions {
		/// <summary>
		/// Asserts that the <see cref="Action"/> throws a <typeparamref name="TException"/>.
		/// </summary>
		/// <typeparam name="TException">The exception type that should be thrown.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Action> Throws<TException>(this Assert<Action> assert) where TException : Exception {
			try {
				assert.Actual();
			} catch (TException ex) {
				return assert;
			} catch (Exception ex) {
				throw new AssertException($"An exception was thrown but not what was expected.\nActual: {ex.GetType()}\nExpected: {typeof(TException)}", ex);
			}
			throw new AssertException($"An exception was not thrown.");
		}

		/// <summary>
		/// Asserts that the <see cref="Action"/> throws a <typeparamref name="TException"/>.
		/// </summary>
		/// <typeparam name="TException">The exception type that should be thrown.</typeparam>
		/// <param name="assert">This <see cref="Assert{T}"/>.</param>
		/// <param name="additionalMessage">Additional text to include in the failure message.</param>
		/// <returns>This <paramref name="assert"/>.</returns>
		public static Assert<Action> Throws<TException>(this Assert<Action> assert, String additionalMessage) where TException : Exception {
			try {
				assert.Actual();
			} catch (TException ex) {
				return assert;
			} catch (Exception ex) {
				throw new AssertException($"An exception was thrown but not what was expected.\nActual: {ex.GetType()}\nExpected: {typeof(TException)}\n{additionalMessage}", ex);
			}
			throw new AssertException($"An exception was not thrown.");
		}
	}
}
