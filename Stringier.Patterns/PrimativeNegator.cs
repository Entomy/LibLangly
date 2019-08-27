namespace System.Text.Patterns {
	internal sealed class PrimativeNegator : IPrimativeNode, IEquatable<PrimativeNegator> {
		private readonly IPrimativeNode Pattern;

		internal PrimativeNegator(IPrimativeNode Pattern) => this.Pattern = Pattern;

		Int32 IPrimative.Length => Pattern.Length;

		public Result Consume(ref Source Source) => Pattern.Neglect(ref Source);

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

		public Boolean Equals(String other) => !Pattern.Equals(other);

		public Boolean Equals(PrimativeNegator other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => -Pattern.GetHashCode();

		public Result Neglect(ref Source Source) => Pattern.Consume(ref Source);

		public override String ToString() => $"!{Pattern}";
	}
}
