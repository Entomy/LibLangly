namespace System.Text.Patterns {
	internal abstract class PrimativePattern : Pattern {
		protected internal abstract Int32 Length { get; }

		#region Alternator

		internal override Pattern Alternate(Pattern Right) => new Alternator(this, Right);

		internal override Pattern Alternate(Char Right) => new Alternator(this, Right);

		internal override Pattern Alternate(String Right) => new Alternator(this, Right);

		#endregion

		#region Capturer

		public override Pattern Capture(out Capture Capture) => new PrimativeCapturer(this, out Capture);

		#endregion

		#region Concatenator

		internal override Pattern Concatenate(Pattern Right) {
			switch (Right) {
			case PrimativePattern right:
				return new PrimativeConcatenator(this, right);
			default:
				return new ComplexConcatenator(this, Right);
			}
		}

		internal override Pattern Concatenate(Char Right) => new PrimativeConcatenator(this, Right);

		internal override Pattern Concatenate(String Right) => new PrimativeConcatenator(this, Right);

		#endregion

		#region Negator

		internal override Pattern Negate() => new PrimativeNegator(this);

		#endregion

		#region Optor

		internal override Pattern Optional() => new Optor(this);

		#endregion

		#region Repeater

		internal override Pattern Repeat(Int32 Count) => new PrimativeRepeater(this, Count);

		#endregion

		#region Spanner

		internal override Pattern Span() => new Spanner(this);

		#endregion
	}
}
