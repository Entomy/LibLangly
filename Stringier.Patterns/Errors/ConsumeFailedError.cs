namespace System.Text.Patterns {
	internal sealed class ConsumeFailedError : Error {
		private readonly String expected;
		private readonly String actual;

		internal ConsumeFailedError(Char Expected, Char Actual) {
			expected = Expected.ToString();
			actual = Actual.ToString();
		}

		internal ConsumeFailedError(String Expected, Char Actual) {
			expected = Expected;
			actual = Actual.ToString();
		}

		internal ConsumeFailedError(Char Expected, String Actual) {
			expected = Expected.ToString();
			actual = Actual;
		}

		internal ConsumeFailedError(String Expected, String Actual) {
			expected = Expected;
			actual = Actual;
		}

		internal ConsumeFailedError(String Expected, ReadOnlySpan<Char> Actual) {
			expected = Expected;
			actual = Actual.ToString();
		}

		internal ConsumeFailedError(ReadOnlySpan<Char> Expected, String Actual) {
			expected = Expected.ToString();
			actual = Actual;
		}

		internal ConsumeFailedError(ReadOnlySpan<Char> Expected, ReadOnlySpan<Char> Actual) {
			expected = Expected.ToString();
			actual = Actual.ToString();
		}

		internal override void Throw() => throw new ConsumeFailedException($"Consume failed. Expected: {expected}. Actual: {actual}.");
	}
}
