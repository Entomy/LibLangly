namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations. There are two main components. The first is a Boolean representing success of the operation. The second is the remaining string after the operation. This type can be used as if it is either individual type.
	/// </summary>
	public readonly struct Result : IEquatable<Result>, IEquatable<String> {
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

		public static Boolean operator !=(Result left, String right) => !left.Equals(right);

		public static Boolean operator !=(String left, Result right) => !right.Equals(left);

		public static Boolean operator ==(Result left, Result right) => left.Equals(right);

		public static Boolean operator ==(Result left, String right) => left.Equals(right);

		public static Boolean operator ==(String left, Result right) => right.Equals(left);

		public Boolean Equals(Result other) => Success.Equals(other.Success) && String.Equals(Remaining, other.Remaining, StringComparison.Ordinal);

		public Boolean Equals(String other) => String.Equals(Remaining, other, StringComparison.InvariantCulture);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case String Other:
				return Equals(Other);
			case Result Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Int32 GetHashCode() => Remaining.GetHashCode() ^ Success.GetHashCode();
	}
}
