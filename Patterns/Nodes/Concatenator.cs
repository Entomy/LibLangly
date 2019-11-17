using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents the concatenation of two <see cref="Node"/>. That is, one <see cref="Node"/> directly after another.
	/// </summary>
	internal sealed class Concatenator : Node, IEquatable<Concatenator> {
		/// <summary>
		/// The lefthand <see cref="Node"/>; the first.
		/// </summary>
		private readonly Node Left;

		/// <summary>
		/// The righthand <see cref="Node"/>; the last.
		/// </summary>
		private readonly Node Right;

		/// <summary>
		/// Initialize a new <see cref="Concatenator"/> with the <paramref name="left"/> and <paramref name="right"/> <see cref="Node"/>.
		/// </summary>
		/// <param name="left">The lefthand <see cref="Node"/>; the first.</param>
		/// <param name="right">The righthand <see cref="Node"/>; the last.</param>
		internal Concatenator(Node left, Node right) {
			Left = left;
			Right = right;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Left.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		internal override void Consume(ref Source source, ref Result result) {
			Left.Consume(ref source, ref result);
			if (!result) {
				return;
			}
			Right.Consume(ref source, ref result);
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		internal override void Neglect(ref Source source, ref Result result) {
			Left.Neglect(ref source, ref result);
			if (!result) {
				return;
			}
			Right.Neglect(ref source, ref result);
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Node node) {
			switch (node) {
			case Concatenator other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns>
		public Boolean Equals(Concatenator other) => Left.Equals(other.Left) && Right.Equals(other.Right);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Left.GetHashCode() & Right.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns>
		public override String ToString() => $"{Left}{Right}";
	}
}
