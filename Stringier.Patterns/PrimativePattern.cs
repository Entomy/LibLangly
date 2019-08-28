namespace System.Text.Patterns {
	internal abstract class PrimativePattern : Pattern {
		protected internal abstract Int32 Length { get; }

		#region Alternator

		public override Pattern Alternate(Pattern Right) => new Alternator(this, Right);

		public override Pattern Alternate(Char Right) => new Alternator(this, Right);

		public override Pattern Alternate(String Right) => new Alternator(this, Right);

		#endregion

		#region Capturer

		public override Pattern Capture(out Capture Capture) => new PrimativeCapturer(this, out Capture);

		#endregion

		#region Concatenator

		public override Pattern Concatenate(Pattern Right) {
			switch (Right) {
			case PrimativePattern right:
				return new PrimativeConcatenator(this, right);
			default:
				return new ComplexConcatenator(this, Right);
			}
		}

		public override Pattern Concatenate(Char Right) => new PrimativeConcatenator(this, Right);

		public override Pattern Concatenate(String Right) => new PrimativeConcatenator(this, Right);

		#endregion

		#region Negator

		public override Pattern Negate() => new PrimativeNegator(this);

		#endregion

		#region Optor

		public override Pattern Optional() => new Optor(this);

		#endregion

		#region Repeater

		public override Pattern Repeat(Int32 Count) => new PrimativeRepeater(this, Count);

		#endregion

		#region Spanner

		public override Pattern Span() => new Spanner(this);

		#endregion
	}
}
