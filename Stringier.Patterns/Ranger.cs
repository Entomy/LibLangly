namespace System.Text.Patterns {
	internal class Ranger : ComplexPattern, IEquatable<Ranger> {
		internal protected readonly Pattern From;
		internal protected readonly Pattern To;

		internal protected Ranger(Pattern From, Pattern To) {
			this.From = From;
			this.To = To;
		}

		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = From.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			Result = To.Consume(ref Source);
			while (!Result) {
				if (Source.EOF) { goto Cleanup; } //If we're already at the end, abort
				Source.Position++;
				Result = To.Consume(ref Source);
			}
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
			case Ranger other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => throw new NotImplementedException();

		public override Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(Ranger other) => From.Equals(other.From) && To.Equals(other.To);

		public override Int32 GetHashCode() => From.GetHashCode() ^ To.GetHashCode();

		protected internal override Result Neglect(ref Source Source) => throw new NotImplementedException();

		public override String ToString() => $"from=({From}) to=({To})";
	}
}
