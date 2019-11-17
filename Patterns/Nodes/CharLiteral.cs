using System;

namespace Stringier.Patterns.Nodes {
	/// <summary>	
	/// Represents a character literal, a pattern matching this exact character.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Char"/> into something that we can treat as a part of a pattern.
	/// </remarks>
	internal sealed class CharLiteral : Literal, IEquatable<CharLiteral> {
		/// <summary>
		/// The actual <see cref="System.Char"/> being matched.
		/// </summary>
		internal readonly Char Char;

		/// <summary>
		/// Initialize a new <see cref="CharLiteral"/> with the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="System.Char"/> to parse.</param>
		internal CharLiteral(Char @char) : base(StringComparison.Ordinal) => Char = @char;

		/// <summary>
		/// Initialize a new <see cref="CharLiteral"/> with the given <paramref name="char"/>.
		/// </summary>
		/// <param name="char">The <see cref="System.Char"/> to parse.</param>
		/// <param name="comparisonType">The <see cref="StringComparison"/> to use when parsing.</param>
		internal CharLiteral(Char @char, StringComparison comparisonType) : base(comparisonType) => Char = @char;

		/// <summary>
		/// Checks the first character in the <paramref name="source"/> against the header of this node.
		/// </summary>
		/// <remarks>
		/// This is primarily used to check whether a pattern may exist at the current position.
		/// </remarks>
		/// <param name="source">The <see cref="Source"/> to check against.</param>
		/// <returns><c>true</c> if this <see cref="Pattern"/> may be present, <c>false</c> if definately not.</returns>
		internal override Boolean CheckHeader(ref Source source) => Char.CheckHeader(ref source);

		/// <summary>
		/// Call the Consume parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		internal override void Consume(ref Source source, ref Result result) => Char.Consume(ref source, ref result, ComparisonType);

		/// <summary>
		/// Call the Neglect parser of this <see cref="Node"/> on the <paramref name="source"/> with the <paramref name="result"/>.
		/// </summary>
		/// <param name="source">The <see cref="Source"/> to consume.</param>
		/// <param name="result">A <see cref="Result"/> containing whether a match occured and the captured <see cref="String"/>.</param
		internal override void Neglect(ref Source source, ref Result result) => Char.Neglect(ref source, ref result, ComparisonType);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="node">The <see cref="Node"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(Node node) {
			switch (node) {
			case CharLiteral other:
				return Equals(other);
			default:
				return false;
			}
		}

		/// <summary>
		/// Determines whether the specified <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="ReadOnlySpan{T}"/> of <see cref="Char"/> to check against this <see cref="Node"/>.</param>.
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(ReadOnlySpan<Char> other) => Char.ToString().Equals(other, ComparisonType);

		/// <summary>
		/// Determines whether the specified <see cref="String"/> can be represented by this <see cref="Node"/>.
		/// </summary>
		/// <param name="other">The <see cref="String"/> to check against this <see cref="Node"/>.</param>
		/// <returns><c>true</c> if representable; otherwise, <c>false</c>.</returns>
		public override Boolean Equals(String other) => Char.ToString().Equals(other, ComparisonType);

		/// <summary>
		/// Determines whether this instance and a specified object have the same value.
		/// </summary>
		/// <param name="other">The <see cref="CharLiteral"/> to compare with the current <see cref="Node"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="Node"/> is equal to the current <see cref="Node"/>; otherwise, <c>false</c>.</returns>
		public Boolean Equals(CharLiteral other) => ComparisonType.Equals(other.ComparisonType) && this.Char.Equals(other.Char, ComparisonType);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Char.GetHashCode();

		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="Node"/>.
		/// </summary>
		/// <returns>A <see cref="String"/> that represents the current <see cref="Node"/>.</returns>
		public override String ToString() => $"{Char}";

		#region Concatenator

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Node"/> comes before the <paramref name="right"/> <see cref="Node"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Node"/>.</param>
		/// <returns>A new <see cref="Node"/> concatenating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal override Node Concatenate(Node right) {
			switch (right) {
			case StringLiteral @string:
				if (ComparisonType.Equals(@string.ComparisonType)) {
					return new StringLiteral(Char + @string.String);
				} else {
					goto default;
				}
			case CharLiteral @char:
				if (ComparisonType.Equals(@char.ComparisonType)) {
					return new StringLiteral(Char.ToString() + @char.Char.ToString());
				} else {
					goto default;
				}
			default:
				return base.Concatenate(right);
			}
		}

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Node"/> comes before the <paramref name="right"/> <see cref="String"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="String"/>.</param>
		/// <returns>A new <see cref="Node"/> concatenating this <see cref="Node"/> and <paramref name="right"/>.</returns
		internal override Node Concatenate(String right) => new StringLiteral(Char + right);

		/// <summary>
		/// Concatenates the nodes so that this <see cref="Node"/> comes before the <paramref name="right"/> <see cref="Char"/>.
		/// </summary>
		/// <param name="right">The succeeding <see cref="Char"/>.</param>
		/// <returns>A new <see cref="Node"/> concatenating this <see cref="Node"/> and <paramref name="right"/>.</returns>
		internal override Node Concatenate(Char right) => new StringLiteral(Char.ToString() + right);

		#endregion

		#region Repeater

		/// <summary>
		/// Repeats this <see cref="Node"/> <paramref name="count"/> times.
		/// </summary>
		/// <param name="count">The amount of times to repeat.</param>
		/// <returns>A new <see cref="Node"/> repeated <paramref name="count"/> times.</returns>
		internal override Node Repeat(Int32 count) => new StringLiteral(Char.Repeat(count));

		#endregion
	}
}
