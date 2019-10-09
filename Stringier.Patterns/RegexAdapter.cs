using System.Text.RegularExpressions;

namespace System.Text.Patterns {
	internal sealed class RegexAdapter : Pattern, IEquatable<RegexAdapter> {
		private readonly Regex Regex;

		internal RegexAdapter(Regex Regex) {
			String Pattern = Regex.ToString();
			if (Pattern[0] != '^') {
				throw new PatternConstructionException("Regex me be anchored to the begining");
			}
			this.Regex = Regex;
		}

		internal override Boolean CheckHeader(ref Source Source) => throw new NotImplementedException();

		internal override void Consume(ref Source Source, ref Result Result) {
			Match Match = Regex.Match(Source.ToString());
			if (Match.Success) {
				Source.Position += Match.Length;
				Result.Length += Match.Length;
			} else {
				Result.Error = new ConsumeFailedError(Expected: this);
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) => throw new InvalidOperationException("Regex can not be negated");

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case RegexAdapter other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(RegexAdapter other) => Regex.Equals(other.Regex);

		public override Int32 GetHashCode() => Regex.GetHashCode();

		public override String ToString() => $"╱{Regex}╱";

		#region Negator

		internal override Pattern Negate() => throw new PatternConstructionException("Regex can not be negated");

		#endregion
	}
}
