namespace System.Text.Patterns {
	internal sealed class Spanner : ComplexPattern, IEquatable<Spanner> {
		private readonly Pattern Pattern;

		internal Spanner(Pattern Pattern) => this.Pattern = Pattern;

		protected internal override Boolean CheckFirstChar(ref Source Source) => Pattern.CheckFirstChar(ref Source);

		public override Result Consume(ref Source Source) {
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

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result("", true);
			while (Result) {
				Result = Consume(ref Source);
				if (Source.Length == 0) { break; }
			}
			return Result;
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result("", true);
			while (Result) {
				Result = Consume(ref Source);
				if (Source.Length == 0) { break; }
			}
			return Result;
		}

		public Boolean Equals(Spanner other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
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
