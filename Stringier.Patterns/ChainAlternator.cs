namespace System.Text.Patterns {
	internal sealed class ChainAlternator : Node, IEquatable<ChainAlternator> {
		internal readonly Node[] Nodes;

		internal ChainAlternator(params Node[] Nodes) {
			this.Nodes = Nodes;
		}

		internal ChainAlternator(Node FirstNode, Node[] OtherNodes) {
			Nodes = new Node[OtherNodes.Length + 1];
			Nodes[0] = FirstNode;
			OtherNodes.CopyTo(Nodes, 1);
		}

		internal ChainAlternator(Node[] OtherNodes, Node LastNode) {
			Nodes = new Node[OtherNodes.Length + 1];
			OtherNodes.CopyTo(Nodes, 0);
			Nodes[Nodes.Length - 1] = LastNode;
		}

		internal ChainAlternator(Node[] FirstNodes, Node[] LastNodes) {
			Nodes = new Node[FirstNodes.Length + LastNodes.Length];
			FirstNodes.CopyTo(Nodes, 0);
			LastNodes.CopyTo(Nodes, FirstNodes.Length);
		}

		internal override Boolean CheckHeader(ref Source Source) {
			foreach (Node Node in Nodes) {
				if (Node.CheckHeader(ref Source)) { return true; }
			}
			return false;
		}

		internal override void Consume(ref Source Source, ref Result Result) {
			foreach (Node Node in Nodes) {
				Node.Consume(ref Source, ref Result);
				if (Result) {
					return;
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			Int32 OriginalPosition = Source.Position;
			Int32 OriginalLength = Result.Length;
			Int32 ShortestPattern = Int32.MaxValue;
			for (Int32 i = Nodes.Length - 1; i >= 0; i--) {
				Nodes[i].Neglect(ref Source, ref Result);
				if (Result.Length < ShortestPattern) { ShortestPattern = Result.Length - OriginalLength; }
				if (Result) {
					Source.Position = OriginalPosition;
					Result.Length = OriginalLength;
				} else {
					return;
				}
			}
			Source.Position += ShortestPattern;
			Result.Length += ShortestPattern;
		}

		public override Boolean Equals(Node node) {
			switch (node) {
			case ChainAlternator other:
				return Equals(other);
			default:
				return false;
			}
		}

		public Boolean Equals(ChainAlternator other) => Nodes.Equals(other.Nodes);

		public override Int32 GetHashCode() => Nodes.GetHashCode();

		public override String ToString() {
			StringBuilder Builder = new StringBuilder("┃");
			foreach (Node Node in Nodes) {
				Builder.Append($"{Node}│");
			}
			Builder.Remove(Builder.Length - 1, 1);
			Builder.Append("┃");
			return Builder.ToString();
		}

		#region Alternate

		internal override Node Alternate(Char Right) => new ChainAlternator(Nodes, new CharLiteral(Right));

		internal override Node Alternate(String Right) => new ChainAlternator(Nodes, new StringLiteral(Right));

		internal override Node Alternate(Node Right) {
			switch (Right) {
			case ChainAlternator chain:
				return new ChainAlternator(Nodes, chain.Nodes);
			default:
				return base.Alternate(Right);
			}
		}

		#endregion

		#region Spanner

		internal override Node Span() {
			foreach (Node Node in Nodes) {
				if (Node is Optor) { throw new PatternConstructionException("One or more of the components of this alternator are optional, and the alternator is marked as spanning. Options can not span, as it creates an infinite loop. While this potentially could succeed, this is absolutely an error."); }
			}
			return base.Span();
		}

		#endregion
	}
}
