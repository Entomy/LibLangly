namespace System.Text.Patterns {
	internal sealed class NeglectFailedError : Error {
		private readonly String expected;
		private readonly String actual;

		internal NeglectFailedError(Char Expected, Char Actual) {
			expected = Expected.ToString();
			actual = Actual.ToString();
		}

		internal NeglectFailedError(String Expected, Char Actual) {
			expected = Expected;
			actual = Actual.ToString();
		}

		internal NeglectFailedError(Char Expected, String Actual) {
			expected = Expected.ToString();
			actual = Actual;
		}

		internal NeglectFailedError(String Expected, String Actual) {
			expected = Expected;
			actual = Actual;
		}

		internal NeglectFailedError(String Expected, ReadOnlySpan<Char> Actual) {
			expected = Expected;
			actual = Actual.ToString();
		}

		internal NeglectFailedError(ReadOnlySpan<Char> Expected, String Actual) {
			expected = Expected.ToString();
			actual = Actual;
		}

		internal NeglectFailedError(ReadOnlySpan<Char> Expected, ReadOnlySpan<Char> Actual) {
			expected = Expected.ToString();
			actual = Actual.ToString();
		}


		internal override void Throw() => throw new ConsumeFailedException($"Neglect failed. Expected: {expected}. Actual: {actual}.");
	}
}
