namespace System.Text.Patterns {
	internal sealed class ComplexCapturer : ComplexPattern, IEquatable<ComplexCapturer> {
		private readonly Pattern Pattern;

		private readonly Capture capture = new Capture();

		internal ComplexCapturer(Pattern Pattern, out Capture capture) {
			this.Pattern = Pattern;
			capture = this.capture;
		}

		protected internal override Boolean CheckFirstChar(ref Source Source) => Pattern.CheckFirstChar(ref Source);

		public override Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			capture.Value = Result;
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case ComplexCapturer other:
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

		public Boolean Equals(ComplexCapturer other) => Pattern.Equals(other);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			capture.Value = Result;
			return Result;
		}

		public override String ToString() => $"{Pattern}";
	}
}
