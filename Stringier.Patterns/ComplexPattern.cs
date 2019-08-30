namespace System.Text.Patterns {
	internal abstract class ComplexPattern : Pattern {
		#region Alternator

		internal override Pattern Alternate(Pattern Right) => new Alternator(this, Right);

		internal override Pattern Alternate(Char Right) => new Alternator(this, Right);

		internal override Pattern Alternate(String Right) => new Alternator(this, Right);

		#endregion

		#region Capturer

		public override Pattern Capture(out Capture Capture) => new ComplexCapturer(this, out Capture);

		#endregion

		#region Concatenator

		internal override Pattern Concatenate(Pattern Right) => new ComplexConcatenator(this, Right);

		internal override Pattern Concatenate(Char Right) => new ComplexConcatenator(this, Right);

		internal override Pattern Concatenate(String Right) => new ComplexConcatenator(this, Right);

		#endregion

		#region Negator

		internal override Pattern Negate() => new ComplexNegator(this);

		#endregion

		#region Optor

		internal override Pattern Optional() => new Optor(this);

		#endregion

		#region Repeater

		internal override Pattern Repeat(Int32 Count) => new ComplexRepeater(this, Count);

		#endregion

		#region Spanner

		internal override Pattern Span() => new Spanner(this);

		#endregion
	}
}
