namespace System.Text.Patterns {
	internal sealed class Negator : Pattern, IEquatable<Negator> {
		private readonly Pattern Pattern;

		internal Negator(Pattern Pattern) => this.Pattern = Pattern;

		internal override Boolean CheckHeader(ref Source Source) => !Pattern.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			Pattern.Neglect(ref Source, ref Result);
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Pattern.Consume(ref Source, ref Result);
		}

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case Negator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Negator other) => Pattern.Equals(other.Pattern);

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = Consume(ref Source);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Result = Pattern.Consume(ref Source);
				if (Result) {
					//If this was successful, check if it consumed the entire source
					return Source.Length != 0;
				} else {
					//Otherwise it's definately not a match
					return false;
				}
			}
		}

		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = Consume(ref Source);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Result = Pattern.Consume(ref Source);
				if (Result) {
					//If this was successful, check if it consumed the entire source
					return Source.Length != 0;
				} else {
					//Otherwise it's definately not a match
					return false;
				}
			}
		}

		public override Int32 GetHashCode() => -Pattern.GetHashCode();

		public override String ToString() => $"!╣{Pattern}║";
	}
}
