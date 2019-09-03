namespace System.Text.Patterns {
	internal sealed class PrimativeNegator : PrimativePattern, IEquatable<PrimativeNegator> {
		private readonly PrimativePattern Pattern;

		internal PrimativeNegator(PrimativePattern Pattern) => this.Pattern = Pattern;

		protected internal override Int32 Length => Pattern.Length;

		public override Result Consume(ref Source Source) => Pattern.Neglect(ref Source);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case PrimativeNegator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => !Pattern.Equals(other);

		public override Boolean Equals(String other) => !Pattern.Equals(other);

		public Boolean Equals(PrimativeNegator other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => -Pattern.GetHashCode();

		protected internal override Result Neglect(ref Source Source) => Pattern.Consume(ref Source);

		public override String ToString() => $"!{Pattern}";
	}
}
