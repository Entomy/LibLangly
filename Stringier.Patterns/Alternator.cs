namespace System.Text.Patterns {
	internal sealed class Alternator : Node, IEquatable<Alternator> {
		private readonly Node Left;
		private readonly Node Right;

		internal Alternator(Node Left, Node Right) {
			this.Left = Left;
			this.Right = Right;
		}

		internal override Boolean CheckHeader(ref Source Source) => Left.CheckHeader(ref Source) || Right.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			Left.Consume(ref Source, ref Result);
			if (!Result) {
				Error Error = Result.Error; //Store the error
				Result.Error.Clear();
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

		public override Boolean Equals(Node node) {
			switch (node) {
			case Alternator other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(Alternator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		public override Int32 GetHashCode() => Left.GetHashCode() | Right.GetHashCode();

		public override String ToString() => $"┃{Left}│{Right}┃";

		#region Alternator

		internal override Node Alternate(Node Right) => new ChainAlternator(this.Left, this.Right, Right);

		internal override Node Alternate(Char Right) => new ChainAlternator(this.Left, this.Right, new CharLiteral(Right));

		internal override Node Alternate(String Right) => new ChainAlternator(this.Left, this.Right, new StringLiteral(Right));

		#endregion

		#region Spanner

		internal override Node Span() {
			if (Left is Optor || Right is Optor) {
				throw new PatternConstructionException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop. While this potentially could succeed, this is absolutely an error.");
			} else {
				return base.Span();
			}
		}

		#endregion
	}
}
