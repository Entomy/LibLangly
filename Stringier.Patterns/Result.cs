namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations. There are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.
	/// </summary>
	public ref struct Result {
		private readonly ReadOnlySpan<Char> Capture;

		public Result(ReadOnlySpan<Char> Capture) {
			this.Capture = Capture;
		}

		public Result(String Capture) {
			this.Capture = Capture.AsSpan();
		}

		public static implicit operator Boolean(Result Result) => Result.Capture.Length > 0;

		public static implicit operator String(Result Result) => Result.Capture.ToString();

		public override String ToString() => Capture.ToString();

	}
}
