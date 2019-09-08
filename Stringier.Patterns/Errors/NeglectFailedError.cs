namespace System.Text.Patterns {
	internal sealed class NeglectFailedError : Error {
		private readonly String neglected;

		internal NeglectFailedError(Char Neglected) {
			neglected = Neglected.ToString();
		}

		internal NeglectFailedError(String Neglected) {
			neglected = Neglected;
		}

		internal NeglectFailedError(ReadOnlySpan<Char> Neglected) {
			neglected = Neglected.ToString();
		}


		internal override void Throw() => throw new ConsumeFailedException($"Neglect failed. Neglected: {neglected}.");
	}
}
