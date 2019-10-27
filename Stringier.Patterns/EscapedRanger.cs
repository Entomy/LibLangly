namespace System.Text.Patterns {
	internal sealed class EscapedRanger : Ranger, IEquatable<EscapedRanger> {
		internal readonly Node Escape;

		internal EscapedRanger(Node From, Node To, Node Escape) : base(From, To) {
			this.Escape = Escape;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			From.Consume(ref Source, ref Result);
			if (!Result) {
				Result.Error.Set(ErrorType.ConsumeFailed, From);
				return;
			}
			To.Consume(ref Source, ref Result);
			while (!Result) {
				if (Source.EOF) {
					break;
				}
				Source.Position++;
				Result.Length++;
				//Check for the escape before checking for the end of the range
				if (Escape.CheckHeader(ref Source)) {
					Escape.Consume(ref Source, ref Result);
					Result.Error.Set(ErrorType.ConsumeFailed, To); //We need an error to continue the loop, and this is the current error
				}
				if (To.CheckHeader(ref Source)) {
					To.Consume(ref Source, ref Result);
				}
			}
			if (!Result) {
				Result.Error.Set(ErrorType.EndOfSource, To);
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => base.Neglect(ref Source, ref Result);

		public override Boolean Equals(Node node) {
			switch (node) {
			case EscapedRanger other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(EscapedRanger other) => From.Equals(other.From) && To.Equals(other.To) && Escape.Equals(other.Escape);

		public override Int32 GetHashCode() => base.GetHashCode() ^ Escape.GetHashCode();

		public override String ToString() => $"from=({From}) to=({To}) escape=({Escape})";
	}
}
