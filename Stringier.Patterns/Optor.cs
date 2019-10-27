namespace System.Text.Patterns {
	internal sealed class Optor : Node, IEquatable<Optor> {
		private readonly Node Node;

		internal Optor(Node Node) => this.Node = Node;

		internal override Boolean CheckHeader(ref Source Source) => Node.CheckHeader(ref Source); //This isn't supposed to work like an optor normally, as it's a performance optimization, not a parser

		internal override void Consume(ref Source Source, ref Result Result) {
			Node.Consume(ref Source, ref Result);
			Result.Error.Clear(); //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Node.Neglect(ref Source, ref Result);
			Result.Error.Clear(); //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}


		public override Boolean Equals(Node node) {
			switch (node) {
			case Optor other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => true; //If a pattern is optional, it doesn't matter if it's there or not

		public override Boolean Equals(String other) => true; //If a pattern is optional, it doesn't matter if it's there or not

		public Boolean Equals(Optor other) => Node.Equals(other.Node);

		public override Int32 GetHashCode() => ~Node.GetHashCode();

		public override String ToString() => $"-╣{Node}║";

		#region Spanner

		internal override Node Span() => throw new PatternConstructionException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");

		#endregion
	}
}
