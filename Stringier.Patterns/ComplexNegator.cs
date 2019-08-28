namespace System.Text.Patterns {
	internal sealed class ComplexNegator : ComplexPattern, IEquatable<ComplexNegator> {
		private readonly Pattern Pattern;

		internal ComplexNegator(Pattern Pattern) => this.Pattern = Pattern;

		public override Result Consume(ref Source Source) => Pattern.Neglect(ref Source);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ComplexNegator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => !Pattern.Equals(other);

		public override Boolean Equals(String other) => !Pattern.Equals(other);

		public Boolean Equals(ComplexNegator other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => -Pattern.GetHashCode();

		protected internal override Result Neglect(ref Source Source) => Pattern.Consume(ref Source);

		public override String ToString() => $"!{Pattern}";
	}
}
