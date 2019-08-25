using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class CaptureLiteral : IPrimativeNode, IEquatable<CaptureLiteral> {
		private readonly Capture Capture;

		internal CaptureLiteral(Capture Capture) => this.Capture = Capture;

		Int32 IPrimative.Length => Capture.Length;

		public Result Consume(String Source) => Capture.Value.Consume(Source);

		public Result Consume(ref Source Source) => Capture.Value.Consume(ref Source);

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

		public Boolean Equals(String other) => Capture.Equals(other);

		public Boolean Equals(CaptureLiteral other) => Capture.Equals(other.Capture);

		public override Int32 GetHashCode() => Capture.GetHashCode();

		public Result Neglect(String Source) => Capture.Value.Neglect(Source);

		public Result Neglect(ref Source Source) => Capture.Value.Neglect(ref Source);

		public override String ToString() => Capture.ToString();

	}
}
