namespace System.Text.Patterns {
	internal sealed class ConsumeFailedError : Error {

		internal ConsumeFailedError(Char Expected) : base(Expected.ToString()) { }

		internal ConsumeFailedError(String Expected) : base(Expected) { }

		internal ConsumeFailedError(ReadOnlySpan<Char> Expected) : base(Expected.ToString()) { }

		internal ConsumeFailedError(Pattern Expected) : base(Expected.ToString()) { }

		internal override void Throw() => throw new ConsumeFailedException($"Consume failed. Expected: {@string}.");
	}
}
