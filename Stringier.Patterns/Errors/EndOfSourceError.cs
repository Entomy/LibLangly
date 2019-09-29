namespace System.Text.Patterns {
	internal sealed class EndOfSourceError : Error {
		internal EndOfSourceError(Char Expected) : base(Expected.ToString()) { }

		internal EndOfSourceError(String Expected) : base(Expected) { }

		internal EndOfSourceError(Pattern Expected) : base(Expected.ToString()) { }

		internal override void Throw() => throw new EndOfSourceException($"End of source has been reached before able to parse. Expected: {@string}");
	}
}
