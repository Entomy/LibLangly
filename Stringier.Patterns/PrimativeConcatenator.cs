using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class PrimativeConcatenator : IPrimativeNode, IEquatable<PrimativeConcatenator> {
		private readonly IPrimativeNode Left;

		private readonly IPrimativeNode Right;

		internal PrimativeConcatenator(IPrimativeNode Left, IPrimativeNode Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal PrimativeConcatenator(IPrimativeNode Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal PrimativeConcatenator(Char Left, IPrimativeNode Right) : this(new CharLiteral(Left), Right) { }

		internal PrimativeConcatenator(IPrimativeNode Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal PrimativeConcatenator(String Left, IPrimativeNode Right) : this(new StringLiteral(Left), Right) { }

		public Int32 Length => Left.Length + Right.Length;

		public Result Consume(ref Source Source) {
			if (this.Length > Source.Length) { return new Result(); }
			Boolean Success =
				Left.Equals(Source.Substring(Source.Position, Left.Length))
				&& Right.Equals(Source.Substring(Source.Position + Left.Length, Right.Length));
			return Success ? new Result(Source.Read(this.Length), Success) : new Result();
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case PrimativeConcatenator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => throw new NotImplementedException();

		public Boolean Equals(PrimativeConcatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		public Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			if (this.Length > Source.Length) { return new Result(); }
			Boolean Success =
				!Left.Equals(Source.Substring(OriginalPosition, Left.Length))
				&& !Right.Equals(Source.Substring(OriginalPosition + Left.Length, Right.Length));
			return Success ? new Result(Source.Read(this.Length), Success) : new Result();
		}

		public override String ToString() => $"{Left}{Right}";

	}
}
