using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class CaptureLiteral : Literal, IEquatable<CaptureLiteral> {
		private readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		private readonly Capture capture;

		internal CaptureLiteral(Capture Capture) : this(Capture, Stringier.DefaultComparisonType) { }

		internal CaptureLiteral(Capture Capture, StringComparison ComparisonType) {
			this.capture = Capture;
			this.ComparisonType = ComparisonType;
		}

		internal override Boolean CheckHeader(ref Source Source) => capture.Value.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => capture.Value.Consume(ref Source, ref Result, ComparisonType);

		internal override void Neglect(ref Source Source, ref Result Result) => capture.Value.Neglect(ref Source, ref Result, ComparisonType);

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case CaptureLiteral other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(capture.Value, other, ComparisonType);

		public override Boolean Equals(String other) => Stringier.Equals(capture.Value, other, ComparisonType);

		public Boolean Equals(CaptureLiteral other) => capture.Equals(other.capture) && ComparisonType.Equals(other.ComparisonType);

		public override Int32 GetHashCode() => capture.GetHashCode();

		public override String ToString() => $"{capture}";
	}
}
