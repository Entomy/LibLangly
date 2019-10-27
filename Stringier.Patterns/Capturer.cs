namespace System.Text.Patterns {
	internal sealed class Capturer : Node, IEquatable<Capturer> {
		private readonly Node Node;

		private readonly Capture capture = new Capture();

		internal Capturer(Node Node, out Capture capture) {
			this.Node = Node;
			capture = this.capture;
		}

		internal override Boolean CheckHeader(ref Source Source) => Node.CheckHeader(ref Source);

		internal override void Consume(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Node.Consume(ref Source, ref Result);
			capture.Value = Source.Substring(OriginalPosition, Source.Position - OriginalPosition).ToString();
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Node.Neglect(ref Source, ref Result);
			capture.Value = Source.Substring(OriginalPosition, Source.Position - OriginalPosition).ToString();
		}

		public override Boolean Equals(Node node) {
			switch (node) {
			case Capturer other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) {
			capture.Value = other.ToString();
			return Node.Equals(other);
		}

		public override Boolean Equals(String other) {
			capture.Value = other;
			return Node.Equals(other);
		}

		public Boolean Equals(Capturer other) => Node.Equals(other);

		public override Int32 GetHashCode() => Node.GetHashCode();

		public override String ToString() => $"{Node}";
	}
}
