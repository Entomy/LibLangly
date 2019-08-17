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
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result;
			// Try consuming the left side
			Result = Left.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			// Try consuming the right side
			Result = Right.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
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

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public override Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result;
			// Try consuming the left side
			Result = Left.Neglect(ref Source);
			if (!Result) { goto Cleanup; }
			// Try consuming the right side
			Result = Right.Neglect(ref Source);
			if (!Result) { goto Cleanup; }
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Left.ToString() + Right.ToString();
	}
}
