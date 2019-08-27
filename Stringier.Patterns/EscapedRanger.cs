namespace System.Text.Patterns {
	internal sealed class EscapedRanger : Ranger, IEquatable<EscapedRanger> {
		internal readonly INode Escape;

		internal EscapedRanger(INode From, INode To, INode Escape) : base(From, To) {
			this.Escape = Escape;
		}

		internal EscapedRanger(Pattern From, Pattern To, Pattern Escape) : base(From, To) {
			switch (Escape) {
			case ComplexPattern escape:
				this.Escape = escape.Head;
				break;
			case PrimativePattern escape:
				this.Escape = escape.Head;
				break;
			default:
				throw new ArgumentException("Pattern type wasn't handled", nameof(Escape));
			}
		}

		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = From.Consume(ref Source);
			if (!Result) { goto Cleanup; }
			Result = To.Consume(ref Source);
			while (!Result) {
				if (Source.EOF) { goto Cleanup; } //If we're already at the end, abort
				Source.Position++;
				if (!(Escape is null)) { Escape.Consume(ref Source); } //If an escape is defined, check for it now and advance if found, before checking the end of the range
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
			case EscapedRanger other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(EscapedRanger other) => From.Equals(other.From) && To.Equals(other.To) && Escape.Equals(other.Escape);

		public override Int32 GetHashCode() => base.GetHashCode() ^ Escape.GetHashCode();

		public override Result Neglect(ref Source Source) => throw new NotImplementedException();

		public override String ToString() => $"from=({From}) to=({To}) escape=({Escape})";
	}
}
