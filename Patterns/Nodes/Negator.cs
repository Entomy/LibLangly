using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>
	/// Represents a <see cref="Nodes.Node"/> whos content should be neglected.
	/// </summary>
	/// <remarks>
	/// This is syntactic sugar around the Neglect parser, which parses anything that does not match the pattern, with some special semantics for certain patterns. It is basically saying "anything that isn't this, that is the same length".
	/// </remarks>
	internal sealed class Negator : Node, IEquatable<Negator> {
		/// <summary>
		/// The <see cref="Nodes.Node"/> to be parsed.
		/// </summary>
		private readonly Node Node;

		/// <summary>
		/// Intialize a new <see cref="Negator"/> from the given <paramref name="node"/>.
		/// </summary>
		/// <param name="node">The <see cref="Nodes.Node"/> to be parsed.</param>
		internal Negator(Node node) => Node = node;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns
		internal override Boolean CheckHeader(ref Source source) => !Node.CheckHeader(ref source);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <remarks>
		/// This is not an error, it deliberately calls the other parser.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Consume(ref Source source, ref Result result) => Node.Neglect(ref source, ref result);

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <remarks>
		/// This is not an error, it deliberately calls the other parser.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</
		internal override void Neglect(ref Source source, ref Result result) => Node.Consume(ref source, ref result);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</
		public override Boolean Equals(Node node) {
			switch (node) {
			case Negator other:
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
		public Boolean Equals(Negator other) => Node.Equals(other.Node);

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Node"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns
		public override Boolean Equals(ReadOnlySpan<Char> other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Node.Consume(ref Source, ref Result);
				if (Result) {
					//If this was successful, check if it consumed the entire source
					return Source.Length != 0;
				} else {
					//Otherwise it's definately not a match
					return false;
				}
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Node"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns
		public override Boolean Equals(String other) {
			Source Source = new Source(other);
			Result Result = new Result(ref Source);
			Consume(ref Source, ref Result);
			if (Result) {
				return true;
			} else {
				//We have to do some manual work here
				//Normally we would store the source position, but since we create the source in this method, the original position is always 0
				//Call the underlying neglect
				Node.Consume(ref Source, ref Result);
				//If this was successful, check if it consumed the entire source, otherwise it's definately not a match
				return Result && Source.Length != 0;
			}
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns
		public override Int32 GetHashCode() => -Node.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns
		public override String ToString() => $"!╣{Node}║";
	}
}
