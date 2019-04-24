namespace System.Text.Patterns {
	/// <summary>
	/// Represents a spanner pattern
	/// </summary>
	public sealed class Spanner : Pattern, IEquatable<Spanner> {
		private readonly Pattern Pattern;

		internal Spanner(Pattern Pattern) => this.Pattern = Pattern;

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public override Result Consume(Result Candidate) => Consume(Candidate, out _);

		/// <summary>
		/// Attempt to consume the <paramref name="Pattern"/> from the <paramref name="Candidate"/>
		/// </summary>
		/// <param name="Pattern">The <see cref="String"/> to match</param>
		/// <param name="Candidate">The <see cref="String"/> to consume</param>
		/// <param name="Consumed">The <see cref="String"/> that was consumed, empty if not matched</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the remaining string</returns>
		public override Result Consume(Result Candidate, out String Capture) {
			StringBuilder CaptureBuilder = new StringBuilder();
			String capture;
			Result Result = Candidate;
			while (Result) {
				Result = Pattern.Consume(Result, out capture);
				CaptureBuilder.Append(capture);
			}
			Capture = CaptureBuilder.ToString();
			return Result;
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
