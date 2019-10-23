namespace System.Text.Patterns {
	internal sealed class Spanner : Pattern, IEquatable<Spanner> {
		private readonly Pattern Pattern;

		internal Spanner(Pattern Pattern) => this.Pattern = Pattern;

		internal override Boolean CheckHeader(ref Source Source) => Pattern.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			//Store the source position and result length, because backtracking has to be done on the entire span unit
			Int32 OriginalPosition = Source.Position;
			Int32 OriginalLength = Result.Length;
			//We need to confirm the pattern exists at least once
			Pattern.Consume(ref Source, ref Result);
			if (!Result) {
				//Backtrack
				Source.Position = OriginalPosition;
				Result.Length = OriginalLength;
				return;
			}
			//Now continue to consume as much as possible
			while (Result) {
				//Update the positions so we can backtrack this unit
				OriginalPosition = Source.Position;
				OriginalLength = Result.Length;
				//Try consuming
				Pattern.Consume(ref Source, ref Result);
				if (!Result) {
					//Before we break out, backtrack
					Source.Position = OriginalPosition;
					Result.Length = OriginalLength;
				}
			}
			Result.Error.Clear(); //As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			//We need to confirm the pattern exists at least once
			Pattern.Neglect(ref Source, ref Result);
			if (!Result) { return; }
			//Now continue to consume as much as possible
			while (Result) {
				Pattern.Neglect(ref Source, ref Result);
			}
			Result.Error.Clear(); //As long as the first pattern matched, this consume is successful; we just stop on the eventual fail
		}


		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Spanner other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Spanner other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		public override String ToString() => $"+╣{Pattern}║";
	}
}
