namespace System.Text.Patterns {
	/// <summary>
	/// Represents a combinator pattern
	/// </summary>
	public sealed class Combinator : Pattern, IEquatable<Combinator> {
		private readonly Pattern Left;

		private readonly Pattern Right;

		internal Combinator(Pattern Left, Pattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			//? This is almost certainly inefficient; we should probably calculate the range and slice from Source instead
			StringBuilder CaptureBuilder = new StringBuilder();
			Result Result = Left.Consume(ref Source);
			if (!Result) { goto Done; }
			CaptureBuilder.Append((String)Result);
			Result = Right.Consume(ref Source);
			if (!Result) { goto Done; }
			CaptureBuilder.Append((String)Result);
		Done:
			return new Result(CaptureBuilder.ToString());
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
