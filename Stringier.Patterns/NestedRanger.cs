namespace System.Text.Patterns {
	internal sealed class NestedRanger : Ranger, IEquatable<NestedRanger> {
		private Int32 Level;

		internal NestedRanger(Pattern From, Pattern To) : base(From, To) {
			Level = 0;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			From.Consume(ref Source, ref Result);
			if (Result) { Level++; }
			while (Level > 0) {
				if (Source.EOF) { break; }
				Source.Position++;
				Result.Length++;
				if (From.CheckHeader(ref Source)) { From.Consume(ref Source, ref Result); }
				if (Result) { Level++; }
				if (To.CheckHeader(ref Source)) { To.Consume(ref Source, ref Result); }
				if (Result) { Level--; }
			}
			if (Level != 0) {
				Result.Error = new ConsumeFailedError(Expected: this.ToString());
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => base.Neglect(ref Source, ref Result);

		public Boolean Equals(NestedRanger other) => base.Equals(other);
	}
}