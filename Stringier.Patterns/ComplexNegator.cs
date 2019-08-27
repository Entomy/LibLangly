namespace System.Text.Patterns {
	internal sealed class ComplexNegator : IComplexNode, IEquatable<ComplexNegator> {
		private readonly IComplexNode Pattern;

		internal ComplexNegator(IComplexNode Pattern) => this.Pattern = Pattern;

		public Result Consume(ref Source Source) => Pattern.Neglect(ref Source);

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

		public Boolean Equals(String other) => !Pattern.Equals(other);

		public Boolean Equals(ComplexNegator other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => -Pattern.GetHashCode();

		public Result Neglect(ref Source Source) => Pattern.Consume(ref Source);

		public override String ToString() => $"!{Pattern}";
	}
}
