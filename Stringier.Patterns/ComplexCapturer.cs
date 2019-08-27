namespace System.Text.Patterns {
	internal sealed class ComplexCapturer : IComplexNode, IEquatable<ComplexCapturer> {
		private readonly IComplexNode Pattern;

		private readonly Capture Capture = new Capture();

		internal ComplexCapturer(IComplexNode Pattern, out Capture Capture) {
			this.Pattern = Pattern;
			Capture = this.Capture;
		}

		public Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			Capture.Value = Result;
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

		public Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(ComplexCapturer other) => Pattern.Equals(other);

		public override Int32 GetHashCode() => Pattern.GetHashCode();

		public Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			Capture.Value = Result;
			return Result;
		}

		public override String ToString() => $"{Pattern}";
	}
}
