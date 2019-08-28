namespace System.Text.Patterns {
	internal sealed class Alternator : ComplexPattern, IEquatable<Alternator> {
		private readonly Pattern Left;
		private readonly Pattern Right;

		internal Alternator(Pattern Left, Pattern Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal Alternator(Pattern Left, Char Right) : this(Left, new CharLiteral(Right)) { }

		internal Alternator(Char Left, Pattern Right) : this(new CharLiteral(Left), Right) { }

		internal Alternator(Pattern Left, String Right) : this(Left, new StringLiteral(Right)) { }

		internal Alternator(String Left, Pattern Right) : this(new StringLiteral(Left), Right) { }

		public override Result Consume(ref Source Source) {
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

		public override Boolean Equals(ReadOnlySpan<Char> other) => Left.Equals(other) || Right.Equals(other);

		public override Boolean Equals(String other) => Left.Equals(other) || Right.Equals(other);

		public Boolean Equals(Alternator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() | Right.GetHashCode();

		protected internal override Result Neglect(ref Source Source) {
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
