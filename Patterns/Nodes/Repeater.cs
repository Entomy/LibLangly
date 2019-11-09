using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Nodes.Node"/> whos content repeats a given number of times.
	/// </summary>
	internal sealed class Repeater : Node, IEquatable<Repeater> {
		/// <summary>
		/// The amount of times to be parsed.
		/// </summary>
		private readonly Int32 Count;

		/// <summary>
		/// The <see cref="Nodes.Node"/> to be parsed.
		/// </summary>
		private readonly Node Node;

		/// <summary>
		/// Initialize a new <see cref="Repeater"/> from the given <paramref name="node"/> and <paramref name="count"/>
		/// </summary>
		/// <param name="node">The <see cref="Nodes.Node"/> to be parsed.</param>
		/// <param name="count">The amount of times to be parsed.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> must be a positive integer.</exception>
		internal Repeater(Node node, Int32 count) {
			Node = node;
			if (count < 1) { throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive"); }
			Count = count;
		}

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => Node.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Consume(ref Source source, ref Result result) {
			for (Int32 i = 0; i < Count; i++) {
				Node.Consume(ref source, ref result);
				if (!result) { return; }
			}
		}

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.
		internal override void Neglect(ref Source source, ref Result result) {
			for (Int32 i = 0; i < Count; i++) {
				Node.Neglect(ref source, ref result);
				if (!result) { return; }
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</
		public override Boolean Equals(Node node) {
			switch (node) {
			case Repeater other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="Concatenator"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns
		public Boolean Equals(Repeater other) => Node.Equals(other.Node) && Count.Equals(other.Count);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Node.GetHashCode() ^ Count.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns>
		public override String ToString() => $"{Count}╣{Node}║";
	}
}
