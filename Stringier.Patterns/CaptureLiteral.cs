using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class CaptureLiteral : Literal, IEquatable<CaptureLiteral> {
		private readonly Capture capture;
		internal CaptureLiteral(Capture Capture) : this(Capture, false) { }

		internal CaptureLiteral(Capture Capture, Boolean IsCaseSensitive) : base(IsCaseSensitive) => capture = Capture;

		internal override Boolean CheckHeader(ref Source Source) => capture.Value.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) => capture.Value.Consume(ref Source, ref Result, IsCaseSensitive);

		internal override void Neglect(ref Source Source, ref Result Result) => capture.Value.Neglect(ref Source, ref Result, IsCaseSensitive);

		public override Boolean Equals(Node node) {
			switch (node) {
			case CaptureLiteral other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => Stringier.Equals(capture.Value, other, IsCaseSensitive);

		public override Boolean Equals(String other) => Stringier.Equals(capture.Value, other, IsCaseSensitive);

		public Boolean Equals(CaptureLiteral other) => Stringier.Equals(capture.Value, other.capture.Value, IsCaseSensitive);

		public override Int32 GetHashCode() => capture.GetHashCode();

		public override String ToString() => $"{capture}";
	}
}
