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

		/// <summary>
		/// Attempt to consume the <see cref="Alternator"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			Result Result = Left.Consume(ref Source);
			if (!Result) {
				Result = Right.Consume(ref Source);
			}
			return Result;
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
