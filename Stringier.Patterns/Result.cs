namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations
	/// </summary>
	public readonly struct Result : IEquatable<Result> {
		private readonly String Remaining;

		private readonly Boolean Success;

		public Result(Boolean Success, String Remaining) {
			this.Success = Success;
			this.Remaining = Remaining;
		}

		public static implicit operator Boolean(Result Result) => Result.Success;

		public static implicit operator Result(String Remaining) => new Result(true, Remaining);

		public static implicit operator String(Result Result) => Result.Remaining;

		public static Boolean operator !=(Result left, Result right) => !left.Equals(right);

		public static Boolean operator ==(Result left, Result right) => left.Equals(right);

		public Boolean Equals(Result other) => Success.Equals(other.Success) && String.Equals(Remaining, other.Remaining, StringComparison.InvariantCulture);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Result Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Int32 GetHashCode() => Remaining.GetHashCode() ^ Success.GetHashCode();
	}
}
