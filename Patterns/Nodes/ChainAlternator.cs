using System;
using System.Text;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the alternation of more than two <see cref="Node"/>. That is, one of many <see cref="Node"/>.
	/// </summary>
	/// <remarks>
	/// This is an optimization around cases of alternating alternators; there's much less indirection and other issues when flattening that portion of the graph. It also causes better syntax when written to a string.
	/// </remarks>
	internal sealed class ChainAlternator : Node, IEquatable<ChainAlternator> {
		/// <summary>
		/// The possible <see cref="Node"/> matches.
		/// </summary>
		internal readonly Node[] Nodes;

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="nodes"/>.
		/// </summary>
		/// <param name="nodes">The possible <see cref="Node"/> matches.</param>
		internal ChainAlternator(params Node[] nodes) => Nodes = nodes;

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="firstNode"/> and <paramref name="otherNodes"/>.
		/// </summary>
		/// <param name="firstNode">The very first <see cref="Node"/> to check.</param>
		/// <param name="otherNodes">The other possible <see cref="Node"/> matches.</param>
		internal ChainAlternator(Node firstNode, Node[] otherNodes) {
			Nodes = new Node[otherNodes.Length + 1];
			Nodes[0] = firstNode;
			otherNodes.CopyTo(Nodes, 1);
		}

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="otherNodes"/> and <paramref name="lastNode"/>.
		/// </summary>
		/// <param name="otherNodes">All but the very last possible <see cref="Node"/> to check.</param>
		/// <param name="lastNode">The very last <see cref="Node"/> to check.</param>
		internal ChainAlternator(Node[] otherNodes, Node lastNode) {
			Nodes = new Node[otherNodes.Length + 1];
			otherNodes.CopyTo(Nodes, 0);
			Nodes[Nodes.Length - 1] = lastNode;
		}

		/// <summary>
		/// Initialize a new <see cref="ChainAlternator"/> with the <paramref name="firstNodes"/> and <paramref name="lastNodes"/>.
		/// </summary>
		/// <param name="firstNodes">The first set of <see cref="Node"/> to check.</param>
		/// <param name="lastNodes">The last set of <see cref="Node"/> to check.</param>
		internal ChainAlternator(Node[] firstNodes, Node[] lastNodes) {
			Nodes = new Node[firstNodes.Length + lastNodes.Length];
			firstNodes.CopyTo(Nodes, 0);
			lastNodes.CopyTo(Nodes, firstNodes.Length);
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) {
			foreach (Node Node in Nodes) {
				if (Node.CheckHeader(ref source)) { return true; }
			}
			return false;
		}

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Consume(ref Source source, ref Result result) {
			foreach (Node Node in Nodes) {
				Node.Consume(ref source, ref result);
				if (result) {
					return;
				}
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Neglect(ref Source source, ref Result result) {
			Int32 OriginalPosition = source.Position;
			Int32 OriginalLength = result.Length;
			Int32 ShortestPattern = Int32.MaxValue;
			for (Int32 i = Nodes.Length - 1; i >= 0; i--) {
				Nodes[i].Neglect(ref source, ref result);
				if (result.Length < ShortestPattern) {
					ShortestPattern = result.Length - OriginalLength;
				}
				if (result) {
					source.Position = OriginalPosition;
					result.Length = OriginalLength;
				} else {
					return;
				}
			}
			source.Position += ShortestPattern;
			result.Length += ShortestPattern;
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</
		public override Boolean Equals(Node node) {
			switch (node) {
			case ChainAlternator other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</
		public Boolean Equals(ChainAlternator other) => Nodes.Equals(other.Nodes);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</
		public override Int32 GetHashCode() => Nodes.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns>
		public override String ToString() {
			StringBuilder Builder = new StringBuilder("┃");
			foreach (Node Node in Nodes) {
				_ = Builder.Append($"{Node}│");
			}
			_ = Builder.Remove(Builder.Length - 1, 1);
			_ = Builder.Append("┃");
			return Builder.ToString();
		}

		#region Alternate

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="Char"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</returns
		internal override Node Alternate(Char right) => new ChainAlternator(Nodes, new CharLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="String"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</
		internal override Node Alternate(String right) => new ChainAlternator(Nodes, new StringLiteral(right));

		/// <summary>
		/// Declares <paramref name="right"/> to be an alternate of this <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The <see cref="Node"/> to check if this <see cref="Node"/> does not match.</param>
		/// <returns>A new <see cref="Node"/> alternating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal override Node Alternate(Node right) {
			switch (right) {
			case ChainAlternator chain:
				return new ChainAlternator(Nodes, chain.Nodes);
			default:
				return base.Alternate(right);
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
