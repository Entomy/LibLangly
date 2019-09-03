using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	internal sealed class PrimativeConcatenator : PrimativePattern, IEquatable<PrimativeConcatenator> {
		private readonly PrimativePattern Left;

		private readonly PrimativePattern Right;

		internal PrimativeConcatenator(PrimativePattern Left, PrimativePattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal PrimativeConcatenator(PrimativePattern Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal PrimativeConcatenator(Char Left, PrimativePattern Right) : this(new CharLiteral(Left), Right) { }

		internal PrimativeConcatenator(PrimativePattern Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal PrimativeConcatenator(String Left, PrimativePattern Right) : this(new StringLiteral(Left), Right) { }

		protected internal override Int32 Length => Left.Length + Right.Length;

		public override Result Consume(ref Source Source) {
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

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			if (this.Length != other.Length) { return false; }
			return
				Left.Equals(other.Slice(0, Left.Length))
				&& Right.Equals(other.Slice(Left.Length, Right.Length));
		}

		public override Boolean Equals(String other) {
			if (this.Length != other.Length) { return false; }
			return
				Left.Equals(other.Substring(0, Left.Length))
				&& Right.Equals(other.Substring(Left.Length, Right.Length));
		}

		public Boolean Equals(PrimativeConcatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
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
