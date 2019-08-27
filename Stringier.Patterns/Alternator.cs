namespace System.Text.Patterns {
	internal sealed class Alternator : IComplexNode, IEquatable<Alternator> {
		private readonly INode Left;
		private readonly INode Right;

		internal Alternator(INode Left, INode Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal Alternator(INode Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal Alternator(Char Left, INode Right) : this(new CharLiteral(Left), Right) { }

		internal Alternator(INode Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal Alternator(String Left, INode Right) : this(new StringLiteral(Left), Right) { }

		public Result Consume(ref Source Source) {
			Result Result = Left.Consume(ref Source);
			if (!Result) {
				Result = Right.Consume(ref Source);
			}
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Alternator other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(String other) => Left.Equals(other) || Right.Equals(other);

		public Boolean Equals(Alternator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() | Right.GetHashCode();

		public Result Neglect(ref Source Source) {
			Int32 OriginalPosition = Source.Position;
			Result Result = Right.Neglect(ref Source);
			if (Result) {
				Source.Position = OriginalPosition;
				Result = Left.Neglect(ref Source);
			}
			return Result;
		}

		public override String ToString() => $"({Left}|{Right})";
	}
}
