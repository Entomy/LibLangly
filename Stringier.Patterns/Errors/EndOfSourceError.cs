namespace System.Text.Patterns {
	internal sealed class EndOfSourceError : Error {
		private readonly String expected;

		internal EndOfSourceError(Char Expected) {
			expected = Expected.ToString();
		}

		internal EndOfSourceError(String Expected) {
			expected = Expected;
		}

		internal override void Throw() => throw new EndOfSourceException($"End of source has been reached before able to parse. Expected: {expected}");
	}
}
