namespace System.Text.Patterns {
	internal sealed class Capturer : Pattern, IEquatable<Capturer> {
		private readonly Pattern Pattern;

		private readonly Capture capture = new Capture();

		internal Capturer(Pattern Pattern, out Capture capture) {
			this.Pattern = Pattern;
			capture = this.capture;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Pattern.Consume(ref Source, ref Result);
			capture.Value = Source.Substring(OriginalPosition, Source.Position - OriginalPosition).ToString();
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Pattern.Neglect(ref Source, ref Result);
			capture.Value = Source.Substring(OriginalPosition, Source.Position - OriginalPosition).ToString();
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Capturer other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			capture.Value = other.ToString();
			return Pattern.Equals(other);
		}

		public override Boolean Equals(String other) {
			capture.Value = other;
			return Pattern.Equals(other);
		}

		public Boolean Equals(Capturer other) => Pattern.Equals(other);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		public override String ToString() => $"{Pattern}";
	}
}
