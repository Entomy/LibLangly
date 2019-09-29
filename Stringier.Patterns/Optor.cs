namespace System.Text.Patterns {
	internal sealed class Optor : Pattern, IEquatable<Optor> {
		private readonly Pattern Pattern;

		internal Optor(Pattern Pattern) => this.Pattern = Pattern;

		internal override Boolean CheckHeader(ref Source Source) => Pattern.CheckHeader(ref Source); //This isn't supposed to work like an optor normally, as it's a performance optimization, not a parser

		internal override void Consume(ref Source Source, ref Result Result) {
			Pattern.Consume(ref Source, ref Result);
			Result.Error = null; //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Pattern.Neglect(ref Source, ref Result);
			Result.Error = null; //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}


		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Optor other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => true; //If a pattern is optional, it doesn't matter if it's there or not

		public override Boolean Equals(String other) => true; //If a pattern is optional, it doesn't matter if it's there or not

		public Boolean Equals(Optor other) => Pattern.Equals(other.Pattern);

		public override Int32 GetHashCode() => ~Pattern.GetHashCode();

		public override String ToString() => $"-╣{Pattern}║";

		#region Spanner

		internal override Pattern Span() => throw new PatternConstructionException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");

		#endregion
	}
}
