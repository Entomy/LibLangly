using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class CaptureLiteral : Primative, IEquatable<CaptureLiteral> {
		private readonly Capture Capture;

		internal CaptureLiteral(Capture Capture) => this.Capture = Capture;

		public override Result Consume(ref Source Source) => Capture.Value.Consume(ref Source);

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

		public override Boolean Equals(String other) => Capture.Equals(other);

		public Boolean Equals(CaptureLiteral other) => Capture.Equals(other.Capture);

		public override Int32 GetHashCode() => Capture.GetHashCode();

		public override Result Neglect(ref Source Source) => Capture.Value.Neglect(ref Source);

		public override String ToString() => Capture.ToString();

	}
}
