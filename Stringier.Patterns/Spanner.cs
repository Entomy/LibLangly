namespace System.Text.Patterns {
	internal sealed class Spanner : IComplexNode, IEquatable<Spanner> {
		private readonly INode Pattern;

		internal Spanner(INode Pattern) => this.Pattern = Pattern;

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
			case Spanner other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(Spanner other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

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

		public override String ToString() => $"+{Pattern}";
	}
}
