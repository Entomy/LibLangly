namespace System.Text.Patterns {
	internal abstract class ComplexPattern : Pattern {
		#region Alternator

		public override Pattern Alternate(Pattern Right) => new Alternator(this, Right);

		public override Pattern Alternate(Char Right) => new Alternator(this, Right);

		public override Pattern Alternate(String Right) => new Alternator(this, Right);

		#endregion

		#region Capturer

		public override Pattern Capture(out Capture Capture) => new ComplexCapturer(this, out Capture);

		#endregion

		#region Concatenator

		public override Pattern Concatenate(Pattern Right) => new ComplexConcatenator(this, Right);

		public override Pattern Concatenate(Char Right) => new ComplexConcatenator(this, Right);

		public override Pattern Concatenate(String Right) => new ComplexConcatenator(this, Right);

		#endregion

		#region Negator

		public override Pattern Negate() => new ComplexNegator(this);

		#endregion

		#region Optor

		public override Pattern Optional() => new Optor(this);

		#endregion

		#region Repeater

		public override Pattern Repeat(Int32 Count) => new ComplexRepeater(this, Count);

		#endregion

		#region Spanner

		public override Pattern Span() => new Spanner(this);

		#endregion
	}
}
