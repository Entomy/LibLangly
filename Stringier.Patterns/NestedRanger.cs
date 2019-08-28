namespace System.Text.Patterns {
	internal sealed class NestedRanger : Ranger, IEquatable<NestedRanger> {
		private Int32 Level;

		internal NestedRanger(INode From, INode To) : base(From, To) {
			Level = 0;
		}

		internal NestedRanger(Pattern From, Pattern To) : base(From, To) {
			Level = 0;
		}

		public override Result Consume(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			if (From.Consume(ref Source)) {
				Level++;
			}
			while (Level > 0) {
				if (Source.EOF) { goto Cleanup; } //If we're already at the end, abort
				Source.Position++;
				if (From.Consume(ref Source)) { Level++; }
				if (To.Consume(ref Source)) { Level--; }
			}
			goto Done;
		Cleanup:
			Source.Position = OriginalPosition;
		Done:
			Int32 FinalPosition = Source.Position;
			Source.Position = OriginalPosition;
			return new Result(Source.Read(FinalPosition - OriginalPosition), Level == 0);
		}

		public Boolean Equals(NestedRanger other) => base.Equals(other);

		public override Result Neglect(ref Source Source) => throw new NotImplementedException();
	}
}