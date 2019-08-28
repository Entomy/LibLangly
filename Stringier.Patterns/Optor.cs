namespace System.Text.Patterns {
	internal sealed class Optor : ComplexPattern, IEquatable<Optor> {
		private readonly Pattern Pattern;

		internal Optor(Pattern Pattern) => this.Pattern = Pattern;

		public override Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			Result.Success = true; //Consuming an optional pattern is always considered successful, the only thing that changes is what is captured
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Optor other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => true;

		public override Boolean Equals(String other) => true;

		public Boolean Equals(Optor other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => ~Pattern.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			Result.Success = true; //Consuming an optional pattern is always considered successful, the only thing that changes is what is captured
			return Result;
		}

		public override String ToString() => $"~{Pattern}";

		#region Spanner

		public override Pattern Span() => throw new PatternConstructionException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");

		#endregion
	}
}
