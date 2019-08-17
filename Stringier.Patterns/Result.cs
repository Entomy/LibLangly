namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations. There are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.
	/// </summary>
	public ref struct Result {
		internal Boolean Success;

		private readonly ReadOnlySpan<Char> Capture;

		public Result(ReadOnlySpan<Char> Capture) {
			this.Success = true;
			this.Capture = Capture;
		}

		public Result(ReadOnlySpan<Char> Capture, Boolean Success) {
			this.Success = Success;
			this.Capture = Capture;
		}

		public Result(String Capture) {
			this.Success = true;
			this.Capture = Capture.AsSpan();
		}

		public Result(String Capture, Boolean Success) {
			this.Success = Success;
			this.Capture = Capture.AsSpan();
		}

		public Char this[Int32 Index] => Capture[Index];

		public Int32 Length => Capture.Length;

		public static implicit operator Boolean(Result Result) => Result.Success;

		public static implicit operator String(Result Result) => Result.Capture.ToString();

		public static implicit operator Source(Result Result) => new Source(Result.Capture);

		public override String ToString() => Capture.ToString();

	}
}
