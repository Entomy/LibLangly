namespace System.Text.Patterns {
	internal sealed class NeglectFailedError : Error {
		internal NeglectFailedError(Char Neglected) : base(Neglected.ToString()) { }

		internal NeglectFailedError(String Neglected) : base(Neglected) { }

		internal NeglectFailedError(ReadOnlySpan<Char> Neglected) : base(Neglected.ToString()) { }

		internal NeglectFailedError(Pattern Neglected) : base(Neglected.ToString()) { }

		internal override void Throw() => throw new ConsumeFailedException($"Neglect failed. Neglected: {@string}.");
	}
}
