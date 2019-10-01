namespace System.Text.Patterns {
	internal sealed class ChainAlternator : Pattern, IEquatable<ChainAlternator> {
		private readonly Pattern[] Patterns;

		internal ChainAlternator(params Pattern[] Patterns) {
			this.Patterns = Patterns;
		}

		internal override Boolean CheckHeader(ref Source Source) {
			foreach (Pattern Pattern in Patterns) {
				if (Pattern.CheckHeader(ref Source)) { return true; }
			}
			return false;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			foreach (Pattern Pattern in Patterns) {
				Pattern.Consume(ref Source, ref Result);
				if (Result) {
					return;
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new NotImplementedException();

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case ChainAlternator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(ChainAlternator other) => Patterns.Equals(other.Patterns);

		public override Int32 GetHashCode() => Patterns.GetHashCode();

		public override String ToString() {
			StringBuilder Builder = new StringBuilder("┃");
			foreach (Pattern Pattern in Patterns) {
				Builder.Append($"{Pattern}│");
			}
			Builder.Remove(Builder.Length - 1, 1);
			Builder.Append("┃");
			return Builder.ToString();
		}
	}
}
