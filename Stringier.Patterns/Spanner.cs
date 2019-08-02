namespace System.Text.Patterns {
	/// <summary>
	/// Represents a spanner pattern
	/// </summary>
	internal sealed class Spanner : Node, IEquatable<Spanner> {
		private readonly Node Pattern;

		internal Spanner(Node Pattern) => this.Pattern = Pattern;

		internal Spanner(Pattern Pattern) : this(Pattern.Head) { }

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			StringBuilder CaptureBuilder = new StringBuilder();
			Result Result = new Result(" ");
			while (Result) {
				Result = Pattern.Consume(ref Source);
				if (!Result) { goto Done; }
				CaptureBuilder.Append((String)Result);
			}
		Done:
			return new Result(CaptureBuilder.ToString());
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

		public override Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(Spanner other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		public override String ToString() => Pattern.ToString();
	}
}
