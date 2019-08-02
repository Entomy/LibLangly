namespace System.Text.Patterns {
	/// <summary>
	/// Represents a repeater pattern
	/// </summary>
	internal sealed class Repeater : Node, IEquatable<Repeater> {

		private readonly Node Pattern;

		private readonly Int32 Count;

		internal Repeater(Node Pattern, Int32 Count) {
			this.Pattern = Pattern;
			this.Count = Count;
		}

		internal Repeater(Pattern Pattern, Int32 Count) : this(Pattern.Head, Count) { }

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			StringBuilder CaptureBuilder = new StringBuilder();
			for (Int32 i = 0; i < Count; i++) {
				CaptureBuilder.Append((String)Pattern.Consume(ref Source));
			}
			return new Result(CaptureBuilder.ToString().AsSpan());
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Repeater Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result();
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
			}
			return Result;
		}

		public Boolean Equals(Repeater other) => Pattern.Equals(other.Pattern) && Count.Equals(other.Count);

		public override Int32 GetHashCode() => Pattern.GetHashCode() ^ Count.GetHashCode();

		public override String ToString() {
			StringBuilder Result = new StringBuilder();
			for (Int32 i = 0; i < Count; i++) {
				Result.Append(Pattern);
			}
			return Result.ToString();
		}
	}
}
