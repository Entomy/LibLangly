namespace System.Text.Patterns {
	internal sealed class ConsumeFailedError : Error {
		private readonly String expected;

		internal ConsumeFailedError(Char Expected) {
			expected = Expected.ToString();
		}

		internal ConsumeFailedError(String Expected) {
			expected = Expected;
		}

		internal ConsumeFailedError(ReadOnlySpan<Char> Expected) {
			expected = Expected.ToString();
		}

		internal override void Throw() => throw new ConsumeFailedException($"Consume failed. Expected: {expected}.");
	}
}
