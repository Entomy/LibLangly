namespace System.Text.Patterns {
	internal sealed class Alternator : Pattern, IEquatable<Alternator> {
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

		internal override void Consume(ref Source Source, ref Result Result) {
			Error? Error;
			Left.Consume(ref Source, ref Result);
			if (!Result) {
				Error = Result.Error; //Store the error
				Result.Error = null; //Clear the error
				Right.Consume(ref Source, ref Result);
				if (!Result) {
					Result.Error = Error; //Resassign the first error, since both failed, but we want to be clear of that
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Int32 OriginalLength = Result.Length;
			Right.Neglect(ref Source, ref Result);
			if (Result) {
				Source.Position = OriginalPosition;
				Result.Length = OriginalLength;
				Left.Neglect(ref Source, ref Result);
			}
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

		public Boolean Equals(Alternator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() | Right.GetHashCode();

		public override String ToString() => $"┃{Left}│{Right}┃";
	}
}
