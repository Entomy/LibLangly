namespace System.Text.Patterns {
	/// <summary>
	/// Represents an alternator pattern
	/// </summary>
	public sealed class Alternator : Pattern, IEquatable<Alternator> {
		private readonly Pattern Left;

		private readonly Pattern Right;

		internal Alternator(Pattern Left, Pattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		public override Result Consume(Result Candidate) => Consume(Candidate, out _);

		public override Result Consume(Result Candidate, out String Capture) {
			Result Result = Left.Consume(Candidate, out Capture);
			return Result ? Result : Right.Consume(Candidate, out Capture);
		}

		public override Boolean Equals(String other) => Left.Equals(other) || Right.Equals(other);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Alternator Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public Boolean Equals(Alternator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() | Right.GetHashCode();

		public override String ToString() => $"{Left} | {Right}";
	}
}
