namespace System.Text.Patterns {
	/// <summary>
	/// Represents an alternator pattern
	/// </summary>
	internal sealed class Alternator : Node, IEquatable<Alternator> {
		private readonly Node Left;

		private readonly Node Right;

		internal Alternator(Node Left, Node Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal Alternator(Pattern Left, Pattern Right) : this(Left.Head, Right.Head) { }

		/// <summary>
		/// The maximum length possibly matched by this pattern
		/// </summary>
		internal override Int32 MaxLength => Left.MaxLength >= Right.MaxLength ? Left.MaxLength : Right.MaxLength;

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

		/// <summary>
		/// Attempt to span the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Span(ref Source Source) => throw new NotImplementedException();

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
