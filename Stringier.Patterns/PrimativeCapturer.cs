namespace System.Text.Patterns {
	internal sealed class PrimativeCapturer : IPrimativeNode, IEquatable<PrimativeCapturer> {
		private readonly IPrimativeNode Pattern;

		private readonly Capture Capture = new Capture();

		internal PrimativeCapturer(IPrimativeNode Pattern, out Capture Capture) {
			this.Pattern = Pattern;
			Capture = this.Capture;
		}

		Int32 IPrimative.Length => Pattern.Length;

		public Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			Capture.Value = Result;
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

		public Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(PrimativeCapturer other) => Pattern.Equals(other);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		public Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			Capture.Value = Result;
			return Result;
		}

		public override String ToString() => $"{Pattern}";
	}
}
