namespace System.Text.Patterns {
	internal class Ranger : Node, IEquatable<Ranger> {
		internal protected readonly Node From;
		internal protected readonly Node To;

		internal protected Ranger(Node From, Node To) {
			this.From = From;
			this.To = To;
		}

		internal override Boolean CheckHeader(ref Source Source) => From.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			From.Consume(ref Source, ref Result);
			if (!Result) {
				Result.Error.Set(ErrorType.ConsumeFailed, From);
				return;
			}
			To.Consume(ref Source, ref Result);
			while (!Result) {
				if (Source.EOF) { break; }
				Source.Position++;
				Result.Length++;
				if (To.CheckHeader(ref Source)) {
					To.Consume(ref Source, ref Result);
				}
			}
			if (!Result) {
				Result.Error.Set(ErrorType.EndOfSource, To);
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new NotSupportedException();

		public override Boolean Equals(Node node) {
			switch (node) {
			case Ranger other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Ranger other) => From.Equals(other.From) && To.Equals(other.To);

		public override Int32 GetHashCode() => From.GetHashCode() ^ To.GetHashCode();

		public override String ToString() => $"from=({From}) to=({To})";

		#region Negator

		internal override Node Negate() => throw new PatternConstructionException("Ranges can not be negated, as there is no valid concept to describe this behavior");

		#endregion
	}
}
