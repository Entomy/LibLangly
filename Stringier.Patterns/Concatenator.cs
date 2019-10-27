using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class Concatenator : Node, IEquatable<Concatenator> {
		private readonly Node Left;

		private readonly Node Right;

		internal Concatenator(Node Left, Node Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal override Boolean CheckHeader(ref Source Source) => Left.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			Left.Consume(ref Source, ref Result);
			if (!Result) { return; }
			Right.Consume(ref Source, ref Result);
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Left.Neglect(ref Source, ref Result);
			if (!Result) { return; }
			Right.Neglect(ref Source, ref Result);
		}

		public override Boolean Equals(Node node) {
			switch (node) {
			case Concatenator other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Concatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public override String ToString() => $"{Left}{Right}";
	}
}
