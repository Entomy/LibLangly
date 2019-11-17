using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Nodes.Node"/> whos content is optional.
	/// </summary>
	internal sealed class Optor : Node, IEquatable<Optor> {
		/// <summary>
		/// The <see cref="Nodes.Node"/> to be parsed.
		/// </summary>
		private readonly Node Node;

		/// <summary>
		/// Intialize a new <see cref="Optor"/> from the given <paramref name="node"/>.
		/// </summary>
		/// <param name="node">The <see cref="Nodes.Node"/> to be parsed.</param>
		internal Optor(Node node) => Node = node;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => Node.CheckHeader(ref source); //This isn't supposed to work like an optor normally, as it's a performance optimization, not a parser

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Consume(ref Source source, ref Result result) {
			Node.Consume(ref source, ref result);
			result.Error.Clear(); //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Neglect(ref Source source, ref Result result) {
			Node.Neglect(ref source, ref result);
			result.Error.Clear(); //If a pattern is optional, it doesn't matter if it's there or not, so we never actually have an error
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</
		public override Boolean Equals(Node node) {
			switch (node) {
			case Optor other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Node"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns
		public override Boolean Equals(ReadOnlySpan<Char> other) => true; //If a pattern is optional, it doesn't matter if it's there or not

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Node"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) => true; //If a pattern is optional, it doesn't matter if it's there or not

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Optor"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public Boolean Equals(Optor other) => Node.Equals(other.Node);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => ~Node.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns>
		public override String ToString() => $"-╣{Node}║";

		#region Spanner

		internal override Node Span() => throw new PatternConstructionException("Options can not span, as it creates an infinite loop. You probably want to make a span optional instead.");

		#endregion
	}
}
