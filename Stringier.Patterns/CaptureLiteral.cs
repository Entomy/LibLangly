using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class CaptureLiteral : PrimativePattern, IEquatable<CaptureLiteral> {
		private readonly StringComparison ComparisonType = Stringier.DefaultComparisonType;

		private readonly Capture capture;

		internal CaptureLiteral(Capture Capture) : this(Capture, Stringier.DefaultComparisonType) { }

		internal CaptureLiteral(Capture Capture, StringComparison ComparisonType) {
			this.capture = Capture;
			this.ComparisonType = ComparisonType;
		}

		protected internal override Int32 Length => capture.Length;

		public override Result Consume(ref Source Source) => capture.Value.Consume(ref Source, ComparisonType);

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

		protected internal override Result Neglect(ref Source Source) => capture.Value.Neglect(ref Source, ComparisonType);

		public override String ToString() => $"{capture}";
	}
}
