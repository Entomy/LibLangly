namespace System.Text.Patterns {
	internal sealed class ComplexRepeater : ComplexPattern, IEquatable<ComplexRepeater> {
		private readonly Int32 Count;

		private readonly Pattern Pattern;

		internal ComplexRepeater(Pattern Pattern, Int32 Count) {
			this.Pattern = Pattern;
			this.Count = Count;
		}

		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = new Result("", false);
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
				if (!Result) { goto Cleanup; }
			}
			// Skip cleanup
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
			case ComplexRepeater other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result();
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
			}
			if (Source.Length != 0) { return false; }
			return Result;
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result();
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Consume(ref Source);
			}
			if (Source.Length != 0) { return false; }
			return Result;
		}

		public Boolean Equals(ComplexRepeater other) => Pattern.Equals(other.Pattern) && Count.Equals(other.Count);

		public override Int32 GetHashCode() => Pattern.GetHashCode() ^ Count.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = new Result("", false);
			for (Int32 i = 0; i < Count; i++) {
				Result = Pattern.Neglect(ref Source);
				if (!Result) { goto Cleanup; }
			}
			// Skip cleanup
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Result);
		}

		public override String ToString() => $"{Pattern}×{Count}";
	}
}
