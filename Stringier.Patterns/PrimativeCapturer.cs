namespace System.Text.Patterns {
	internal sealed class PrimativeCapturer : PrimativePattern, IEquatable<PrimativeCapturer> {
		private readonly PrimativePattern Pattern;

		private readonly Capture capture = new Capture();

		protected internal override Int32 Length => Pattern.Length;

		internal PrimativeCapturer(PrimativePattern Pattern, out Capture capture) {
			this.Pattern = Pattern;
			capture = this.capture;
		}

		public override Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			capture.Value = Result;
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case PrimativeCapturer other:
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

		public Boolean Equals(PrimativeCapturer other) => Pattern.Equals(other);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			capture.Value = Result;
			return Result;
		}

		public override String ToString() => $"{Pattern}";
	}
}
