namespace System.Text.Patterns {
	internal sealed class EscapedRanger : Ranger, IEquatable<EscapedRanger> {
		internal readonly Pattern Escape;

		internal EscapedRanger(Pattern From, Pattern To, Pattern Escape) : base(From, To) {
			this.Escape = Escape;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			From.Consume(ref Source, ref Result);
			if (!Result) {
				Result.Error = new ConsumeFailedError(Expected: From);
				return;
			}
			To.Consume(ref Source, ref Result);
			while (!Result) {
				if (Source.EOF) { break; }
				Source.Position++;
				Result.Length++;
				//Check for the escape before checking for the end of the range
				if (Escape.CheckHeader(ref Source)) {
					Escape.Consume(ref Source, ref Result);
					Result.Error = new ConsumeFailedError(Expected: To); //We need an error to continue the loop, and this is the current error
				} 
				if (To.CheckHeader(ref Source)) {
					To.Consume(ref Source, ref Result);
				}
			}
			if (!Result) {
				Result.Error = new EndOfSourceError(Expected: To);
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => base.Neglect(ref Source, ref Result);

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case EscapedRanger other:
				return Equals(other);
			case String other:
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
