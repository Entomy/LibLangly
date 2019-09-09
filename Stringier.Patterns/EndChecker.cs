namespace System.Text.Patterns {
	internal sealed class EndChecker : Checker, IEquatable<EndChecker> {

		internal EndChecker() : base("␃") { }

		internal override void Consume(ref Source Source, ref Result Result) {
			if (!Source.EOF) { Result.Error = new ConsumeFailedError(Expected: ToString()); }
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			if (Source.EOF) { Result.Error = new ConsumeFailedError(Expected: ToString()); }
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case EndChecker other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => other.IsEmpty;

		public override Boolean Equals(String other) => String.IsNullOrEmpty(other);

		public Boolean Equals(EndChecker other) => true;

		public override Int32 GetHashCode() => 0;

		public override String ToString() => "␃";
		
	}
}
