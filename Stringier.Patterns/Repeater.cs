namespace System.Text.Patterns {
	/// <summary>
	/// Represents a repeater pattern
	/// </summary>
	public sealed class Repeater : Pattern, IEquatable<Repeater> {

		private readonly Pattern Pattern;

		private readonly Int32 Count;

		internal Repeater(Pattern Pattern, Int32 Count) {
			this.Pattern = Pattern;
			this.Count = Count;
		}

		public override Result Consume(String Candidate) {
			Result Result = new Result(true, Candidate);
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(Result);
			}
			return Result;
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

		public override Boolean Equals(String Other) {
			Result Result = new Result(true, Other);
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(Result);
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
