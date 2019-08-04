namespace System.Text.Patterns {
	/// <summary>
	/// Represents a combinator pattern
	/// </summary>
	internal sealed class Combinator : Node, IEquatable<Combinator> {
		private readonly Node Left;

		private readonly Node Right;

		internal Combinator(Node Left, Node Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal Combinator(Pattern Left, Pattern Right) : this(Left.Head, Right.Head) { }

		/// <summary>
		/// The maximum length possibly matched by this pattern
		/// </summary>
		internal override Int64 MaxLength => Left.MaxLength + Right.MaxLength;

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			//? This is almost certainly inefficient; we should probably calculate the range and slice from Source instead
			StringBuilder CaptureBuilder = new StringBuilder();
			Result Result = Left.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			CaptureBuilder.Append((String)Result);
			Result = Right.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			CaptureBuilder.Append((String)Result);
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			return new Result(CaptureBuilder.ToString(), Result);
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Combinator Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(Combinator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public override String ToString() => Left.ToString() + Right.ToString();
	}
}
