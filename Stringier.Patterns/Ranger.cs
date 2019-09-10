namespace System.Text.Patterns {
	internal class Ranger : Pattern, IEquatable<Ranger> {
		internal protected readonly Pattern From;
		internal protected readonly Pattern To;

		internal protected Ranger(Pattern From, Pattern To) {
			this.From = From;
			this.To = To;
		}

		internal override Boolean CheckHeader(ref Source Source) => From.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			From.Consume(ref Source, ref Result);
			if (!Result) {
				Result.Error = new ConsumeFailedError(Expected: From.ToString());
				return;
			}
			To.Consume(ref Source, ref Result);
			while (!Result) {
				if (Source.EOF) { break; }
				Source.Position++;
				Result.Length++;
				if (To.CheckHeader(ref Source)) { To.Consume(ref Source, ref Result); }
			}
			if (!Result) {
				Result.Error = new EndOfSourceError(Expected: To.ToString());
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new NotImplementedException();

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

		public Boolean Equals(Ranger other) => From.Equals(other.From) && To.Equals(other.To);

		public override Int32 GetHashCode() => From.GetHashCode() ^ To.GetHashCode();

		public override String ToString() => $"from=({From}) to=({To})";

		#region Negator

		internal override Pattern Negate() => throw new PatternConstructionException("Ranges can not be negated, as there is no valid concept to describe this behavior");

		#endregion
	}
}
