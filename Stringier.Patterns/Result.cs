namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations
	/// </summary>
    public readonly struct Result : IEquatable<Result> {

		private readonly Boolean Success;

		private readonly String Remaining;

		public static implicit operator Boolean(Result Result) => Result.Success;

		public static implicit operator String(Result Result) => Result.Remaining;

		public static implicit operator Result(String String) => new Result(true, String);

		public Result(Boolean Success, String Remaining) {
			this.Success = Success;
			this.Remaining = Remaining;
		}

		public Boolean Equals(Result other) => Success.Equals(other.Success) && Remaining.Equals(other.Remaining);
	}
}
