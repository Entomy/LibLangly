namespace System.Text.Patterns {
	/// <summary>
	/// Represents a spanner pattern
	/// </summary>
	internal sealed class Spanner : IComplexNode, IEquatable<Spanner> {
		private readonly INode Pattern;

		internal Spanner(INode Pattern) => this.Pattern = Pattern;

		internal Spanner(Pattern Pattern) : this(Pattern.Head) { }

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = new Result("", true);
			while (Result) {
				Result = Pattern.Consume(ref Source);
			}
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			Boolean Success = FinalPosition - OriginalPosition > 0;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Success);
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Spanner Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(Spanner other) => Pattern.Equals(other.Pattern);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Pattern.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = new Result("", true);
			while (Result) {
				Result = Pattern.Neglect(ref Source);
			}
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Pattern.ToString();
	}
}