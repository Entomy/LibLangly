using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class Concatenator : Pattern, IEquatable<Concatenator> {
		private readonly Pattern Left;

		private readonly Pattern Right;

		internal Concatenator(Pattern Left, Pattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal Concatenator(Pattern Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal Concatenator(Char Left, Pattern Right) : this(new CharLiteral(Left), Right) { }

		internal Concatenator(Pattern Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal Concatenator(String Left, Pattern Right) : this(new StringLiteral(Left), Right) { }

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

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Concatenator other:
				return Equals(other);
			case String other:
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
