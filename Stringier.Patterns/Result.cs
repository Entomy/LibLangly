namespace System.Text.Patterns {
	/// <summary>
	/// Represents the result value of parsing operations. There are two main components. The first is a Boolean representing success of the operation. The second is the captured string during the operation. This type can be used as if it is either individual type.
	/// </summary>
	public readonly struct Result : IEquatable<Result>, IEquatable<String>, IEquatable<Boolean> {
		private readonly String Capture;

		public Result(String Capture) {
			this.Capture = Capture;
		}

		public static implicit operator Boolean(Result Result) => !String.IsNullOrEmpty(Result);

		public static implicit operator String(Result Result) => Result.Capture;

		public static Boolean operator !=(Result left, Result right) => !left.Equals(right);

		public static Boolean operator !=(Result left, String right) => !left.Equals(right);

		public static Boolean operator !=(String left, Result right) => !right.Equals(left);

		public static Boolean operator ==(Result left, Result right) => left.Equals(right);

		public static Boolean operator ==(Result left, String right) => left.Equals(right);

		public static Boolean operator ==(String left, Result right) => right.Equals(left);

		public Boolean Equals(Result other) => String.Equals(Capture, other.Capture, StringComparison.Ordinal);

		public Boolean Equals(String other) => String.Equals(Capture, other, StringComparison.InvariantCulture);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Boolean Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			case Result Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public Boolean Equals(Boolean other) => other.Equals(!String.IsNullOrEmpty(Capture));

		public override Int32 GetHashCode() => Capture.GetHashCode();
	}
}
